namespace Core.Entities
{
    public class Parceiro : BaseEntity
    {
        public string? razao_social { get; set; } = string.Empty;
        public string? fantasia { get; set; } = string.Empty;
        public string? cnpj_cpf { get; set; } = string.Empty;

        // Collection of addresses for this partner
        public ICollection<ParceiroEndereco> Enderecos { get; set; } = new List<ParceiroEndereco>();
    }
}
