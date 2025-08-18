using API.DTOs;
using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController(StoreContext context) : Controller
    {

        [HttpPost("FabricanteArquivo")]
        public async Task<IActionResult> CriaFabricanteArquivo(IFormFile formFile)
        {
            if (formFile.Length > 0)
            {
                var filePath = Path.GetTempFileName();

                using (var stream = System.IO.File.Create(filePath))
                {
                    await formFile.CopyToAsync(stream);
                    stream.Close();

                    var fabricantes = await System.IO.File.ReadAllTextAsync(stream.Name);

                    System.IO.File.Delete(filePath); // Deleta o arquivo temporário após o uso

                    var fabricantesList = JsonSerializer.Deserialize<List<FabricanteDto>>(fabricantes);
                    if (fabricantesList == null) return BadRequest("Erro de Conversao de Arquivo ");

                    Boolean conversaOK = await AtualizaFabricante(fabricantesList);

                    if (conversaOK)
                        return Ok("Fabricantes Atualizado com Sucesso");

                    return BadRequest("Falha na Atualização dos Fabricantes");
                }
            }

            return NoContent();
        }


        [HttpPost("Fabricante")]
        public async Task<ActionResult> CriaFabricante(List<FabricanteDto> dados)
        {
            if (dados == null || dados.Count == 0)
                return BadRequest("Dados não podem ser nulos ou vazios");

            Boolean conversaOK = await AtualizaFabricante(dados);

            if (conversaOK)
                return Ok("Fabricantes Atualizado com Sucesso");

            return BadRequest("Falha na Atualização dos Fabricantes");

        }


        [HttpDelete("FabricanteExcluir")]
        public async Task<ActionResult> ExcluirFabricante(List<int> dados)
        {
            if (dados == null || dados.Count == 0)
                return BadRequest("Dados não podem ser nulos ou vazios");

            for (int i = 0; i < dados.Count; i++)
            {
                var item = dados[i];
                if (item <= 0)
                    continue; // Ignora itens inválidos na lista

                Fabricante? fabricante = await context.Fabricante.FindAsync(item);
                if (fabricante is not null)
                {
                    context.Fabricante.Remove(fabricante);
                }
            }

            if (await context.SaveChangesAsync() > 0)
                return Ok("Fabricante Excluido com Sucesso");

            return BadRequest("Falha na Exclusao dos Fabricantes");

        }




        private async Task<bool> AtualizaFabricante(List<FabricanteDto> dados)
        {
            if (dados == null || dados.Count == 0)
                return false;

            List<Fabricante> fabricante_novo = new();
            List<Fabricante> fabricante_atualizar = new();


            for (int i = 0; i < dados.Count; i++)
            {

                var item = dados[i];
                if (item == null || (item.id == 0 && string.IsNullOrEmpty(item.id_legado)))
                    continue; // Ignora itens nulos na lista


                Fabricante? fabricante = null!;

                if (item.id > 0)
                    fabricante = await context.Fabricante.AsNoTracking().FirstOrDefaultAsync(p => p.id == item.id);
                else
                    fabricante = await context.Fabricante.AsNoTracking().FirstOrDefaultAsync(p => p.id_legado == item.id_legado);

                Fabricante objeto = item;

                if (fabricante is not null)
                {
                    objeto.id = fabricante.id;
                    fabricante_atualizar.Add(objeto);
                }
                else
                    fabricante_novo.Add(objeto);


            }

            if (fabricante_novo.Count > 0)
                context.Fabricante.AddRange(fabricante_novo);

            if (fabricante_atualizar.Count > 0)
                context.Fabricante.UpdateRange(fabricante_atualizar);


            if (await context.SaveChangesAsync() > 0)
                return true;
            return false;

        }



        [HttpPost("ProdutoArquivo")]
        public async Task<IActionResult> CriaProdutoArquivo(IFormFile formFile)
        {


            if (formFile.Length > 0)
            {
                var filePath = Path.GetTempFileName();

                using (var stream = System.IO.File.Create(filePath))
                {
                    await formFile.CopyToAsync(stream);
                    stream.Close();

                    var produtcs = await System.IO.File.ReadAllTextAsync(stream.Name);

                    System.IO.File.Delete(filePath); // Deleta o arquivo temporário após o uso

                    var productList = JsonSerializer.Deserialize<List<ProdutoDto>>(produtcs);
                    if (productList == null) return BadRequest("Erro de Conversao de Arquivo ");

                    Boolean conversaOK = await AtualizaProduto(productList);

                    if (conversaOK)
                        return Ok("Produtos Atualizado com Sucesso");

                    return BadRequest("Falha na Atualização dos Produtos");

                }
            }

            return NoContent();
        }


        [HttpPost("Produto")]
        public async Task<ActionResult> CriaProduto(List<ProdutoDto> dados)
        {
            if (dados == null || dados.Count == 0)
                return BadRequest("Dados não podem ser nulos ou vazios");

            Boolean conversaOK = await AtualizaProduto(dados);

            if (conversaOK)
                return Ok("Fabricantes Atualizado com Sucesso");

            return BadRequest("Falha na Atualização dos Fabricantes");

        }

        [HttpDelete("ProdutoExcluir")]
        public async Task<ActionResult> ExcluirProduto(List<int> dados)
        {
            if (dados == null || dados.Count == 0)
                return BadRequest("Dados não podem ser nulos ou vazios");

            for (int i = 0; i < dados.Count; i++)
            {
                var item = dados[i];
                if (item <= 0)
                    continue; // Ignora itens inválidos na lista

                Produto? produto = await context.Produto.FindAsync(item);
                if (produto is not null)
                {
                    context.Produto.Remove(produto);
                }
            }

            if (await context.SaveChangesAsync() > 0)
                return Ok("Produto Excluido com Sucesso");

            return BadRequest("Falha na Exclusao do Produto");

        }


        private async Task<bool> AtualizaProduto(List<ProdutoDto> dados)
        {
            if (dados == null || dados.Count == 0)
                return false;

            // DETALHES DOS PRODUTOS
            List<Produto> produto_novo = new();
            List<Produto> produto_atualizar = new();


            for (int i = 0; i < dados.Count; i++)
            {
                var item = dados[i];

                if (item == null || item.fabricanteid == 0 || string.IsNullOrEmpty(item.referencia))
                    continue; // Ignora itens nulos na lista

                Produto? produto = null!;

                if (item.id > 0)
                    produto = await context.Produto.AsNoTracking().FirstOrDefaultAsync(p => p.id == item.id);
                else
                    produto = context.Produto.AsNoTracking().FirstOrDefault(p => p.referencia == item.referencia);

                Produto objeto = item;

                if (produto is not null)
                {
                    objeto.id = produto.id; // Mantém o ID do detalhe existente
                    produto_atualizar.Add(objeto);
                }
                else
                    produto_novo.Add(objeto);
            }

            if (produto_novo.Count > 0)
                context.Produto.AddRange(produto_novo);

            if (produto_atualizar.Count > 0)
                context.Produto.UpdateRange(produto_atualizar);


            if (await context.SaveChangesAsync() > 0)
                return true;
            return false;

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


        [HttpPut("AtualizarDescricao")]
        public async Task<ActionResult> Atualizar_Descricao()
        {
            context.Database.ExecuteSqlRaw("DELETE FROM Descricao");
            await context.SaveChangesAsync();

            var product_descricao = context.Produto.Select(p => p.descricao).Distinct().ToList();

            var descricao = new List<Descricao>();

            foreach (var desc in product_descricao)
            {
                if (string.IsNullOrEmpty(desc))
                    continue; // Ignora descrições vazias   

                descricao.Add(new Descricao
                {
                    descricao = desc

                });
            }

            if (descricao.Count > 0)
            {
                await context.Descricao.AddRangeAsync(descricao);

                if (await context.SaveChangesAsync() > 0)
                    return Ok("Cadastro de Descrição Atualizado com Sucesso");
                else
                    return BadRequest("Falha na Atualizacao de Descrição");
            }
            else
                return Ok("Não Houve Atualização de Registros");


        }


        [HttpPut("AtualizarSimilarPorDescricao")]
        public async Task<ActionResult> Atualizar_SimilarPorDescricao()
        {
            var produto_base = context.Produto.Select(p => new { p.id, p.descricao }).ToList();
            var descricao_base = context.Descricao.ToList();

            context.Database.ExecuteSqlRaw("DELETE FROM DescricaoSimilar");
            await context.SaveChangesAsync();

            var descricao_similar_novo = new List<DescricaoSimilar>();

            foreach (var produto in produto_base)
            {

                descricao_similar_novo.Add(new DescricaoSimilar
                {
                    produtoid = produto.id,
                    descricaoid = descricao_base.FirstOrDefault(d => d.descricao == produto.descricao)?.id ?? 0
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
