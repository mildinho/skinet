using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class SAVDescricao : BaseEntity
    {
        public string descricao { get; set; } = string.Empty;

    }
}