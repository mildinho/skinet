using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class ProductSpecParams : PagingParams
    {
        private List<string> _brands = new List<string>();
        private List<string> _types = new List<string>();
        private string? _search;

        public List<string> Brands
        {
            get => _brands;
            set => _brands = value.SelectMany(b => b.Split(',',
                StringSplitOptions.RemoveEmptyEntries)).ToList();
        }

        public List<string> Types
        {
            get => _types;
            set => _types = value.SelectMany(t => t.Split(',',
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
