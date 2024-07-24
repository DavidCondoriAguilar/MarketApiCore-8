using MarketPeruCore.DTO;
using MarketPeruCore.Interfaces;
using MarketPeruCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPeruCore.Services
{
    public class GuiaService : IGuiaService
    {
        private readonly MarketPeruContext _context;

        public GuiaService(MarketPeruContext context)
        {
            _context = context;
        }

        public async Task<List<GuiaDTO>> FindAll()
        {
            return await _context.Guias.Select(g => new GuiaDTO
            {
                IdGuia = g.IdGuia,
                IdLocal = g.IdLocal,
                FechaSalida = g.FechaSalida,
                Transportista = g.Transportista
            }).ToListAsync();
        }

        public async Task<GuiaDTO> FindById(int id)
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

            return guia;
        }

        public async Task Add(GuiaDTO guiaDTO)
        {
            var guia = new Guia
            {
                IdLocal = guiaDTO.IdLocal,
                FechaSalida = guiaDTO.FechaSalida,
                Transportista = guiaDTO.Transportista
            };
            _context.Add(guia);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, GuiaDTO guiaDTO)
        {
            var guia = await _context.Guias.FindAsync(id);
            if (guia == null)
            {
                return;
            }

            guia.IdLocal = guiaDTO.IdLocal;
            guia.FechaSalida = guiaDTO.FechaSalida;
            guia.Transportista = guiaDTO.Transportista;

            _context.Update(guia);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var guia = await _context.Guias.FirstOrDefaultAsync(g => g.IdGuia == id);
            if (guia == null)
            {
                return;
            }

            _context.Remove(guia);
            await _context.SaveChangesAsync();
        }
    }
}
