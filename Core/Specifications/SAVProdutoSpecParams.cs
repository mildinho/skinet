namespace Core.Specifications
{
    public class SAVProdutoSpecParams : PagingParams
    {
        private List<string> _fabricantes = new List<string>();
        private List<string> _idEmpresaParceira = new List<string>();       //Lista de  ID da Empresa o Qual Deseja Consultar os Produtos;
        private List<string> _id = new List<string>();

        private string _buscar = string.Empty;


        public List<string> Id
        {
            get => _id;
            set => _id = value.SelectMany(b => b.Split(',',
                StringSplitOptions.RemoveEmptyEntries)).ToList();
        }


        public List<string> IdEmpresaParceira
        {
            get => _idEmpresaParceira;
            set => _idEmpresaParceira = value.SelectMany(b => b.Split(',',
                StringSplitOptions.RemoveEmptyEntries)).ToList();
        }


        public List<string> IdFabricante
        {
            get => _fabricantes;
            set => _fabricantes = value.SelectMany(b => b.Split(',',
                StringSplitOptions.RemoveEmptyEntries)).ToList();


        }

        public string? Sort { get; set; }

        public string Buscar
        {
            get => _buscar;
            set => _buscar = value.ToUpper() ?? "";
        }




    }
}
