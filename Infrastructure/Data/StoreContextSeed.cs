using System.Text.Json;
using Core.Entities;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {

        public static async Task SeedDataAsync(StoreContext context)
        {

            // CADASTRANDO PRODUTO
            if (!context.Products.Any())
            {

                var produtcs = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/products.json");

                var productList = JsonSerializer.Deserialize<List<Product>>(produtcs);
                if (productList == null) return;

                context.Products.AddRange(productList);
                await context.SaveChangesAsync();
            }



            // CADASTRANDO PRODUTO
            if (!context.SAVProduto.Any())
            {

                var produtcs = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/produto_sav.json");

                var productList = JsonSerializer.Deserialize<List<SAVProduto>>(produtcs);
                if (productList == null) return;

                context.SAVProduto.AddRange(productList);
                await context.SaveChangesAsync();
            }




            // CADASTRANDO DESCRICAO UNICA DO PRODUTO
            if (!context.SAVDescricao.Any())
            {
                var product_descricao = context.SAVProduto.Where(x => x.idparceiro != "0000000400").
                    Select(p => p.descricao).Distinct().ToList();

                var descricao = new List<SAVDescricao>();

                foreach (var desc in product_descricao)
                {
                    descricao.Add(new SAVDescricao
                    {
                        descricao = desc

                    });
                }

                if (descricao == null) return;

                context.SAVDescricao.AddRange(descricao);
                await context.SaveChangesAsync();
            }





            // CADASTRANDO IMAGENS
            if (!context.SAVProdutoImagem.Any())
            {
                var product_base = context.SAVProduto.Select(p => new { p.Id, p.referencia }).ToList();
                var images = new List<SAVProdutoImagem>();

                foreach (var product in product_base)
                {


                    images.Add(new SAVProdutoImagem
                    {
                        savprodutoid = product.Id,
                        filename = product.referencia,
                        url = "https://www.furacao.com.br/imagensfuracao/produtosfw/"
                    });
                }

                if (images == null) return;


                context.SAVProdutoImagem.AddRange(images);
                await context.SaveChangesAsync();
            }


            // CADASTRANDO DESCRICAO SIMILAR
            if (!context.SAVDescricaoSimilar.Any())
            {
                var product_base = context.SAVProduto.Where( X=> X.idparceiro != "0000000400").
                    Select(p => new { p.Id, p.descricao }).ToList();
                var descricao_base = context.SAVDescricao.ToList();


                var descricao_similar = new List<SAVDescricaoSimilar>();
                foreach (var product in product_base)
                {
                    descricao_similar.Add(new SAVDescricaoSimilar
                    {
                        savprodutoid = product.Id,
                        savdescricaoid = descricao_base.FirstOrDefault(d => d.descricao == product.descricao)?.Id ?? 0
                    });
                }
                if (descricao_similar == null) return;
                context.SAVDescricaoSimilar.AddRange(descricao_similar);
                await context.SaveChangesAsync();
            }





            // CADASTRANDO DETALHES DOS PRODUTOS
            if (!context.SAVProdutoDetalhe.Any())
            {
                var product_base = context.SAVProduto.Select(p => new { p.Id, p.referencia }).ToList();

                var details = new List<SAVProdutoDetalhe>();
      
                foreach (var product in product_base)
                {
                    details.Add(new SAVProdutoDetalhe
                    {
                        savempresaid = 1, // Assuming a default value for idempresa
                        savprodutoid = product.Id,
                        base_venda = product.Id,
                        base_oferta = product.Id * 0.9m,
                        base_atacado = product.Id * 0.7m,
                        saldo_disponivel = product.Id / 3.14m
                    });


                }

                if (details == null) return;

                //detalhes
                context.SAVProdutoDetalhe.AddRange(details);

                await context.SaveChangesAsync();
            }




        }
    }
}
