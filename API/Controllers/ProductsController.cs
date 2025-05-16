using Core.Entities;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(StoreContext storeContext) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            return await storeContext.Products.ToListAsync();
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var obj = await storeContext.Products.FindAsync(id);


            if (obj == null) return NotFound();

            return obj;
        }


        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            storeContext.Products.Add(product);

            await storeContext.SaveChangesAsync();
            return product;
        }



        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await storeContext.Products.FindAsync(id);
            if (product == null) return NotFound();


            var obj = storeContext.Products.Remove(product);
            await storeContext.SaveChangesAsync();


            return NoContent();
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, Product product)
        {

            if (product == null) return NotFound();
            if (product.Id != id) return BadRequest();
            if (!ProductExist(id)) return NotFound();


            var obj = storeContext.Products.Update(product);
            await storeContext.SaveChangesAsync();




            return NoContent();
        }

        private bool ProductExist(int id)
        {
            return storeContext.Products.Any(p => p.Id == id);
        }

    }
}
