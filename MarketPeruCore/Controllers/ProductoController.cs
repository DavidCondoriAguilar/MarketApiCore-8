using MarketPeruCore.DTO;
using MarketPeruCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
    
namespace MarketPeruCore.Controllers
{
    [ApiController]
    [Route("api/tienditarest/producto")]
    public class ProductoController : ControllerBase
    {
        private readonly MarketPeruContext _context;

        public ProductoController(MarketPeruContext context)
        {
            _context = context;
        }

        // Obtener todos los productos
        [HttpGet("")]
        public async Task<ActionResult<List<ProductoDTO>>> FindAll()
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

        // Agregar un nuevo producto
        [HttpPost("")]
        public async Task<ActionResult> Add(ProductoDTO productoDTO)
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
            return Ok();
        }

        // Buscar un producto por ID
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductoDTO>> FindById(int id)
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

            if (producto == null)
            {
                return NotFound();
            }
            return producto;
        }

        // Actualizar un producto
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, ProductoDTO productoDTO)
        {
            if (productoDTO.IdProducto != id)
            {
                return BadRequest("El ID del producto no coincide.");
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
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
            return Ok();
        }

        // Eliminar un producto cambiando su estado a false
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var producto = await _context.Productos.FirstOrDefaultAsync(p => p.IdProducto == id);
            if (producto == null)
            {
                return NotFound();
            }

            producto.Estado = false;
            _context.Update(producto);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
