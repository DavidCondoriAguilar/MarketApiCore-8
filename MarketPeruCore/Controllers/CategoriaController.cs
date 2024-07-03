using MarketPeruCore.DTO;
using MarketPeruCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicioRestCore;

namespace MarketPeruCore.Controllers
{
    [ApiController]
    [Route("api/tienditarest/categoria")]
    public class CategoriaController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public CategoriaController(ApplicationDBContext context)
        {
            _context = context;
        }

        // Obtener todas las categorías
        [HttpGet("")]
        public async Task<ActionResult<List<CategoriaDTO>>> FindAll()
        {
            return await _context.Categorias.Select(c => new CategoriaDTO
            {
                IdCategoria = c.IdCategoria,
                Nombre = c.Nombre,
                Descripcion = c.Descripcion,
                Estado = c.Estado
            }).ToListAsync();
        }

        // Obtener todas las categorías habilitadas
        [HttpGet("custom")]
        public async Task<ActionResult<List<CategoriaDTO>>> FindAllCustom()
        {
            return await _context.Categorias
                .Where(c => c.Estado == true)
                .Select(c => new CategoriaDTO
                {
                    IdCategoria = c.IdCategoria,
                    Nombre = c.Nombre,
                    Descripcion = c.Descripcion,
                    Estado = c.Estado
                }).ToListAsync();
        }

        // Agregar una nueva categoría
        [HttpPost("")]
        public async Task<ActionResult> Add(CategoriaDTO categoriaDTO)
        {
            var categoria = new Categoria
            {
                Nombre = categoriaDTO.Nombre,
                Descripcion = categoriaDTO.Descripcion,
                Estado = categoriaDTO.Estado
            };
            _context.Add(categoria);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // Buscar una categoría por ID
        [HttpGet("{id:int}")]
        public async Task<ActionResult<CategoriaDTO>> FindById(int id)
        {
            var categoria = await _context.Categorias
                .Select(c => new CategoriaDTO
                {
                    IdCategoria = c.IdCategoria,
                    Nombre = c.Nombre,
                    Descripcion = c.Descripcion,
                    Estado = c.Estado
                })
                .FirstOrDefaultAsync(c => c.IdCategoria == id);

            if (categoria == null)
            {
                return NotFound();
            }
            return categoria;
        }

        // Actualizar una categoría
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, CategoriaDTO categoriaDTO)
        {
            if (categoriaDTO.IdCategoria != id)
            {
                return BadRequest("El ID de la categoría no coincide.");
            }

            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            categoria.Nombre = categoriaDTO.Nombre;
            categoria.Descripcion = categoriaDTO.Descripcion;
            categoria.Estado = categoriaDTO.Estado;

            _context.Update(categoria);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // "Eliminar" una categoría cambiando su estado a false
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.IdCategoria == id);
            if (categoria == null)
            {
                return NotFound();
            }

            categoria.Estado = false;
            _context.Update(categoria);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
