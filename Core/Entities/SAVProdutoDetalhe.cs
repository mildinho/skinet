using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class SAVProdutoDetalhe : BaseEntity
    {
        [ForeignKey("SAVEmpresa")]
        public int savempresaid { get; set; }

        [ForeignKey("SAVProduto")]
        public int savprodutoid { get; set; }



        public decimal base_venda { get; set; } = 0;
        public decimal base_oferta { get; set; } = 0;
        public decimal base_atacado { get; set; } = 0;
        public decimal saldo_disponivel { get; set; } = 0;



    }
}
