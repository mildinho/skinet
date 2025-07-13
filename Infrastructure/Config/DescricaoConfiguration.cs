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
    public class DescricaoConfiguration : IEntityTypeConfiguration<Descricao>
    {
        public void Configure(EntityTypeBuilder<Descricao> builder)
        {


            builder.HasIndex(x => x.descricao);

        }
    }
}
