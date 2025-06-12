using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class SAVBuscaProduto(StoreContext storeContext) : ISAVBuscaProduto
    {
        public async Task<List<int>> BuscaProduto(string? pesquisar)
        {
            List<int> idProdutos = new List<int>();
            List<int> idSimilar = new List<int>();

            var query = storeContext.SAVProduto.AsQueryable();

            query = query.Where(
                p => p.referencia == pesquisar || p.numero_fabrica == pesquisar ||
                     p.codigobarra01 == pesquisar || p.codigobarra02 == pesquisar ||
                     p.numero_original == pesquisar || p.descricao.Contains(pesquisar)
            );


            idProdutos = await query.Select(x => x.Id).ToListAsync();




            var queryDescricaoSimilar = storeContext.SAVDescricaoSimilar.AsQueryable();

            queryDescricaoSimilar = queryDescricaoSimilar.Where(
                x => idProdutos.Contains(x.savprodutoid)
            );

            idSimilar = await queryDescricaoSimilar.Select(x => x.Id).ToListAsync();

            idProdutos.AddRange(idSimilar);

            return idProdutos;
        }


    }
}
