using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class SAVBuscaProdutoController(IGenericRepository<SAVProduto> genericRepository, 
        ISAVBuscaProduto buscaProduto) : BaseAPIController
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<SAVProduto>>> BuscaProdutos(
           [FromQuery] SAVProdutoSpecParams specParams)
        {
            if (specParams == null) return BadRequest("Os Parametros NÃO PODEM Ser Nulo");

       
            if ((specParams.Id == null || specParams.Id.Count <= 0) &&
               ( string.IsNullOrEmpty(specParams.Buscar)  || specParams.Buscar.Length < 3))
                return BadRequest("Informe no Minimo 3 Digitos para Buscar");

            if ((specParams.Id == null || specParams.Id.Count == 0) &&
              string.IsNullOrEmpty(specParams.Buscar))
                return BadRequest("Informe ao menos um ID de Produto para Buscar");


            List<int> ids = new List<int>();
            if ( specParams.Buscar != null && specParams.Buscar.Length >= 3)
            {
               ids = await buscaProduto.BuscaProduto(specParams.Buscar);
            }
            

            foreach (var item in ids)
            {
                specParams.Id.Add(item);
            }

            if (specParams.Id.Count == 0)
            {
                return BadRequest("Nenhum Produto Encontrado");
            }

            specParams.Buscar = string.Empty; // Clear search term since we're using IDs now


            var spec = new SAVProdutoSpecification(specParams);


            return await CreatePagedResult(genericRepository, spec, specParams.PageIndex, specParams.PageSize);
        }


    }
}
