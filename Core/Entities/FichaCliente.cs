using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class FichaCliente : BaseEntity
    {
     
        public string? Razao_Nome { get; set; } = string.Empty;
        public string? Fantasia { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public string? Telefone { get; set; } = string.Empty;
        public string? Celular { get; set; }
        public string? CNPJ_CPF { get; set; }
        public string? Endereco { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Estado { get; set; }
        public string? CEP { get; set; }


        // DADOS DE COBRANÇA
        public string? Endereco_Cobranca { get; set; }
        public string? Numero_Cobranca { get; set; }
        public string? Complemento_Cobranca { get; set; }
        public string? Bairro_Cobranca { get; set; }
        public string? Cidade_Cobranca { get; set; }
        public string? Estado_Cobranca { get; set; }
        public string? CEP_Cobranca { get; set; }



        // DADOS DE ENREGA
        public string? Endereco_Entrega { get; set; }
        public string? Numero_Entrega { get; set; }
        public string? Complemento_Entrega { get; set; }
        public string? Bairro_Entrega { get; set; }
        public string? Cidade_Entrega { get; set; }
        public string? Estado_Entrega { get; set; }
        public string? CEP_Entrega { get; set; }
    }
}
