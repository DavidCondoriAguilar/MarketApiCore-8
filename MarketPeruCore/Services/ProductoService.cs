using MarketPeruCore.DTO;
using MarketPeruCore.Interfaces;
using MarketPeruCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPeruCore.Services
{
    public class ProductoService : IProductoService
    {
        private readonly MarketPeruContext _context;

        public ProductoService(MarketPeruContext context)
        {
            _context = context;
        }

        public async Task<List<ProductoDTO>> FindAll()
        {
            return await _context.Productos.Select(p => new ProductoDTO
            {
                IdProducto = p.IdProducto,
                IdCategoria = p.IdCategoria,
                IdProveedor = p.IdProveedor,
                Nombre = p.Nombre,
                UnidadMedida = p.UnidadMedida,
                PrecioProveedor = p.PrecioProveedor,
                StockActual = p.StockActual,
                StockMinimo = p.StockMinimo,
                Descontinuado = p.Descontinuado,
                Estado = p.Estado
            }).ToListAsync();
        }

        public async Task<ProductoDTO> FindById(int id)
        {
            var producto = await _context.Productos
                .Select(p => new ProductoDTO
                {
                    IdProducto = p.IdProducto,
                    IdCategoria = p.IdCategoria,
                    IdProveedor = p.IdProveedor,
                    Nombre = p.Nombre,
                    UnidadMedida = p.UnidadMedida,
                    PrecioProveedor = p.PrecioProveedor,
                    StockActual = p.StockActual,
                    StockMinimo = p.StockMinimo,
                    Descontinuado = p.Descontinuado,
                    Estado = p.Estado
                })
                .FirstOrDefaultAsync(p => p.IdProducto == id);

            return producto;
        }

        public async Task Add(ProductoDTO productoDTO)
        {
            var producto = new Producto
            {
                IdCategoria = productoDTO.IdCategoria,
                IdProveedor = productoDTO.IdProveedor,
                Nombre = productoDTO.Nombre,
                UnidadMedida = productoDTO.UnidadMedida,
                PrecioProveedor = productoDTO.PrecioProveedor,
                StockActual = productoDTO.StockActual,
                StockMinimo = productoDTO.StockMinimo,
                Descontinuado = productoDTO.Descontinuado,
                Estado = productoDTO.Estado
            };
            _context.Add(producto);
            await _context.SaveChangesAsync();
        }

        public async Task Update(int id, ProductoDTO productoDTO)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return;
            }

            producto.IdCategoria = productoDTO.IdCategoria;
            producto.IdProveedor = productoDTO.IdProveedor;
            producto.Nombre = productoDTO.Nombre;
            producto.UnidadMedida = productoDTO.UnidadMedida;
            producto.PrecioProveedor = productoDTO.PrecioProveedor;
            producto.StockActual = productoDTO.StockActual;
            producto.StockMinimo = productoDTO.StockMinimo;
            producto.Descontinuado = productoDTO.Descontinuado;
            producto.Estado = productoDTO.Estado;

            _context.Update(producto);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var producto = await _context.Productos.FirstOrDefaultAsync(p => p.IdProducto == id);
            if (producto == null)
            {
                return;
            }

            producto.Estado = false;
            _context.Update(producto);
            await _context.SaveChangesAsync();
        }
    }
}
