namespace Core.Entities
{
    public class ParceiroEndereco : BaseEntity
    {

        public int ParceiroId { get; set; }

        public string? endereco { get; set; } = string.Empty;
        public string? numero { get; set; } = string.Empty;
        public string? complemento { get; set; } = string.Empty;
        public string? bairro { get; set; } = string.Empty;
        public string? cidade { get; set; } = string.Empty;
        public string? estado { get; set; } = string.Empty;
        public string? cep { get; set; } = string.Empty;
        public string? pais { get; set; } = string.Empty;

        // Type of address
        public EnderecoTipo Tipo { get; set; }
    }

    public enum EnderecoTipo
    {
        Comercial,
        Entrega,
        Cobranca,
        Residencial,
        Outro
    }
}
