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
    public class ProdutoImagemConfiguration : IEntityTypeConfiguration<ProdutoImagem>
    {
        public void Configure(EntityTypeBuilder<ProdutoImagem> builder)
        {


            builder.HasIndex(x => x.produtoid);

        }
    }
}
