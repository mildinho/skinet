using Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.DTOs
{
    public class ProdutoDto
    {
        public string fabricante_interno { get; set; } = string.Empty;

        public string referencia { get; set; } = string.Empty;
        public string? codigobarra01 { get; set; } = string.Empty;
        public string? codigobarra02 { get; set; } = string.Empty;
        public string? descricao { get; set; } = string.Empty;
        public string? numero_original { get; set; } = string.Empty;
        public string? conversao { get; set; } = string.Empty;
        public string? numero_fabrica { get; set; } = string.Empty;

    }
}