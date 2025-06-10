using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class SAVProdutoController(IGenericRepository<SAVProduto> produtoSAVRepository) : BaseAPIController
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<SAVProduto>>> GetProducts(
            [FromQuery] SAVProdutoSpecParams specParams)
        {
            var spec = new SAVProdutoSpecification(specParams);



            return await CreatePagedResult(produtoSAVRepository, spec, specParams.PageIndex, specParams.PageSize);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult<SAVProduto>> GetProduct(int id)
        {
            var obj = await produtoSAVRepository.GetByIdAsync(id);


            if (obj == null) return NotFound();

            return obj;
        }




    }
}
