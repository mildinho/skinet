using Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DTOs
{
    public class ProdutoDetalheDto
    {
        public int savempresaid { get; set; }
        public int savprodutoid { get; set; }

        public string referencia { get; set; } = string.Empty;

        public string? unidade_medida { get; set; } = string.Empty;

        public string? ncm { get; set; } = string.Empty;

        public decimal? multiplo_venda { get; set; } = 0;

        public decimal? base_venda { get; set; } = 0;
        public decimal? base_oferta { get; set; } = 0;
        public decimal? base_atacado { get; set; } = 0;
        public decimal? base_custo { get; set; } = 0;
        public decimal? base_medio { get; set; } = 0;

        public decimal? saldo_disponivel { get; set; } = 0;

    }
}