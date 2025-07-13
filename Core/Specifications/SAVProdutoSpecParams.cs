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
          private List<int> _idEmpresaParceira = new List<int>();       //Lista de  ID da Empresa o Qual Deseja Consultar os Produtos;


        private List<int> _id = new List<int>();

        private string _buscar = string.Empty;


        public List<int> Id
        {
            get => _id;
            set => _id = value.Select(b => b).ToList();
        }

      
        public List<int> IDEmpresaParceira
        {
            get => _idEmpresaParceira;
            set => _idEmpresaParceira = value;
        }


        public List<int> FabricantesId
        {
            get => _fabricantes;
            set => _fabricantes = value;


        }

        public string? Sort { get; set; }

        public string Buscar
        {
            get => _buscar;
            set => _buscar = value.ToUpper();
        }




    }
}
