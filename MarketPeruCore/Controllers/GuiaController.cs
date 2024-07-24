using MarketPeruCore.DTO;
using MarketPeruCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPeruCore.Controllers
{
    [ApiController]
    [Route("api/tienditarest/guia")]
    public class GuiaController : ControllerBase
    {
        private readonly IGuiaService _guiaService;

        public GuiaController(IGuiaService guiaService)
        {
            _guiaService = guiaService;
        }

        [HttpGet("")]
        public async Task<ActionResult<List<GuiaDTO>>> FindAll()
        {
            var guias = await _guiaService.FindAll();
            return Ok(guias);
        }

        [HttpPost("")]
        public async Task<ActionResult> Add(GuiaDTO guiaDTO)
        {
            await _guiaService.Add(guiaDTO);
            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<GuiaDTO>> FindById(int id)
        {
            var guia = await _guiaService.FindById(id);
            if (guia == null)
            {
                return NotFound();
            }
            return Ok(guia);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, GuiaDTO guiaDTO)
        {
            if (guiaDTO.IdGuia != id)
            {
                return BadRequest("El ID de la guía no coincide.");
            }

            await _guiaService.Update(id, guiaDTO);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _guiaService.Delete(id);
            return Ok();
        }
    }
}
