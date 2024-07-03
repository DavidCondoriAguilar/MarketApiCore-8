using MarketPeruCore.DTO;
using MarketPeruCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ServicioRestCore;

namespace MarketPeruCore.Controllers
{
    [ApiController]
    [Route("api/tienditarest/proveedor")]
    public class ProveedorController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public ProveedorController(ApplicationDBContext context)
        {
            _context = context;
        }

        // Obtener todos los proveedores
        [HttpGet("")]
        public async Task<ActionResult<List<ProveedorDTO>>> FindAll()
        {
            return await _context.Proveedores.Select(p => new ProveedorDTO
            {
                IdProveedor = p.IdProveedor,
                Nombre = p.Nombre,
                Representante = p.Representante,
                Direccion = p.Direccion,
                Ciudad = p.Ciudad,
                Departamento = p.Departamento,
                CodigoPostal = p.CodigoPostal,
                Telefono = p.Telefono,
                Fax = p.Fax,
                Estado = p.Estado
            }).ToListAsync();
        }

        // Agregar un nuevo proveedor
        [HttpPost("")]
        public async Task<ActionResult> Add(ProveedorDTO proveedorDTO)
        {
            var proveedor = new Proveedor
            {
                Nombre = proveedorDTO.Nombre,
                Representante = proveedorDTO.Representante,
                Direccion = proveedorDTO.Direccion,
                Ciudad = proveedorDTO.Ciudad,
                Departamento = proveedorDTO.Departamento,
                CodigoPostal = proveedorDTO.CodigoPostal,
                Telefono = proveedorDTO.Telefono,
                Fax = proveedorDTO.Fax,
                Estado = proveedorDTO.Estado
            };
            _context.Add(proveedor);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // Buscar un proveedor por ID
        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProveedorDTO>> FindById(int id)
        {
            var proveedor = await _context.Proveedores
                .Select(p => new ProveedorDTO
                {
                    IdProveedor = p.IdProveedor,
                    Nombre = p.Nombre,
                    Representante = p.Representante,
                    Direccion = p.Direccion,
                    Ciudad = p.Ciudad,
                    Departamento = p.Departamento,
                    CodigoPostal = p.CodigoPostal,
                    Telefono = p.Telefono,
                    Fax = p.Fax,
                    Estado = p.Estado
                })
                .FirstOrDefaultAsync(p => p.IdProveedor == id);

            if (proveedor == null)
            {
                return NotFound();
            }
            return proveedor;
        }

        // Actualizar un proveedor
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Update(int id, ProveedorDTO proveedorDTO)
        {
            if (proveedorDTO.IdProveedor != id)
            {
                return BadRequest("El ID del proveedor no coincide.");
            }

            var proveedor = await _context.Proveedores.FindAsync(id);
            if (proveedor == null)
            {
                return NotFound();
            }

            proveedor.Nombre = proveedorDTO.Nombre;
            proveedor.Representante = proveedorDTO.Representante;
            proveedor.Direccion = proveedorDTO.Direccion;
            proveedor.Ciudad = proveedorDTO.Ciudad;
            proveedor.Departamento = proveedorDTO.Departamento;
            proveedor.CodigoPostal = proveedorDTO.CodigoPostal;
            proveedor.Telefono = proveedorDTO.Telefono;
            proveedor.Fax = proveedorDTO.Fax;
            proveedor.Estado = proveedorDTO.Estado;

            _context.Update(proveedor);
            await _context.SaveChangesAsync();
            return Ok();
        }

        // Eliminar un proveedor cambiando su estado a false
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var proveedor = await _context.Proveedores.FirstOrDefaultAsync(p => p.IdProveedor == id);
            if (proveedor == null)
            {
                return NotFound();
            }

            proveedor.Estado = false;
            _context.Update(proveedor);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
