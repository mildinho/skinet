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

            // FILTRO PRINCIPAL DO PRODUTO
            query = query.Where(
                p => p.referencia.StartsWith(pesquisar) || p.numero_fabrica.StartsWith(pesquisar) ||
                     p.codigobarra01 == pesquisar || p.codigobarra02 == pesquisar ||
                     p.numero_original == pesquisar || p.descricao.Contains(pesquisar)
            );

            idProdutos = await query.Select(x => x.id).ToListAsync();




            // FILTRO POR SIMILARES - DESCRIÇÃO
            var queryDescricaoSimilar = storeContext.SAVDescricaoSimilar.AsQueryable();

            queryDescricaoSimilar = queryDescricaoSimilar.Where(
                x => idProdutos.Contains(x.savprodutoid)
            );

            idSimilar = await queryDescricaoSimilar.Select(x => x.savdescricaoid).ToListAsync();

            queryDescricaoSimilar = queryDescricaoSimilar.Where(
                x => idSimilar.Contains(x.savdescricaoid)
            );

            idSimilar = await queryDescricaoSimilar.Select(x => x.savprodutoid).ToListAsync();





            // JUNTANDO OS RESULTADOS
            idProdutos.AddRange(idSimilar);


            // CRIANDO A LISTA FINAL
            idProdutos = idProdutos.Distinct().ToList();

            return idProdutos;
        }


    }
}
