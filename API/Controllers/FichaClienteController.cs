using API.DTOs;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class FichaClienteController(IGenericRepository<FichaCliente> repository, 
        ILogger<FichaClienteController> logger) : BaseAPIController
    {

        [HttpGet("{id:int}")]
        public async Task<ActionResult<FichaClienteDto>> GetById(int id)
        {
            logger.LogInformation("Solicitação para obter previsão do tempo recebida.");

            var obj = await repository.GetByIdAsync(id);
            if (obj == null) return NotFound();

            FichaClienteDto objDto = obj;

            return objDto;
        }


        [HttpPost]
        public async Task<ActionResult<FichaClienteDto>> Create(FichaClienteDto objDto)
        {
            FichaCliente fichaCliente = objDto;
            repository.Add(fichaCliente);

            if (await repository.SaveChangesAsync())
            {
                return CreatedAtAction(nameof(GetById), new { id = objDto.id }, objDto);
            }
            else
            {
                return BadRequest("Falha ao Criar Ficha");
            }

        }



        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var fichaCliente = await repository.GetByIdAsync(id);
            if (fichaCliente == null) return NotFound();


            repository.Remove(fichaCliente);
            if (await repository.SaveChangesAsync())
            {
                return NoContent();
            }
            else
            {
                return BadRequest("Falha ao Excluir Ficha");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<FichaClienteDto>> UpdateProduct(int id, FichaClienteDto fichaCliente)
        {

            if (fichaCliente == null) return NotFound();
            if (fichaCliente.id != id) return BadRequest();
            if (!ProductExist(id)) return NotFound();


            repository.Update(fichaCliente);
            if (await repository.SaveChangesAsync())
            {
                return NoContent();
            }
            else
            {
                return BadRequest("Falha ao Atualizar Ficha");
            }


        }
              

        private bool ProductExist(int id)
        {
            return repository.Exists(id);
        }

    }
}
