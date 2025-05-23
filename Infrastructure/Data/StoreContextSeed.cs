using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Core.Entities;

namespace Infrastructure.Data
{
    public  class StoreContextSeed
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
        }
    }
}
