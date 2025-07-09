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
    public class SAVFabricanteConfiguration : IEntityTypeConfiguration<SAVFabricante>
    {
        public void Configure(EntityTypeBuilder<SAVFabricante> builder)
        {
            builder.HasIndex(x => x.cnpj_cpf);
            builder.HasIndex(x => x.codigo_interno);
        }
    }
}
