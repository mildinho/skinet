namespace Core.Entities
{
    public class Fabricante : BaseEntity
    {
        public string id_legado { get; set; } = string.Empty;
        public string? razao_social { get; set; } = string.Empty;
        public string? fantasia { get; set; } = string.Empty;
        public string? cnpj_cpf { get; set; } = string.Empty;
    }
}
