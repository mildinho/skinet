using Core.Entities;
using Infrastructure.Config;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContext(DbContextOptions options) : IdentityDbContext<AppUser> (options)
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Fabricante> Fabricante { get; set; }

        public DbSet<Produto> Produto { get; set; }
        public DbSet<ProdutoDetalhe> ProdutoDetalhe { get; set; }
        public DbSet<ProdutoImagem> ProdutoImagem { get; set; }
        public DbSet<Descricao> Descricao { get; set; }
        public DbSet<DescricaoSimilar> DescricaoSimilar { get; set; }

        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<EmpresaVinculo> EmpresaVinculo { get; set; }

        public DbSet<FichaCliente> FichaCliente { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FabricanteConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProdutoConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProdutoDetalheConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProdutoImagemConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DescricaoConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DescricaoSimilarConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EmpresaVinculoConfiguration).Assembly);
        }
    }

}
