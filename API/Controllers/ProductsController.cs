using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController(IGenericRepository<Product> productRepository) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts(string? brand, string? type, string? sort)
        {
            var spec = new ProductSpecification(brand, type, sort);

            var products = await productRepository.ListAsync(spec);

            return Ok(products);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var obj = await productRepository.GetByIdAsync(id);


            if (obj == null) return NotFound();

            return obj;
        }


        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            productRepository.Add(product);

            if (await productRepository.SaveChangesAsync())
            {
                return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
            }
            else
            {
                return BadRequest("Failed to create product");
            }

        }



        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await productRepository.GetByIdAsync(id);
            if (product == null) return NotFound();


            productRepository.Remove(product);
            if (await productRepository.SaveChangesAsync())
            {
                return NoContent();
            }
            else
            {
                return BadRequest("Failed to delete product");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Product>> UpdateProduct(int id, Product product)
        {

            if (product == null) return NotFound();
            if (product.Id != id) return BadRequest();
            if (!ProductExist(id)) return NotFound();


            productRepository.Update(product);
            if (await productRepository.SaveChangesAsync())
            {
                return NoContent();
            }
            else
            {
                return BadRequest("Failed to update product");
            }


        }


        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetBrands()
        {
            var spec = new BrandListSpecification();
            return Ok(await productRepository.ListAsync(spec));
        }


        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetTypes()
        {
            var spec = new TypeListSpecification();
            return Ok(await productRepository.ListAsync(spec));
        }

        private bool ProductExist(int id)
        {
            return productRepository.Exists(id);
        }

    }
}
