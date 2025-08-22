using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ProdutoDetalhe : BaseEntity
    {
        public int empresaid { get; set; }

        public int produtoid { get; set; }

        public string? unidade_medida { get; set; } = string.Empty;

        public string? ncm { get; set; } = string.Empty;

        public decimal? multiplo_venda { get; set; } = 0; 

        public decimal? base_venda { get; set; } = 0;
        public decimal? base_oferta { get; set; } = 0;
        public decimal? base_atacado { get; set; } = 0;
        public decimal? base_custo { get; set; } = 0;
        public decimal? base_medio { get; set; } = 0;

        public decimal? saldo_disponivel { get; set; } = 0;


        public decimal? estoque_minimo { get; set; } = 0;
        public decimal? estoque_maximo { get; set; } = 0;

    }
}
