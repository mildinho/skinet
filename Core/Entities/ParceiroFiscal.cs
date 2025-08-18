namespace Core.Entities
{
    public class ParceiroFiscal : BaseEntity
    {

        public int ParceiroId { get; set; }

        public int consumidorfinal { get; set; } = 0;
        public int contribuiteicms { get; set; } = 0;
        public int simplesnacional { get; set; } = 0;
        public string? inscricaoestadual { get; set; } = string.Empty;
        public string? inscricaomunicipal { get; set; } = string.Empty;
        public string? cnaeprincipal { get; set; } = string.Empty;


    }

}
