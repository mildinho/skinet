using System.Runtime.InteropServices;
using API.DTOs;
using API.RequestHelpers;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseAPIController : Controller
    {
        protected async Task<ActionResult> CreatePagedResult<T>(IGenericRepository<T> repo,
          ISpecification<T> spec, int pageIndex, int pageSize) where T : BaseEntity
        {
            var items = await repo.ListAsync(spec);
            var count = await repo.CountAsync(spec);

            var pagination = new Pagination<T>(pageIndex, pageSize, count, items);

            return Ok(pagination);
        }


        protected async Task<ActionResult> CreatePagedResult_DTO<T, T_DTO>(
            IGenericRepository<T> repo, 
            ISpecification<T> spec, 
            int pageIndex, int pageSize) 
                where T : BaseEntity 
                where T_DTO : class, new()

        {
            var items = await repo.ListAsync(spec);
            var count = await repo.CountAsync(spec);

            var dtoItems = items.Select(item =>
            {
                var dto = new T_DTO();

                // Encontra o método FromEntity no tipo T_DTO
                var fromEntityMethod = typeof(T_DTO).GetMethod("FromEntity");

                if (fromEntityMethod != null)
                {
                    // Invoca o método FromEntity no objeto DTO, passando o item da entidade
                    dto = (T_DTO)fromEntityMethod.Invoke(null, new object[] { item })!;
                 
                }

                return dto;
            }).ToList();

            var pagination = new Pagination<T_DTO>(pageIndex, pageSize, count, dtoItems);


            return Ok(pagination);
        }


    }
}
