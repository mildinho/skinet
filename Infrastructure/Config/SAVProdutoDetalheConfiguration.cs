using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class SAVProdutoDetalheConfiguration : IEntityTypeConfiguration<SAVProdutoDetalhe>
    {
        public void Configure(EntityTypeBuilder<SAVProdutoDetalhe> builder)
        {
            builder.Property(x => x.base_venda).HasColumnType("decimal(18,4)");
            builder.Property(x => x.base_atacado).HasColumnType("decimal(18,4)");
            builder.Property(x => x.base_oferta).HasColumnType("decimal(18,4)");
            builder.Property(x => x.saldo_disponivel).HasColumnType("decimal(18,4)");


            builder.HasIndex(x =>  new { x.savempresaid, x.savprodutoid});
            
        }
    }
}
