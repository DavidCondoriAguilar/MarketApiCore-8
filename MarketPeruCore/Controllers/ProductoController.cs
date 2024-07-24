using MarketPeruCore.DTO;
using MarketPeruCore.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPeruCore.Controllers
{
    [ApiController]
    [Route("api/tienditarest/producto")]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _productoService;

        public ProductoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        [HttpGet("")]
        public async Task<ActionResult<List<ProductoDTO>>> FindAll()
        {
            var productos = await _productoService.FindAll();
            return Ok(productos);
        }

        [HttpPost("")]
        public async Task<ActionResult> Add(ProductoDTO productoDTO)
        {
            await _productoService.Add(productoDTO);
            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductoDTO>> FindById(int id)
        {
            var producto = await _productoService.FindById(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, ProductoDTO productoDTO)
        {
            if (productoDTO.IdProducto != id)
            {
                return BadRequest("El ID del producto no coincide.");
            }

            await _productoService.Update(id, productoDTO);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _productoService.Delete(id);
            return Ok();
        }
    }
}
