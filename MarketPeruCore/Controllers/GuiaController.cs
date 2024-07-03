using MarketPeruCore.DTO;
using MarketPeruCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicioRestCore;

namespace MarketPeruCore.Controllers
{
    [ApiController]
    [Route("api/tienditarest/guia")]
    public class GuiaController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public GuiaController(ApplicationDBContext context)
        {
            _context = context;
        }

        // Obtener todas las guías
        [HttpGet("")]
        public async Task<ActionResult<List<GuiaDTO>>> FindAll()
        {
            return await _context.Guias.Select(g => new GuiaDTO
            {
                IdGuia = g.IdGuia,
                IdLocal = g.IdLocal,
                FechaSalida = g.FechaSalida,
                Transportista = g.Transportista
            }).ToListAsync();
        }

        // Agregar una nueva guía
        [HttpPost("")]
        public async Task<ActionResult> Add(GuiaDTO guiaDTO)
        {
            var guia = new Guia
            {
                IdLocal = guiaDTO.IdLocal,
                FechaSalida = guiaDTO.FechaSalida,
                Transportista = guiaDTO.Transportista
            };
            _context.Add(guia);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // Buscar una guía por ID
        [HttpGet("{id:int}")]
        public async Task<ActionResult<GuiaDTO>> FindById(int id)
        {
            var guia = await _context.Guias
                .Select(g => new GuiaDTO
                {
                    IdGuia = g.IdGuia,
                    IdLocal = g.IdLocal,
                    FechaSalida = g.FechaSalida,
                    Transportista = g.Transportista
                })
                .FirstOrDefaultAsync(g => g.IdGuia == id);

            if (guia == null)
            {
                return NotFound();
            }
            return guia;
        }

        // Actualizar una guía
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, GuiaDTO guiaDTO)
        {
            if (guiaDTO.IdGuia != id)
            {
                return BadRequest("El ID de la guía no coincide.");
            }

            var guia = await _context.Guias.FindAsync(id);
            if (guia == null)
            {
                return NotFound();
            }

            guia.IdLocal = guiaDTO.IdLocal;
            guia.FechaSalida = guiaDTO.FechaSalida;
            guia.Transportista = guiaDTO.Transportista;

            _context.Update(guia);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // Eliminar una guía cambiando su estado a false
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var guia = await _context.Guias.FirstOrDefaultAsync(g => g.IdGuia == id);
            if (guia == null)
            {
                return NotFound();
            }

            _context.Remove(guia);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
