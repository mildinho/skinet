using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class SAVProdutoImagem : BaseEntity
    {
       
        [ForeignKey("SAVProduto")]
        public int savprodutoid { get; set; }

        public string? imagem { get; set; } = string.Empty;
       
    }
}