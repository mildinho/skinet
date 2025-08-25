using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class FabricanteSpecification : BaseSpecification<Fabricante>
    {
        public FabricanteSpecification(FabricanteSpecParams specParams) : base(x =>
        (
            specParams.Id.Contains(x.id) ||
            x.razao_social!.ToLower().Contains(specParams.Buscar) ||
            x.cnpj_cpf!.ToLower().Contains(specParams.Buscar) ||
            x.fantasia!.ToLower().Contains(specParams.Buscar)

        ))
        {

            ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);

            switch (specParams.Sort)
            {
                case "razao_social":
                    AddOrderBy(p => p.razao_social!);
                    break;
                case "cnpj_cpf":
                    AddOrderBy(p => p.cnpj_cpf!);
                    break;
                default:
                    AddOrderBy(p => p.fantasia!);
                    break;
            }
        }
    }

}
