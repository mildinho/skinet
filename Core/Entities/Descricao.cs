using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Descricao : BaseEntity
    {
        public string descricao { get; set; } = string.Empty;

    }
}