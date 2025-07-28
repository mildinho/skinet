using Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DTOs
{
    public class ProdutoDto
    {
        public int id { get; set; }
        public int fabricanteid { get; set; }

        public string referencia { get; set; } = string.Empty;
        public string? codigobarra01 { get; set; } = string.Empty;
        public string? codigobarra02 { get; set; } = string.Empty;
        public string? descricao { get; set; } = string.Empty;
        public string? numero_original { get; set; } = string.Empty;
        public string? conversao { get; set; } = string.Empty;
        public string? numero_fabrica { get; set; } = string.Empty;



        public static implicit operator Produto(ProdutoDto dto)
        {
            return new Produto
            {
                id= 0, // Assuming the ID is auto-generated;
                fabricanteid = dto.fabricanteid,
                referencia = dto.referencia,
                codigobarra01 = dto.codigobarra01,
                codigobarra02 = dto.codigobarra02,
                descricao = dto.descricao,
                numero_original = dto.numero_original,
                conversao = dto.conversao,
                numero_fabrica = dto.numero_fabrica,
            };
        }
    }
}