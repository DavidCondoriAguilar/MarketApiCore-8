using MarketPeruCore.DTO;
using MarketPeruCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPeruCore.Controllers
{
    [ApiController]
    [Route("api/tienditarest/orden")]
    public class OrdenController : ControllerBase
    {
        private readonly IOrdenService _ordenService;

        public OrdenController(IOrdenService ordenService)
        {
            _ordenService = ordenService;
        }

        [HttpGet("")]
        public async Task<ActionResult<List<OrdenDTO>>> FindAll()
        {
            var ordenes = await _ordenService.FindAll();
            return Ok(ordenes);
        }

        [HttpPost("")]
        public async Task<ActionResult> Add(OrdenDTO ordenDTO)
        {
            await _ordenService.Add(ordenDTO);
            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<OrdenDTO>> FindById(int id)
        {
            var orden = await _ordenService.FindById(id);
            if (orden == null)
            {
                return NotFound();
            }
            return Ok(orden);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, OrdenDTO ordenDTO)
        {
            if (ordenDTO.IdOrden != id)
            {
                return BadRequest("El ID de la orden no coincide.");
            }

            await _ordenService.Update(id, ordenDTO);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _ordenService.Delete(id);
            return Ok();
        }
    }
}
