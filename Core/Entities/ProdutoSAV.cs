using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ProdutoSAV : BaseEntity
    {
        public string? idparceiro { get; set; } = string.Empty;
        public string? refx { get; set; } = string.Empty;
        public string? cdbar { get; set; } = string.Empty;
        public string? cdbar2 { get; set; } = string.Empty;
        public string? descr { get; set; } = string.Empty;
        public string? nrorig { get; set; } = string.Empty;
        public string? conversao { get; set; } = string.Empty;
        public string? nrfabr { get; set; } = string.Empty;
    }
}
