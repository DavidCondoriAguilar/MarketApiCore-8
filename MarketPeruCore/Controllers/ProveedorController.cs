using MarketPeruCore.DTO;
using MarketPeruCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPeruCore.Controllers
{
    [ApiController]
    [Route("api/tienditarest/proveedor")]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorService _proveedorService;

        public ProveedorController(IProveedorService proveedorService)
        {
            _proveedorService = proveedorService;
        }

        [HttpGet("")]
        public async Task<ActionResult<List<ProveedorDTO>>> FindAll()
        {
            var proveedores = await _proveedorService.FindAll();
            return Ok(proveedores);
        }

        [HttpPost("")]
        public async Task<ActionResult> Add(ProveedorDTO proveedorDTO)
        {
            await _proveedorService.Add(proveedorDTO);
            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProveedorDTO>> FindById(int id)
        {
            var proveedor = await _proveedorService.FindById(id);
            if (proveedor == null)
            {
                return NotFound();
            }
            return Ok(proveedor);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, ProveedorDTO proveedorDTO)
        {
            if (proveedorDTO.IdProveedor != id)
            {
                return BadRequest("El ID del proveedor no coincide.");
            }

            await _proveedorService.Update(id, proveedorDTO);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _proveedorService.Delete(id);
            return Ok();
        }
    }
}
