using MarketPeruCore.DTO;
using MarketPeruCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicioRestCore;

namespace MarketPeruCore.Controllers
{
    [ApiController]
    [Route("api/tienditarest/local")]
    public class LocalController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public LocalController(ApplicationDBContext context)
        {
            _context = context;
        }

        // Obtener todos los locales
        [HttpGet("")]
        public async Task<ActionResult<List<LocalDTO>>> FindAll()
        {
            return await _context.Locales.Select(l => new LocalDTO
            {
                IdLocal = l.IdLocal,
                Direccion = l.Direccion,
                Distrito = l.Distrito,
                Telefono = l.Telefono,
                Fax = l.Fax
            }).ToListAsync();
        }

        // Agregar un nuevo local
        [HttpPost("")]
        public async Task<ActionResult> Add(LocalDTO localDTO)
        {
            var local = new Local
            {
                Direccion = localDTO.Direccion,
                Distrito = localDTO.Distrito,
                Telefono = localDTO.Telefono,
                Fax = localDTO.Fax
            };
            _context.Add(local);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // Buscar un local por ID
        [HttpGet("{id:int}")]
        public async Task<ActionResult<LocalDTO>> FindById(int id)
        {
            var local = await _context.Locales
                .Select(l => new LocalDTO
                {
                    IdLocal = l.IdLocal,
                    Direccion = l.Direccion,
                    Distrito = l.Distrito,
                    Telefono = l.Telefono,
                    Fax = l.Fax
                })
                .FirstOrDefaultAsync(l => l.IdLocal == id);

            if (local == null)
            {
                return NotFound();
            }
            return local;
        }

        // Actualizar un local
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, LocalDTO localDTO)
        {
            if (localDTO.IdLocal != id)
            {
                return BadRequest("El ID del local no coincide.");
            }

            var local = await _context.Locales.FindAsync(id);
            if (local == null)
            {
                return NotFound();
            }

            local.Direccion = localDTO.Direccion;
            local.Distrito = localDTO.Distrito;
            local.Telefono = localDTO.Telefono;
            local.Fax = localDTO.Fax;

            _context.Update(local);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // Eliminar un local cambiando su estado a false
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var local = await _context.Locales.FirstOrDefaultAsync(l => l.IdLocal == id);
            if (local == null)
            {
                return NotFound();
            }

            _context.Remove(local);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
