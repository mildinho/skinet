using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class SAVProdutoSpecification : BaseSpecification<Produto>
    {
        public SAVProdutoSpecification(SAVProdutoSpecParams specParams) : base(
        x =>
            ( specParams.Id.Contains(x.id.ToString())) ||

            ( specParams.IdFabricante.Contains(x.fabricanteid.ToString()))
        )
        {
            //Incluindo os Similares
            Includes.Add(x => x.produtosimilar);

            //Incluindo as Imagens
            Includes.Add(x => x.imagens);

            // Incluindo os Detalhes do Produto
            Includes.Add(x => x.produtodetalhe.
                Where(d => specParams.IdEmpresaParceira.Contains(d.empresaid.ToString())));
          

            ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);

            switch (specParams.Sort)
            {
                case "fabricanteAsc":
                    AddOrderBy(p => p.fabricanteid);
                    break;
                case "fabricanteDesc":
                    AddOrderByDescending(p => p.fabricanteid);
                    break;
                default:
                    AddOrderBy(p => p.referencia);
                    break;
            }
        }


    }

}
