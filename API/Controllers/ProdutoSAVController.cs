using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class ProdutoSAVController(IGenericRepository<ProdutoSAV> produtoSAVRepository) : BaseAPIController
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProdutoSAV>>> GetProducts(
            [FromQuery] ProdutoSAVSpecParams specParams)
        {
            var spec = new ProdutoSAVSpecification(specParams);



            return await CreatePagedResult(produtoSAVRepository, spec, specParams.PageIndex, specParams.PageSize);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProdutoSAV>> GetProduct(int id)
        {
            var obj = await produtoSAVRepository.GetByIdAsync(id);


            if (obj == null) return NotFound();

            return obj;
        }




    }
}
