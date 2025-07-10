using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specifications
{
    public class SAVProdutoSpecParams : PagingParams
    {
        private List<int> _fabricantes = new List<int>();
        private List<int> _id = new List<int>();
        
        private string _buscar = string.Empty;
        private bool _comSaldo = true;


        public List<int> Id
        {
            get => _id;
            set => _id = value.Select(b => b).ToList();
        }
       

        public List<int> Fabricantes
        {
            get => _fabricantes;
            set => _fabricantes = value;

            //set => _fabricantes = value.SelectMany(b => b.Split(',',
            // StringSplitOptions.RemoveEmptyEntries)).ToList();
        }

        public string? Sort { get; set; }

        public string Buscar
        {
            get => _buscar;
            set => _buscar = value.ToUpper();
        }

        public bool SomenteComSaldoDisponivel
        {
            get => _comSaldo;
            set => _comSaldo = value;
        }
       
      
    }
}
