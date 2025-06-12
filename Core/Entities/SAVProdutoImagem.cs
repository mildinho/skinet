using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class SAVProdutoImagem : BaseEntity
    {
       
        [ForeignKey("SAVProduto")]
        public int savprodutoid { get; set; }

        public string? filename { get; set; } = string.Empty;
        public string? url { get; set; } = string.Empty;
       
    }
}