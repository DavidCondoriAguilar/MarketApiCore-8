using MarketPeruCore.DTO;
using MarketPeruCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPeruCore.Controllers
{
    [ApiController]
    [Route("api/tienditarest/local")]
    public class LocalController : ControllerBase
    {
        private readonly ILocalService _localService;

        public LocalController(ILocalService localService)
        {
            _localService = localService;
        }

        [HttpGet("")]
        public async Task<ActionResult<List<LocalDTO>>> FindAll()
        {
            var locales = await _localService.FindAll();
            return Ok(locales);
        }

        [HttpPost("")]
        public async Task<ActionResult> Add(LocalDTO localDTO)
        {
            await _localService.Add(localDTO);
            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<LocalDTO>> FindById(int id)
        {
            var local = await _localService.FindById(id);
            if (local == null)
            {
                return NotFound();
            }
            return Ok(local);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, LocalDTO localDTO)
        {
            if (localDTO.IdLocal != id)
            {
                return BadRequest("El ID del local no coincide.");
            }

            await _localService.Update(id, localDTO);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _localService.Delete(id);
            return Ok();
        }
    }
}
