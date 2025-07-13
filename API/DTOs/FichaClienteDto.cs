using Core.Entities;

namespace API.DTOs
{
    public class FichaClienteDto
    {
        public int id { get; set; }
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


        public static implicit operator FichaCliente(FichaClienteDto dto)
        {
            return new FichaCliente
            {
                id = dto.id,
                Razao_Nome = dto.Razao_Nome,
                Fantasia = dto.Fantasia,
                Email = dto.Email,
                Telefone = dto.Telefone,
                Celular = dto.Celular,
                CNPJ_CPF = dto.CNPJ_CPF,
                Endereco = dto.Endereco,
                Numero = dto.Numero,
                Complemento = dto.Complemento,
                Bairro = dto.Bairro,
                Cidade = dto.Cidade,
                Estado = dto.Estado,
                CEP = dto.CEP,
                Endereco_Cobranca = dto.Endereco_Cobranca,
                Numero_Cobranca = dto.Numero_Cobranca,
                Complemento_Cobranca = dto.Complemento_Cobranca,
                Bairro_Cobranca = dto.Bairro_Cobranca,
                Cidade_Cobranca = dto.Cidade_Cobranca,
                Estado_Cobranca = dto.Estado_Cobranca,
                CEP_Cobranca = dto.CEP_Cobranca,
                Endereco_Entrega = dto.Endereco_Entrega,
                Numero_Entrega = dto.Numero_Entrega,
                Complemento_Entrega = dto.Complemento_Entrega,
                Bairro_Entrega = dto.Bairro_Entrega,
                Cidade_Entrega = dto.Cidade_Entrega,
                Estado_Entrega = dto.Estado_Entrega,
                CEP_Entrega = dto.CEP_Entrega
            };
        }

        public static implicit operator FichaClienteDto(FichaCliente entity)
        {
            return new FichaClienteDto
            {
                id = entity.id,
                Razao_Nome = entity.Razao_Nome,
                Fantasia = entity.Fantasia,
                Email = entity.Email,
                Telefone = entity.Telefone,
                Celular = entity.Celular,
                CNPJ_CPF = entity.CNPJ_CPF,
                Endereco = entity.Endereco,
                Numero = entity.Numero,
                Complemento = entity.Complemento,
                Bairro = entity.Bairro,
                Cidade = entity.Cidade,
                Estado = entity.Estado,
                CEP = entity.CEP,
                Endereco_Cobranca = entity.Endereco_Cobranca,
                Numero_Cobranca = entity.Numero_Cobranca,
                Complemento_Cobranca = entity.Complemento_Cobranca,
                Bairro_Cobranca = entity.Bairro_Cobranca,
                Cidade_Cobranca = entity.Cidade_Cobranca,
                Estado_Cobranca = entity.Estado_Cobranca,
                CEP_Cobranca = entity.CEP_Cobranca,
                Endereco_Entrega = entity.Endereco_Entrega,
                Numero_Entrega = entity.Numero_Entrega,
                Complemento_Entrega = entity.Complemento_Entrega,
                Bairro_Entrega = entity.Bairro_Entrega,
                Cidade_Entrega = entity.Cidade_Entrega,
                Estado_Entrega = entity.Estado_Entrega,
                CEP_Entrega = entity.CEP_Entrega
            };
        }
    }
}
