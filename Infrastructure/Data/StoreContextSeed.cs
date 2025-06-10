using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class StoreContextSeed
    {

        public static async Task SeedDataAsync(StoreContext context)
        {
            if (!context.Products.Any())
            {

                var produtcs = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/products.json");

                var productList = JsonSerializer.Deserialize<List<Product>>(produtcs);
                if (productList == null) return;

                context.Products.AddRange(productList);
                await context.SaveChangesAsync();
            }

            if (!context.SAVProduto.Any())
            {

                var produtcs = await File.ReadAllTextAsync("../Infrastructure/Data/SeedData/produto_sav.json");

                var productList = JsonSerializer.Deserialize<List<SAVProduto>>(produtcs);
                if (productList == null) return;

                context.SAVProduto.AddRange(productList);
                await context.SaveChangesAsync();
            }

            if (!context.SAVProdutoDetalhe.Any())
            {
                var product_base = context.SAVProduto.Select(p => p.Id).ToList();

                var produtcs = new List<SAVProdutoDetalhe>();

                foreach (var product in product_base)
                {
                    produtcs.Add(new SAVProdutoDetalhe
                    {
                        savempresaid = 1, // Assuming a default value for idempresa
                        savprodutoid = product,
                        base_venda = product,
                        base_oferta = product * 0.9m ,
                        base_atacado = product * 0.7m,
                        saldo_disponivel = product / 3.14m
                    });
                }

                if (produtcs == null) return;
                context.SAVProdutoDetalhe.AddRange(produtcs);
                await context.SaveChangesAsync();
            }



            //if (context.SAVProduto.Any())
            //{

            //    // Correcting the property name to match the type definition
            //    var xx = context.SAVProduto
            //        .Include(p => p.savprodutodetalhe) // Ensure the property name matches the type definition
            //        .Where(p => p.descr.Contains("LANT"))
            //        .ToList();

            //    Console.Write(xx);

            //}


        }
    }
}
