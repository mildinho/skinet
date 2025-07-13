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
    public class DescricaoSimilarConfiguration : IEntityTypeConfiguration<DescricaoSimilar>
    {
        public void Configure(EntityTypeBuilder<DescricaoSimilar> builder)
        {

            builder.HasIndex(x => x.produtoid);
            builder.HasIndex(x => x.savdescricaoid);

        }
    }
}
