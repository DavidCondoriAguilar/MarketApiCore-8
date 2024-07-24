using MarketPeruCore.DTO;
using MarketPeruCore.Interfaces;
using MarketPeruCore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPeruCore.Controllers
{
    [ApiController]
    [Route("api/tienditarest/categoria")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet("")]
        public async Task<ActionResult<List<CategoriaDTO>>> FindAll()
        {
            var categorias = await _categoriaService.FindAll();
            return Ok(categorias);
        }

        [HttpGet("custom")]
        public async Task<ActionResult<List<CategoriaDTO>>> FindAllCustom()
        {
            var categorias = await _categoriaService.FindAllCustom();
            return Ok(categorias);
        }

        [HttpPost("")]
        public async Task<ActionResult> Add(CategoriaDTO categoriaDTO)
        {
            await _categoriaService.Add(categoriaDTO);
            return Ok();
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoriaDTO>> FindById(int id)
        {
            var categoria = await _categoriaService.FindById(id);
            if (categoria == null)
            {
                return NotFound();
            }

            return Ok(categoria);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO.IdCategoria != id)
            {
                return BadRequest("El ID de la categoría no coincide.");
            }

            await _categoriaService.Update(id, categoriaDTO);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _categoriaService.Delete(id);
            return Ok();
        }
    }
}
