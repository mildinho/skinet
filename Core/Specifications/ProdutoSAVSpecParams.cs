using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProdutoSAVSpecParams : PagingParams
    {
        private List<string> _fornecedores = new List<string>();
        private string? _search;



        public List<string> Fornecedores
        {
            get => _fornecedores;
            set => _fornecedores = value.SelectMany(b => b.Split(',',
                StringSplitOptions.RemoveEmptyEntries)).ToList();
        }

        public string? Sort { get; set; }

        public string Search
        {
            get => _search ?? "";
            set => _search = value.ToLower();
        }

    }
}
