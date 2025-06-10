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
    public class SAVProdutoConfiguration : IEntityTypeConfiguration<SAVProduto>
    {
        public void Configure(EntityTypeBuilder<SAVProduto> builder)
        {
            //builder.Property(x => x.Price).HasColumnType("decimal(18,4)");
            builder.HasIndex(x => x.referencia);
            builder.HasIndex(x => x.idparceiro);
            builder.HasIndex(x => x.numero_fabrica);
            builder.HasIndex(x => x.numero_original);
            builder.HasIndex(x => x.codigobarra01);
            builder.HasIndex(x => x.codigobarra02);
            builder.HasIndex(x => x.conversao);
        }
    }
}
