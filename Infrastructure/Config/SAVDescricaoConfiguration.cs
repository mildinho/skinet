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
    public class SAVDescricaoConfiguration : IEntityTypeConfiguration<SAVDescricao>
    {
        public void Configure(EntityTypeBuilder<SAVDescricao> builder)
        {


            builder.HasIndex(x => x.descricao);

        }
    }
}
