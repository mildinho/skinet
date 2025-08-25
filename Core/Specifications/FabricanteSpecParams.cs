using System.Runtime.CompilerServices;

namespace Core.Specifications
{
    public class FabricanteSpecParams : PagingParams
    {
        
        private List<int> _id = new List<int>();

        private string _buscar = string.Empty;


        public FabricanteSpecParams()
        {
                this.MaxPageSize = 100;
        }


        public List<int> Id
        {
            get => _id;
            set => _id = value.Select(b => b).ToList();
        }


        public string? Sort { get; set; }

        public string Buscar
        {
            get => _buscar;
            set => _buscar = value.ToUpper();
        }




    }
}
