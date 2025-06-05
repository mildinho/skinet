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
    public class ProdutoSAVConfiguration : IEntityTypeConfiguration<ProdutoSAV>
    {
        public void Configure(EntityTypeBuilder<ProdutoSAV> builder)
        {
            //builder.Property(x => x.Price).HasColumnType("decimal(18,4)");
            builder.HasIndex(x => x.refx);
            builder.HasIndex(x => x.idparceiro);
            builder.HasIndex(x => x.nrfabr);
            builder.HasIndex(x => x.nrorig);
        }
    }
}
