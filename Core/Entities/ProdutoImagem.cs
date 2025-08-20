using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class ProdutoImagem : BaseEntity
    {

        [ForeignKey("Produto")]
        public int produtoid { get; set; }

        public string? filename { get; set; } = string.Empty;
        public string? url { get; set; } = string.Empty;
       
    }
}