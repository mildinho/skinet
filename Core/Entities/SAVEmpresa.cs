using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class SAVEmpresa : BaseEntity
    {
        
        public string? razao_social { get; set; } = string.Empty;
        public string? fantasia { get; set; } = string.Empty;
        public string? cnpj { get; set; } = string.Empty;
        public string? inscricao_estadual { get; set; } = string.Empty;
    }
}
