using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Specifications
{
    public class SAVProdutoSpecification : BaseSpecification<SAVProduto>
    {
        public SAVProdutoSpecification(SAVProdutoSpecParams specParams) : base(x =>
         (string.IsNullOrEmpty(specParams.Search) || x.referencia == specParams.Search.ToUpper()) ||
         (string.IsNullOrEmpty(specParams.Search) || x.numero_fabrica == specParams.Search.ToUpper()) ||
         (string.IsNullOrEmpty(specParams.Search) || x.codigobarra01 == specParams.Search) ||
         (string.IsNullOrEmpty(specParams.Search) || x.codigobarra02 == specParams.Search) ||
         (string.IsNullOrEmpty(specParams.Search) || x.numero_original == specParams.Search) ||
         (string.IsNullOrEmpty(specParams.Search) || x.descricao.Contains(specParams.Search)) &&
        (specParams.Fornecedores.Count == 0 || specParams.Fornecedores.Contains(x.idparceiro))
        )
        {
            // Inclui o relacionamento com SAVProdutoDetalhe
            Includes.Add(x => x.savprodutodetalhe);
            Includes.Add(x => x.imagens);


            ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);

            switch (specParams.Sort)
            {
                case "fabricanteAsc":
                    AddOrderBy(p => p.idparceiro);
                    break;
                case "fabricanteDesc":
                    AddOrderByDescending(p => p.idparceiro);
                    break;
                default:
                    AddOrderBy(p => p.referencia);
                    break;
            }
        }
    }

}
