namespace Core.Entities
{
    public class FichaCliente : BaseEntity
    {

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








    }
}
