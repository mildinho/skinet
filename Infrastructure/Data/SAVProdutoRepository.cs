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
    public class SAVProdutoRepository(StoreContext storeContext) : ISAVProdutoRepository
    {



        public async Task<SAVProduto?> GetProductByIdAsync(int id)
        {
            return await storeContext.SAVProduto.FindAsync(id);
        }

        public async Task<IReadOnlyList<SAVProduto>> GetProductsAsync(string? pesquisar, string? fornecedor, string? sort)
        {

            var query = storeContext.SAVProduto.AsQueryable();

            query = query.Where(p => p.referencia == pesquisar);
            query = query.Where(p => p.numero_fabrica == pesquisar);
            query = query.Where(p => p.codigobarra01 == pesquisar);
            query = query.Where(p => p.codigobarra02 == pesquisar);
            query = query.Where(p => p.descricao.Contains(pesquisar));


            query = sort switch
            {
                "fabricanteAsc" => query.OrderBy(p => p.idparceiro),
                "fabricanteDesc" => query.OrderByDescending(p => p.idparceiro),
                _ => query.OrderByDescending(p => p.referencia)
            };


            return await query.ToListAsync();

        }




    }
}
