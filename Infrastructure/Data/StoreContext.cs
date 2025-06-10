using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Infrastructure.Config;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContext(DbContextOptions options) : DbContext(options)
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<SAVProduto> SAVProduto { get; set; }
        public DbSet<SAVProdutoDetalhe> SAVProdutoDetalhe { get; set; }
        public DbSet<SAVProdutoImagem> SAVProdutoImagem { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SAVProdutoConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SAVProdutoDetalheConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SAVProdutoImagemConfiguration).Assembly);
        }
    }

}
