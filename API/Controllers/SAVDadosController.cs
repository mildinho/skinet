using API.DTOs;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SAVDadosController(StoreContext context) : Controller
    {


        [HttpPost("ProdutoDetalhe")]
        public async Task<ActionResult> CriaProdutoDetalhe(List<ProdutoDetalheDto> dados)
        {

            // CADASTRO DO PRODUTO
            List<SAVProduto> produtos = context.SAVProduto.ToList();

            if (produtos.Count == 0)
            {
                return BadRequest("Não Encontrado Produtos na SAVPRODUTOS");
            }


            // LISTA DE PRODUTOS PARA CARREGAR
            if (dados == null || dados.Count == 0)
            {
                return BadRequest("Dados não podem ser nulos ou vazios");
            }


            // DETALHES DOS PRODUTOS
            List<SAVProdutoDetalhe> produto_detalhe_novo = new();
            List<SAVProdutoDetalhe> produto_detalhe_atualizar = new();


            for (int i = 0; i < dados.Count; i++)
            {
                var item = dados[i];

                if (item.savempresaid <= 0)
                {
                    return BadRequest("O ID da Empresa deve ser maior que zero");
                }

                if (string.IsNullOrEmpty(item.referencia))
                {
                    return BadRequest("A referência do produto não pode ser nula ou vazia");
                }


                var produto = produtos.FirstOrDefault(p => p.referencia == item.referencia);

                if (produto is not null)
                {

                    dados[i].savprodutoid = produto.id; // Associa o ID do produto ao detalhe

                    var detalhe = new SAVProdutoDetalhe
                    {
                        savempresaid = item.savempresaid,
                        savprodutoid = item.savprodutoid,
                        unidade_medida = item.unidade_medida,
                        ncm = item.ncm,
                        multiplo_venda = item.multiplo_venda,
                        base_venda = item.base_venda,
                        base_oferta = item.base_oferta,
                        base_atacado = item.base_atacado,
                        base_custo = item.base_custo,
                        base_medio = item.base_medio,
                        saldo_disponivel = item.saldo_disponivel
                    };

                    var dados_detalhe = await context.SAVProdutoDetalhe.AsNoTracking().
                        Where( x => x.savempresaid == item.savempresaid && 
                                    x.savprodutoid == item.savprodutoid).FirstOrDefaultAsync();

                    // ATUALIZA DETALHE EXISTENTE
                    if (dados_detalhe is not null ) {
                        
                        detalhe.id = dados_detalhe.id; // Mantém o ID do detalhe existente
                        produto_detalhe_atualizar.Add(detalhe);
                    }
                    else   // ADICIONA NOVO DETALHE
                    {
                        produto_detalhe_novo.Add(detalhe);
                    }
                    
                    
                }
            }

            //ADICIONAR NOVOS PRODUTOS
            if( produto_detalhe_novo.Count > 0)
                context.SAVProdutoDetalhe.AddRange(produto_detalhe_novo);

            //ATUALIZAR NOVOS PRODUTOS
            if (produto_detalhe_atualizar.Count > 0)
                context.SAVProdutoDetalhe.UpdateRange(produto_detalhe_atualizar);


            if (await context.SaveChangesAsync() > 0)
            {
                return Ok("Detalhe de Produtos Atualizado com Sucesso");
            }
            else
            {
                return BadRequest("Falha na Antualização no Detalhe dos Produtos");
            }

        }




    }
}
