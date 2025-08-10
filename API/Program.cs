using API.Middleware;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration) // Permite configurar via appsettings.json
    .Enrich.FromLogContext() // Adiciona propriedades do contexto do log
    .WriteTo.Console()
    .WriteTo.File("logs/skinet.txt", rollingInterval: RollingInterval.Hour) // Logs diários
                                                                            // Adicione outros sinks aqui, por exemplo:
                                                                            // .WriteTo.Seq("http://localhost:5341") // Se você estiver usando o Seq
    .CreateLogger();

// **Passo 2: Usar o Serilog como provedor de log para o .NET**
builder.Host.UseSerilog();


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<StoreContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ISAVBuscaProduto, SAVBuscaProduto>();


builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddCors();

builder.Services.AddSingleton<IConnectionMultiplexer>(x =>
{
    string connRedis = builder.Configuration.GetConnectionString("Redis") ?? throw new Exception("Connection string for Redis is not configured.");
    ConfigurationOptions configuration = ConfigurationOptions.Parse(connRedis, true);

    return ConnectionMultiplexer.Connect(configuration);
});
builder.Services.AddSingleton<ICartService, CartService>();

// esta informação esta no storecontext.cs
builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<AppUser>().AddEntityFrameworkStores<StoreContext>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddSignalR();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseCors(policy =>
{

    policy.WithOrigins("https://localhost:4200", "http://localhost:4200")
           .AllowAnyHeader()
          .AllowAnyMethod()
          .AllowCredentials();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

// Este faz os Endpoints de Identity funcionar
app.MapGroup("api").MapIdentityApi<AppUser>();



try
{
    using var scope = app.Services.CreateScope();
    var services = scope.ServiceProvider;

    var context = services.GetRequiredService<StoreContext>();

    // Ensure the database is created
    // Apply migrations and seed data
    await context.Database.MigrateAsync();
    await StoreContextSeed.SeedDataAsync(context);
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred while seeding the database: {ex.Message}");
    throw;
}

// **Passo 3: Garantir que o logger seja liberado ao sair da aplicação**
// Isso é importante para garantir que todos os logs pendentes sejam gravados
app.Lifetime.ApplicationStopped.Register(Log.CloseAndFlush);
app.Run();
