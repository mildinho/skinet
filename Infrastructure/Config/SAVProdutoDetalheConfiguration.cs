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
            builder.Property(x => x.savempresaid).IsRequired();
            builder.Property(x => x.savprodutoid).IsRequired();

            builder.Property(x => x.base_venda).HasColumnType("decimal(18,4)");
            builder.Property(x => x.base_atacado).HasColumnType("decimal(18,4)");
            builder.Property(x => x.base_oferta).HasColumnType("decimal(18,4)");
            builder.Property(x => x.saldo_disponivel).HasColumnType("decimal(18,4)");
            builder.Property(x => x.multiplo_venda).HasColumnType("decimal(18,4)");
            builder.Property(x => x.base_custo).HasColumnType("decimal(18,4)");
            builder.Property(x => x.base_medio).HasColumnType("decimal(18,4)");


            builder.HasIndex(x =>  new { x.savempresaid, x.savprodutoid}).IsUnique();
            builder.HasIndex(x => new { x.savprodutoid, x.savempresaid, }).IsUnique();

            builder.HasOne<SAVEmpresa>() // SAVProdutoDetalhe tem UMA Empresa
                   .WithMany()              // Empresa pode ter MUITOS SAVProdutoDetalhe (se não houver coleção em SAVEMPRESA)
                   .HasForeignKey(pd => pd.savempresaid) // A chave estrangeira em SAVProdutoDetalhe
                   .OnDelete(DeleteBehavior.Restrict);   // Comportamento ao deletar a empresa (Restringir é seguro)

        }
    }
}
