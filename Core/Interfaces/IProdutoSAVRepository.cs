using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProdutoSAVRepository
    {
        Task<IReadOnlyList<ProdutoSAV>> GetProductsAsync( string? pesquisar, string? fornecedor, string? sort);
        Task<ProdutoSAV?> GetProductByIdAsync(int id);
       
    }
}
