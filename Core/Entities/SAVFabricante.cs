using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class SAVFabricante : BaseEntity
    {
        public string codigo_interno { get; set; } = string.Empty;
        public string? razao_social { get; set; } = string.Empty;
        public string? fantasia { get; set; } = string.Empty;
        public string? cnpj_cpf { get; set; } = string.Empty;
    }
}
