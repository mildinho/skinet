﻿using System;
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

            ( specParams.Id.Contains(x.id)) ||
            ( specParams.FabricantesId.Contains(x.fabricanteid))
        )
        {
            //Incluindo os Similares
            Includes.Add(x => x.produtosimilar);

            //Incluindo as Imagens
            Includes.Add(x => x.imagens);

            // Incluindo os Detalhes do Produto
            Includes.Add(x => x.produtodetalhe.
                Where(d => specParams.IDEmpresaParceira.Contains(d.empresaid)));
          

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







       // public SAVProdutoSpecification(SAVProdutoSpecParams specParams) : base(
       //x =>

       //      (string.IsNullOrEmpty(specParams.Search) || x.referencia == specParams.Search.ToUpper()) ||
       //      (string.IsNullOrEmpty(specParams.Search) || x.numero_fabrica == specParams.Search.ToUpper()) ||
       //      (string.IsNullOrEmpty(specParams.Search) || x.codigobarra01 == specParams.Search) ||
       //      (string.IsNullOrEmpty(specParams.Search) || x.codigobarra02 == specParams.Search) ||
       //      (string.IsNullOrEmpty(specParams.Search) || x.numero_original == specParams.Search) ||
       //      (string.IsNullOrEmpty(specParams.Search) || x.descricao.Contains(specParams.Search)) &&

       //    (specParams.Fabricantes.Count == 0 || specParams.Fabricantes.Contains(x.idparceiro)) &&

       //    (specParams.InStock == false || x.savprodutodetalhe != null && x.savprodutodetalhe.Any(d => d.saldo_disponivel > 0))

       //)
       // {

       //     Includes.Add(x => x.savprodutosimilar);


       //     Includes.Add(x => x.savprodutodetalhe);
       //     Includes.Add(x => x.imagens);

       //     ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize);

       //     switch (specParams.Sort)
       //     {
       //         case "fabricanteAsc":
       //             AddOrderBy(p => p.idparceiro);
       //             break;
       //         case "fabricanteDesc":
       //             AddOrderByDescending(p => p.idparceiro);
       //             break;
       //         default:
       //             AddOrderBy(p => p.referencia);
       //             break;
       //     }
       // }

    }

}
