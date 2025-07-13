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
    public class ProdutoDetalheConfiguration : IEntityTypeConfiguration<ProdutoDetalhe>
    {
        public void Configure(EntityTypeBuilder<ProdutoDetalhe> builder)
        {
            builder.Property(x => x.empresaid).IsRequired();
            builder.Property(x => x.produtoid).IsRequired();

            builder.Property(x => x.base_venda).HasColumnType("decimal(18,4)");
            builder.Property(x => x.base_atacado).HasColumnType("decimal(18,4)");
            builder.Property(x => x.base_oferta).HasColumnType("decimal(18,4)");
            builder.Property(x => x.saldo_disponivel).HasColumnType("decimal(18,4)");
            builder.Property(x => x.multiplo_venda).HasColumnType("decimal(18,4)");
            builder.Property(x => x.base_custo).HasColumnType("decimal(18,4)");
            builder.Property(x => x.base_medio).HasColumnType("decimal(18,4)");


            builder.HasIndex(x =>  new { x.empresaid, x.produtoid}).IsUnique();
            builder.HasIndex(x => new { x.produtoid, x.empresaid, }).IsUnique();

            builder.HasOne<Empresa>() // SAVProdutoDetalhe tem UMA Empresa
                   .WithMany()              // Empresa pode ter MUITOS SAVProdutoDetalhe (se não houver coleção em SAVEMPRESA)
                   .HasForeignKey(pd => pd.empresaid) // A chave estrangeira em SAVProdutoDetalhe
                   .OnDelete(DeleteBehavior.Restrict);   // Comportamento ao deletar a empresa (Restringir é seguro)

        }
    }
}
