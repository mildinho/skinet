using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class ProdutoSAVSpecification : BaseSpecification<ProdutoSAV>
    {
        public ProdutoSAVSpecification(ProdutoSAVSpecParams specParams) : base(x =>
         (string.IsNullOrEmpty(specParams.Search) || x.refx == specParams.Search.ToUpper()) ||
         (string.IsNullOrEmpty(specParams.Search) || x.nrfabr == specParams.Search.ToUpper()) ||
         (string.IsNullOrEmpty(specParams.Search) || x.cdbar == specParams.Search) ||
         (string.IsNullOrEmpty(specParams.Search) || x.cdbar2 == specParams.Search) ||
         (string.IsNullOrEmpty(specParams.Search) || x.descr.Contains(specParams.Search)) &&
        (specParams.Fornecedores.Count == 0 || specParams.Fornecedores.Contains(x.idparceiro))
        )


        {

            ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);

            //switch (specParams.Sort)
            //{
            //    case "priceAsc":
            //        AddOrderBy(p => p.Price);
            //        break;
            //    case "priceDesc":
            //        AddOrderByDescending(p => p.Price);
            //        break;
            //    default:
            //        AddOrderBy(p => p.refx);
            //        break;
            //}
        }
    }

}
