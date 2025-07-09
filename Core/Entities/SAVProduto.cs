using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class SAVProduto : BaseEntity
    {
        public int savfabricanteid { get; set; }

        public string referencia { get; set; } = string.Empty;
        public string? codigobarra01 { get; set; } = string.Empty;
        public string? codigobarra02 { get; set; } = string.Empty;
        public string? descricao { get; set; } = string.Empty;
        public string? numero_original { get; set; } = string.Empty;
        public string? conversao { get; set; } = string.Empty;
        public string? numero_fabrica { get; set; } = string.Empty;

        public virtual List<SAVProdutoImagem>? imagens { get; set; } = [];
        public virtual List<SAVProdutoDetalhe>? savprodutodetalhe { get; set; } = [];
        public virtual List<SAVDescricaoSimilar>? savprodutosimilar { get; set; } = [];
    }
}
