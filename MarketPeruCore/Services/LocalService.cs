using MarketPeruCore.DTO;
using MarketPeruCore.Interfaces;
using MarketPeruCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPeruCore.Services
{
    public class LocalService : ILocalService
    {
        private readonly MarketPeruContext _context;

        public LocalService(MarketPeruContext context)
        {
            _context = context;
        }

        public async Task<List<LocalDTO>> FindAll()
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

        public async Task<LocalDTO> FindById(int id)
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

            return local;
        }

        public async Task Add(LocalDTO localDTO)
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
        }

        public async Task Update(int id, LocalDTO localDTO)
        {
            var local = await _context.Locales.FindAsync(id);
            if (local == null)
            {
                return;
            }

            local.Direccion = localDTO.Direccion;
            local.Distrito = localDTO.Distrito;
            local.Telefono = localDTO.Telefono;
            local.Fax = localDTO.Fax;

            _context.Update(local);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var local = await _context.Locales.FirstOrDefaultAsync(l => l.IdLocal == id);
            if (local == null)
            {
                return;
            }

            _context.Remove(local);
            await _context.SaveChangesAsync();
        }
    }
}
