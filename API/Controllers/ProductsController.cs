using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class ProductsController(IUnitOfWork unitow) : BaseAPIController
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Product>>> GetProducts(
            [FromQuery] ProductSpecParams specParams)
        {
            var spec = new ProductSpecification(specParams);



            return await CreatePagedResult(unitow.Repository<Product>(), spec, specParams.PageIndex, specParams.PageSize);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var obj = await unitow.Repository<Product>().GetByIdAsync(id);


            if (obj == null) return NotFound();

            return obj;
        }


        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            unitow.Repository<Product>().Add(product);

            if (await unitow.Complete())
            {
                return CreatedAtAction(nameof(GetProduct), new { id = product.id }, product);
            }
            else
            {
                return BadRequest("Failed to create product");
            }

        }



        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await unitow.Repository<Product>().GetByIdAsync(id);
            if (product == null) return NotFound();


            unitow.Repository<Product>().Remove(product);
            if (await unitow.Complete())
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
            if (product.id != id) return BadRequest();
            if (!ProductExist(id)) return NotFound();


            unitow.Repository<Product>().Update(product);
            if (await unitow.Complete())
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
            return Ok(await unitow.Repository<Product>().ListAsync(spec));
        }


        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<string>>> GetTypes()
        {
            var spec = new TypeListSpecification();
            return Ok(await unitow.Repository<Product>().ListAsync(spec));
        }

        private bool ProductExist(int id)
        {
            return unitow.Repository<Product>().Exists(id);
        }

    }
}
