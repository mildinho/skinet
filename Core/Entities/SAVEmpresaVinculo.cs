using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class SAVEmpresaVinculo : BaseEntity
    {
        [ForeignKey("SAVEmpresa")]
        public int origemid { get; set; }



        [ForeignKey("SAVDescricao")]
        public int destinoid { get; set; }



    }
}