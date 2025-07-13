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
    public class EmpresaVinculoConfiguration : IEntityTypeConfiguration<EmpresaVinculo>
    {
        public void Configure(EntityTypeBuilder<EmpresaVinculo> builder)
        {

            builder.HasIndex(x => x.origemid);
            builder.HasIndex(x => x.origemid);

        }
    }
}
