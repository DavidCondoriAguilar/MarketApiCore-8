using MarketPeruCore.DTO;
using MarketPeruCore.Interfaces;
using MarketPeruCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPeruCore.Services
{
    public class OrdenService : IOrdenService
    {
        private readonly MarketPeruContext _context;

        public OrdenService(MarketPeruContext context)
        {
            _context = context;
        }

        public async Task<List<OrdenDTO>> FindAll()
        {
            return await _context.Ordenes.Select(o => new OrdenDTO
            {
                IdOrden = o.IdOrden,
                FechaOrden = o.FechaOrden,
                FechaEntrada = o.FechaEntrada,
                Estado = o.Estado
            }).ToListAsync();
        }

        public async Task<OrdenDTO> FindById(int id)
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

            return orden;
        }

        public async Task Add(OrdenDTO ordenDTO)
        {
            var orden = new Orden
            {
                FechaOrden = ordenDTO.FechaOrden,
                FechaEntrada = ordenDTO.FechaEntrada,
                Estado = ordenDTO.Estado
            };
            _context.Add(orden);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, OrdenDTO ordenDTO)
        {
            var orden = await _context.Ordenes.FindAsync(id);
            if (orden == null)
            {
                return;
            }

            orden.FechaOrden = ordenDTO.FechaOrden;
            orden.FechaEntrada = ordenDTO.FechaEntrada;
            orden.Estado = ordenDTO.Estado;

            _context.Update(orden);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var orden = await _context.Ordenes.FirstOrDefaultAsync(o => o.IdOrden == id);
            if (orden == null)
            {
                return;
            }

            orden.Estado = false;
            _context.Update(orden);
            await _context.SaveChangesAsync();
        }
    }
}
