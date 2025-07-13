using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasIndex(x => x.referencia);
            builder.HasIndex(x => x.savfabricanteid);
            builder.HasIndex(x => x.numero_fabrica);
            builder.HasIndex(x => x.numero_original);
            builder.HasIndex(x => x.codigobarra01);
            builder.HasIndex(x => x.codigobarra02);
            builder.HasIndex(x => x.conversao);


            builder.HasIndex(x => new { x.savfabricanteid, x.id }).IsUnique();


            builder.HasOne<Fabricante>() // SAVProdutoDetalhe tem UMA Empresa
                   .WithMany()              // Empresa pode ter MUITOS SAVProdutoDetalhe (se não houver coleção em SAVEMPRESA)
                   .HasForeignKey(pd => pd.savfabricanteid) // A chave estrangeira em SAVProdutoDetalhe
                   .OnDelete(DeleteBehavior.Restrict);   // Comportamento ao deletar a empresa (Restringir é seguro)

        }
    }
}
