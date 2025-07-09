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

        public DbSet<SAVFabricante> SAVFabricante { get; set; }

        public DbSet<SAVProduto> SAVProduto { get; set; }
        public DbSet<SAVProdutoDetalhe> SAVProdutoDetalhe { get; set; }
        public DbSet<SAVProdutoImagem> SAVProdutoImagem { get; set; }
        public DbSet<SAVDescricao> SAVDescricao { get; set; }
        public DbSet<SAVDescricaoSimilar> SAVDescricaoSimilar { get; set; }

        public DbSet<SAVEmpresa> SAVEmpresa { get; set; }
        public DbSet<SAVEmpresaVinculo> SAVEmpresaVinculo { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);


            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SAVFabricanteConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SAVProdutoConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SAVProdutoDetalheConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SAVProdutoImagemConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SAVDescricaoConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SAVDescricaoSimilarConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SAVEmpresaVinculoConfiguration).Assembly);
        }
    }

}
