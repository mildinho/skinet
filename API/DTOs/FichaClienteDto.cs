using Core.Entities;

namespace API.DTOs
{
    public class FichaClienteDto
    {
        public int id { get; set; }
        public string? Razao_Nome { get; set; } = string.Empty;
        public string? Fantasia { get; set; } = string.Empty;
        public string? Telefone { get; set; } = string.Empty;
        public string? Celular { get; set; } = string.Empty;
        public string? CNPJ_CPF { get; set; } = string.Empty;
        public string? Inscricao_Estadual { get; set; } = string.Empty;
        public string? Endereco { get; set; } = string.Empty;
        public string? Numero { get; set; } = string.Empty;
        public string? Complemento { get; set; } = string.Empty;
        public string? Bairro { get; set; } = string.Empty;
        public string? Cidade { get; set; } = string.Empty;
        public string? Estado { get; set; } = string.Empty;
        public string? CEP { get; set; } = string.Empty;
        public string? email { get; set; } = string.Empty;
        public string? email_nfe { get; set; } = string.Empty;


        // DADOS DE COBRANÇA
        public string? Endereco_Cobranca { get; set; } = string.Empty;
        public string? Numero_Cobranca { get; set; } = string.Empty;
        public string? Complemento_Cobranca { get; set; } = string.Empty;
        public string? Bairro_Cobranca { get; set; } = string.Empty;
        public string? Cidade_Cobranca { get; set; } = string.Empty;
        public string? Estado_Cobranca { get; set; } = string.Empty;
        public string? CEP_Cobranca { get; set; } = string.Empty;



        // DADOS DE ENREGA
        public string? Endereco_Entrega { get; set; } = string.Empty;
        public string? Numero_Entrega { get; set; } = string.Empty;
        public string? Complemento_Entrega { get; set; } = string.Empty;
        public string? Bairro_Entrega { get; set; } = string.Empty;
        public string? Cidade_Entrega { get; set; } = string.Empty;
        public string? Estado_Entrega { get; set; } = string.Empty;
        public string? CEP_Entrega { get; set; } = string.Empty;

        public Boolean Isento { get; set; } = false;
        public Boolean Simples_Nacional { get; set; } = false;
        public Boolean Consumidor_Final { get; set; } = false;

        // DADOS ADICIONAIS ( INFORMACAO LIVRE )
        public string? Dados_Adicional { get; set; } = string.Empty;


        // DADOS DO COMPRADOR
        public string? Nome_Comprador { get; set; } = string.Empty;
        public DateOnly? Nascimento_Comprador { get; set; }
        public string? Telefone_Comprador { get; set; } = string.Empty;
        public string? Celular_Comprador { get; set; } = string.Empty;


        public static implicit operator FichaCliente(FichaClienteDto dto)
        {
            return new FichaCliente
            {
                id = dto.id,
                Razao_Nome = dto.Razao_Nome,
                Fantasia = dto.Fantasia,
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
                CEP_Entrega = dto.CEP_Entrega,
                Celular_Comprador = dto.Celular_Comprador,
                Telefone_Comprador = dto.Telefone_Comprador,
                Nome_Comprador = dto.Nome_Comprador,
                Nascimento_Comprador = dto.Nascimento_Comprador,
                Isento = dto.Isento,
                Simples_Nacional = dto.Simples_Nacional,
                Consumidor_Final = dto.Consumidor_Final,
                Dados_Adicional = dto.Dados_Adicional,
                email = dto.email,
                email_nfe = dto.email_nfe,
                Inscricao_Estadual = dto.Inscricao_Estadual

            };
        }

        public static implicit operator FichaClienteDto(FichaCliente entity)
        {
            return new FichaClienteDto
            {
                id = entity.id,
                Razao_Nome = entity.Razao_Nome,
                Fantasia = entity.Fantasia,
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
                CEP_Entrega = entity.CEP_Entrega,
                Celular_Comprador = entity.Celular_Comprador,
                Telefone_Comprador = entity.Telefone_Comprador,
                Nome_Comprador = entity.Nome_Comprador,
                Nascimento_Comprador = entity.Nascimento_Comprador,
                Isento = entity.Isento,
                Simples_Nacional = entity.Simples_Nacional,
                Consumidor_Final = entity.Consumidor_Final,
                Dados_Adicional = entity.Dados_Adicional,
                email = entity.email,
                email_nfe = entity.email_nfe,
                Inscricao_Estadual = entity.Inscricao_Estadual

            };
        }
    }
}
