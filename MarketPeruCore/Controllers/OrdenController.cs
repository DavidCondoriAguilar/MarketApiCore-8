using MarketPeruCore.DTO;
using MarketPeruCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicioRestCore;

namespace MarketPeruCore.Controllers
{
    [ApiController]
    [Route("api/tienditarest/orden")]
    public class OrdenController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public OrdenController(ApplicationDBContext context)
        {
            _context = context;
        }

        // Obtener todas las órdenes
        [HttpGet("")]
        public async Task<ActionResult<List<OrdenDTO>>> FindAll()
        {
            return await _context.Ordenes.Select(o => new OrdenDTO
            {
                IdOrden = o.IdOrden,
                FechaOrden = o.FechaOrden,
                FechaEntrada = o.FechaEntrada,
                Estado = o.Estado
            }).ToListAsync();
        }

        // Agregar una nueva orden
        [HttpPost("")]
        public async Task<ActionResult> Add(OrdenDTO ordenDTO)
        {
            var orden = new Orden
            {
                FechaOrden = ordenDTO.FechaOrden,
                FechaEntrada = ordenDTO.FechaEntrada,
                Estado = ordenDTO.Estado
            };
            _context.Add(orden);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // Buscar una orden por ID
        [HttpGet("{id:int}")]
        public async Task<ActionResult<OrdenDTO>> FindById(int id)
        {
            var orden = await _context.Ordenes
                .Select(o => new OrdenDTO
                {
                    IdOrden = o.IdOrden,
                    FechaOrden = o.FechaOrden,
                    FechaEntrada = o.FechaEntrada,
                    Estado = o.Estado
                })
                .FirstOrDefaultAsync(o => o.IdOrden == id);

            if (orden == null)
            {
                return NotFound();
            }
            return orden;
        }

        // Actualizar una orden
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, OrdenDTO ordenDTO)
        {
            if (ordenDTO.IdOrden != id)
            {
                return BadRequest("El ID de la orden no coincide.");
            }

            var orden = await _context.Ordenes.FindAsync(id);
            if (orden == null)
            {
                return NotFound();
            }

            orden.FechaOrden = ordenDTO.FechaOrden;
            orden.FechaEntrada = ordenDTO.FechaEntrada;
            orden.Estado = ordenDTO.Estado;

            _context.Update(orden);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // Eliminar una orden cambiando su estado a false
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var orden = await _context.Ordenes.FirstOrDefaultAsync(o => o.IdOrden == id);
            if (orden == null)
            {
                return NotFound();
            }

            orden.Estado = false;
            _context.Update(orden);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
