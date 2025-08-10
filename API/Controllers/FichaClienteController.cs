using API.DTOs;
using Core.Entities;
using Core.Interfaces;
using Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    public class FichaClienteController(IUnitOfWork unitow,
        ILogger<FichaClienteController> logger) : BaseAPIController
    {

        [HttpGet("{id:int}")]
        public async Task<ActionResult<FichaClienteDto>> GetById(int id)
        {
            logger.LogInformation("Solicitação para obter previsão do tempo recebida.");

            var obj = await unitow.Repository<FichaCliente>().GetByIdAsync(id);
            if (obj == null) return NotFound();

            FichaClienteDto objDto = obj;

            return objDto;
        }


        [HttpPost]
        public async Task<ActionResult<FichaClienteDto>> Create(FichaClienteDto objDto)
        {
            FichaCliente fichaCliente = objDto;
          
            unitow.Repository<FichaCliente>().Add(fichaCliente);

            if (await unitow.Complete())
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
            var fichaCliente = await unitow.Repository<FichaCliente>().GetByIdAsync(id);
            if (fichaCliente == null) return NotFound();


            unitow.Repository<FichaCliente>().Remove(fichaCliente);
            if (await unitow.Complete())
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


            unitow.Repository<FichaCliente>().Update(fichaCliente);
            if (await unitow.Complete())
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
            return unitow.Repository<FichaCliente>().Exists(id);
        }

    }
}
