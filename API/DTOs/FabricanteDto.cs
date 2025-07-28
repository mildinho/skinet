using API.DTOs;

namespace Core.Entities
{
    public class FabricanteDto
    {
        public int id { get; set; }
        public string? id_legado { get; set; } = string.Empty;
        public string? razao_social { get; set; } = string.Empty;
        public string? fantasia { get; set; } = string.Empty;
        public string? cnpj_cpf { get; set; } = string.Empty;


        public static implicit operator Fabricante(FabricanteDto dto)
        {
            return new Fabricante
            {
                id = dto.id,
                id_legado = dto.id_legado,
                razao_social = dto.razao_social,
                fantasia = dto.fantasia,
                cnpj_cpf = dto.cnpj_cpf
            };
        }


        public static implicit operator FabricanteDto(Fabricante entity)
        {
            return new FabricanteDto
            {
                id = entity.id,
                id_legado = entity.id_legado,
                razao_social = entity.razao_social,
                fantasia = entity.fantasia,
                cnpj_cpf = entity.cnpj_cpf


            };
        }
    }
}
