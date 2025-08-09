using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class DescricaoSimilar : BaseEntity
    {
        [ForeignKey("Produto")]
        public int produtoid { get; set; }



        [ForeignKey("Descricao")]
        public int descricaoid { get; set; }



    }
}