using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class SAVDescricaoSimilar : BaseEntity
    {
        [ForeignKey("SAVProduto")]
        public int savprodutoid { get; set; }



        [ForeignKey("SAVDescricao")]
        public int savdescricaoid { get; set; }



    }
}