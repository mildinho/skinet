using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class BuscaProdutoController(IGenericRepository<Produto> genericRepository,
        ISAVBuscaProduto buscaProduto, IUnitOfWork unitow) : BaseAPIController
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Produto>>> BuscaProdutos(
           [FromQuery] SAVProdutoSpecParams specParams)
        {
            if (specParams == null) return BadRequest("Os Parametros NÃO PODEM Ser Nulo");

            if (specParams.IdEmpresaParceira == null || specParams.IdEmpresaParceira.Count <= 0)
                return BadRequest("Deve Informar a Empresa Parceira");

            List<int> ids = new List<int>();
            if (!string.IsNullOrEmpty(specParams.Buscar))
            {
                ids = await buscaProduto.BuscaProduto(specParams.Buscar);
            }


            foreach (var item in ids)
            {
                specParams.Id.Add(item.ToString());
            }

            if (specParams.Id.Count == 0)
            {
                return BadRequest("Nenhum Produto Encontrado");
            }

            specParams.Buscar = string.Empty; // Clear search term since we're using IDs now


            var spec = new SAVProdutoSpecification(specParams);


            return await CreatePagedResult(genericRepository, spec, specParams.PageIndex, specParams.PageSize);
        }


        [HttpGet("Fabricante")]
        public async Task<ActionResult<IReadOnlyList<FabricanteDto>>> GetFabricante(
             [FromQuery] FabricanteSpecParams specParams)
        {
            var spec = new FabricanteSpecification(specParams);

            return await CreatePagedResult_DTO<Fabricante, FabricanteDto>
                (unitow.Repository<Fabricante>(), spec, specParams.PageIndex, specParams.PageSize);

        }


    }



}
