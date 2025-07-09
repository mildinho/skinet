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





            // CADASTRANDO FABRICANTE
            if (!context.SAVFabricante.Any())
            {

                var objeto = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/fabricante_sav.json");

                var objetoLista = JsonSerializer.Deserialize<List<SAVFabricante>>(objeto);
                if (objetoLista == null) return;

                context.SAVFabricante.AddRange(objetoLista);
                await context.SaveChangesAsync();
            }


            // CADASTRANDO DA EMPRESA
            if (!context.SAVEmpresa.Any())
            {
                List<SAVEmpresa> empresaList =[];

                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - SOCORRO",
                    cnpj_cpf = "08897417000100",
                    uf = "SP",
                });

                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - CAMPINAS",
                    cnpj_cpf = "08897417000291",
                    uf = "SP",
                });

                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - CAMPO GRANDE",
                    cnpj_cpf = "08897417000372",
                    uf = "MS",
                });


                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - RECIFE",
                    cnpj_cpf = "08897417000453",
                    uf = "PE",
                });

                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - RIO DE JANEIRO",
                    cnpj_cpf = "08897417000534",
                    uf = "RJ",
                });

                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - PORTO ALEGRE",
                    cnpj_cpf = "08897417000615",
                    uf = "RS",
                });


                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - ITAJAI",
                    cnpj_cpf = "08897417000704",
                    uf = "SC",
                });


                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - GOIANIA",
                    cnpj_cpf = "08897417000887",
                    uf = "GO",
                });


                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - CURITIBA",
                    cnpj_cpf = "08897417000968",
                    uf = "PR",
                });

                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - SALVADOR",
                    cnpj_cpf = "08897417001000",
                    uf = "BA",
                });


                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - CUIABA",
                    cnpj_cpf = "08897417001182",
                    uf = "MT",
                });

                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - VITORIA",
                    cnpj_cpf = "08897417001263",
                    uf = "ES",
                });


                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - FORTALEZA",
                    cnpj_cpf = "08897417001344",
                    uf = "CE",
                });


                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - BELEM",
                    cnpj_cpf = "08897417001425",
                    uf = "PA",
                });

                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - MANAUS",
                    cnpj_cpf = "08897417001697",
                    uf = "AM",
                });


                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - BELO HORIZONTE",
                    cnpj_cpf = "08897417001778",
                    uf = "MG",
                });


                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - UBERLANDIA",
                    cnpj_cpf = "08897417001859",
                    uf = "MG",
                });


                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - SANTO ANDRE",
                    cnpj_cpf = "08897417001930",
                    uf = "SP",
                });

                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - BAURU",
                    cnpj_cpf = "08897417002073",
                    uf = "SP",
                });

                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - NOVO MUNDO",
                    cnpj_cpf = "08897417002154",
                    uf = "SP",
                });

                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - OSASCO",
                    cnpj_cpf = "08897417002316",
                    uf = "SP",
                });

                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - RIBEIRAO PRETO",
                    cnpj_cpf = "08897417002405",
                    uf = "SP",
                });

                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - MARINGA",
                    cnpj_cpf = "08897417002588",
                    uf = "PR",
                });

                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - SAO JOSE RIO PRETO",
                    cnpj_cpf = "08897417002669",
                    uf = "SP",
                });

                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - SAO JOSE DOS CAMPOS",
                    cnpj_cpf = "08897417002740",
                    uf = "SP",
                });

                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - SAO LUIS",
                    cnpj_cpf = "08897417002820",
                    uf = "MA",
                });

                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - CAMBUCI",
                    cnpj_cpf = "08897417002901",
                    uf = "SP",
                });

                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - PRESIDENTE PRUDENTE",
                    cnpj_cpf = "08897417003045",
                    uf = "SP",
                });


                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - NATAL",
                    cnpj_cpf = "08897417003126",
                    uf = "RN",
                });


                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - VITORIA DA CONQUISTA",
                    cnpj_cpf = "08897417003398",
                    uf = "BA",
                });


                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - PIRACICABA",
                    cnpj_cpf = "08897417003550",
                    uf = "SP",
                });

                empresaList.Add(new SAVEmpresa
                {
                    razao_social = "FW DISTRIBUIDORA LTDA",
                    fantasia = "FW - SOROCABA",
                    cnpj_cpf = "08897417003630",
                    uf = "SP",
                });


                context.SAVEmpresa.AddRange(empresaList);
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
                var product_descricao = context.SAVProduto.Select(p => p.descricao).Distinct().ToList();

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
                var product_base = context.SAVProduto.Select(p => new { p.id, p.referencia }).ToList();
                var images = new List<SAVProdutoImagem>();

                foreach (var product in product_base)
                {


                    images.Add(new SAVProdutoImagem
                    {
                        savprodutoid = product.id,
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
                var product_base = context.SAVProduto.Select(p => new { p.id, p.descricao }).ToList();
                var descricao_base = context.SAVDescricao.ToList();


                var descricao_similar = new List<SAVDescricaoSimilar>();
                foreach (var product in product_base)
                {
                    descricao_similar.Add(new SAVDescricaoSimilar
                    {
                        savprodutoid = product.id,
                        savdescricaoid = descricao_base.FirstOrDefault(d => d.descricao == product.descricao)?.id ?? 0
                    });
                }
                if (descricao_similar == null) return;
                context.SAVDescricaoSimilar.AddRange(descricao_similar);
                await context.SaveChangesAsync();
            }






        }
    }
}
