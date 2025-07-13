using API.DTOs;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController(StoreContext context) : Controller
    {

        [HttpPost("Produto")]
        public async Task<ActionResult> CriaProduto(List<ProdutoDto> dados)
        {

            // CADASTRO DO FABRICANTE
            List<Fabricante> fabricantes = context.Fabricante.ToList();

            if (fabricantes.Count == 0)
            {
                return BadRequest("Não Encontrado FABRICANTE na SAVFABRICANTE");
            }


            // LISTA DE PRODUTOS PARA CARREGAR
            if (dados == null || dados.Count == 0)
            {
                return BadRequest("Dados não podem ser nulos ou vazios");
            }


            // DETALHES DOS PRODUTOS
            List<Produto> produto_novo = new();
            List<Produto> produto_atualizar = new();


            for (int i = 0; i < dados.Count; i++)
            {
                var item = dados[i];



                if (string.IsNullOrEmpty(item.fabricante_interno))
                {
                    return BadRequest("O Fabricante do produto não pode ser nula ou vazia");
                }

                if (string.IsNullOrEmpty(item.referencia))
                {
                    return BadRequest("A referência do produto não pode ser nula ou vazia");
                }


                var produto = context.Produto.AsNoTracking().FirstOrDefault(p => p.referencia == item.referencia);

                var detalhe = new Produto
                {
                    savfabricanteid = fabricantes.FirstOrDefault(f => f.codigo_interno == item.fabricante_interno)?.id ?? 0,
                    referencia = item.referencia,
                    codigobarra01 = item.codigobarra01,
                    codigobarra02 = item.codigobarra02,
                    descricao = item.descricao,
                    numero_original = item.numero_original,
                    conversao = item.conversao,
                    numero_fabrica = item.numero_fabrica
                };

                if (detalhe.savfabricanteid <= 0)
                {
                    continue; // Ignora o produto se o fabricante não for encontrado
                    //return BadRequest("O ID do Fabricante deve ser maior que zero");
                }

                if (produto is not null)
                {
                    detalhe.id = produto.id; // Mantém o ID do detalhe existente
                    produto_atualizar.Add(detalhe);
                }
                else   // ADICIONA NOVO DETALHE
                {
                    produto_novo.Add(detalhe);
                }



            }

            //ADICIONAR NOVOS PRODUTOS
            if (produto_novo.Count > 0)
                context.Produto.AddRange(produto_novo);

            //ATUALIZAR NOVOS PRODUTOS
            if (produto_atualizar.Count > 0)
                context.Produto.UpdateRange(produto_atualizar);


            if (await context.SaveChangesAsync() > 0)
            {
                return Ok("Produtos Atualizado com Sucesso");
            }
            else
            {
                return BadRequest("Falha na Atualização dos Produtos");
            }

        }


        [HttpPost("ProdutoDetalhe")]
        public async Task<ActionResult> CriaProdutoDetalhe(List<ProdutoDetalheDto> dados)
        {

            // CADASTRO DO PRODUTO
            List<Produto> produtos = context.Produto.ToList();

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
            List<ProdutoDetalhe> produto_detalhe_novo = new();
            List<ProdutoDetalhe> produto_detalhe_atualizar = new();


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

                    var detalhe = new ProdutoDetalhe
                    {
                        empresaid = item.savempresaid,
                        produtoid = item.savprodutoid,
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

                    var dados_detalhe = await context.ProdutoDetalhe.AsNoTracking().
                        Where(x => x.empresaid == item.savempresaid &&
                                    x.produtoid == item.savprodutoid).FirstOrDefaultAsync();

                    // ATUALIZA DETALHE EXISTENTE
                    if (dados_detalhe is not null)
                    {

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
            if (produto_detalhe_novo.Count > 0)
                context.ProdutoDetalhe.AddRange(produto_detalhe_novo);

            //ATUALIZAR NOVOS PRODUTOS
            if (produto_detalhe_atualizar.Count > 0)
                context.ProdutoDetalhe.UpdateRange(produto_detalhe_atualizar);


            if (await context.SaveChangesAsync() > 0)
            {
                return Ok("Detalhe de Produtos Atualizado com Sucesso");
            }
            else
            {
                return BadRequest("Falha na Antualização no Detalhe dos Produtos");
            }

        }



        [HttpPost("AtualizarSimilarPorDescricao")]
        public async Task<ActionResult> Atualizar_SimilarPorDescricao()
        {
            var produto_base = context.Produto.Select(p => new { p.id, p.descricao }).ToList();
            var descricao_base = context.Descricao.ToList();

            context.Database.ExecuteSqlRaw("DELETE FROM SAVDescricaoSimilar");
            await context.SaveChangesAsync();

            var descricao_similar_novo = new List<DescricaoSimilar>();

            foreach (var produto in produto_base)
            {

                descricao_similar_novo.Add(new DescricaoSimilar
                {
                    produtoid = produto.id,
                    savdescricaoid = descricao_base.FirstOrDefault(d => d.descricao == produto.descricao)?.id ?? 0
                });
            }

            if (descricao_similar_novo.Count > 0)
            {
                await context.DescricaoSimilar.AddRangeAsync(descricao_similar_novo);

                if (await context.SaveChangesAsync() > 0)
                    return Ok("Similar por Descrição Atualizado com Sucesso");
                else
                    return BadRequest("Falha na Atualizacao de Similar por Descrição");
            }
            else
                return Ok("Não Houve Atualização de Registros");

        }
    }
}
