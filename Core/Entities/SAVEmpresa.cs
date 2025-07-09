using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class SAVEmpresa : BaseEntity
    {
        // Dados
        public string? razao_social { get; set; } = string.Empty;
        public string? fantasia { get; set; } = string.Empty;
        public string? cnpj_cpf { get; set; } = string.Empty;
        public string? inscricao_estadual { get; set; } = string.Empty;
        public string? inscricao_municipal { get; set; } = string.Empty;

        // Endereço
        public string? endereco { get; set; } = string.Empty;
        public string? numero { get; set; } = string.Empty;
        public string? complemento { get; set; } = string.Empty;
        public string? bairro { get; set; } = string.Empty;
        public string? cidade { get; set; } = string.Empty;
        public string? uf { get; set; } = string.Empty;
        public string? cep { get; set; } = string.Empty;
        public string? telefone { get; set; } = string.Empty;

    }
}
