using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface ISAVProdutoRepository
    {
        Task<IReadOnlyList<SAVProduto>> GetProductsAsync( string? pesquisar, string? fornecedor, string? sort);
        Task<SAVProduto?> GetProductByIdAsync(int id);
       
    }
}
