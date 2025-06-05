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
    public class ProdutoSAVRepository(StoreContext storeContext) : IProdutoSAVRepository
    {



        public async Task<ProdutoSAV?> GetProductByIdAsync(int id)
        {
            return await storeContext.ProdutoSAV.FindAsync(id);
        }

        public async Task<IReadOnlyList<ProdutoSAV>> GetProductsAsync(string? pesquisar, string? fornecedor, string? sort)
        {

            var query = storeContext.ProdutoSAV.AsQueryable();

            query = query.Where(p => p.refx == pesquisar);
            query = query.Where(p => p.nrfabr == pesquisar);
            query = query.Where(p => p.cdbar == pesquisar);
            query = query.Where(p => p.cdbar2 == pesquisar);
            query = query.Where(p => p.descr.Contains(pesquisar));
            

            //query = sort switch
            //{
            //    "priceAsc" => query.OrderBy(p => p.Price),
            //    "priceDesc" => query.OrderByDescending(p => p.Price),
            //    _ => query.OrderByDescending(p => p.Name)
            //};


            return await query.ToListAsync();

        }




    }
}
