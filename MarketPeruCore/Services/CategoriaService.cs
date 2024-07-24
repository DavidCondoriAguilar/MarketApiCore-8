using MarketPeruCore.DTO;
using MarketPeruCore.Models;
using MarketPeruCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPeruCore.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly MarketPeruContext _context;

        public CategoriaService(MarketPeruContext context)
        {
            _context = context;
        }

        public async Task<List<CategoriaDTO>> FindAll()
        {
            var categorias = await _context.Categorias
                .Select(c => new CategoriaDTO
                {
                    IdCategoria = c.IdCategoria,
                    Nombre = c.Nombre,
                    Descripcion = c.Descripcion,
                    Estado = c.Estado
                })
                .ToListAsync();

            return categorias;
        }

        public async Task<List<CategoriaDTO>> FindAllCustom()
        {
            var categorias = await _context.Categorias
                .Where(c => c.Estado == true)
                .Select(c => new CategoriaDTO
                {
                    IdCategoria = c.IdCategoria,
                    Nombre = c.Nombre,
                    Descripcion = c.Descripcion,
                    Estado = c.Estado
                })
                .ToListAsync();

            return categorias;
        }

        public async Task<CategoriaDTO> FindById(int id)
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

            return categoria;
        }

        public async Task Add(CategoriaDTO categoriaDTO)
        {
            var categoria = new Categoria
            {
                Nombre = categoriaDTO.Nombre,
                Descripcion = categoriaDTO.Descripcion,
                Estado = categoriaDTO.Estado
            };

            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, CategoriaDTO categoriaDTO)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return;
            }

            categoria.Nombre = categoriaDTO.Nombre;
            categoria.Descripcion = categoriaDTO.Descripcion;
            categoria.Estado = categoriaDTO.Estado;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var categoria = await _context.Categorias.FirstOrDefaultAsync(c => c.IdCategoria == id);
            if (categoria == null)
            {
                return;
            }

            categoria.Estado = false;
            await _context.SaveChangesAsync();
        }
    }
}
