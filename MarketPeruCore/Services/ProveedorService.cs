using MarketPeruCore.DTO;
using MarketPeruCore.Interfaces;
using MarketPeruCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPeruCore.Services
{
    public class ProveedorService : IProveedorService
    {
        private readonly MarketPeruContext _context;

        public ProveedorService(MarketPeruContext context)
        {
            _context = context;
        }

        public async Task<List<ProveedorDTO>> FindAll()
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

        public async Task<ProveedorDTO> FindById(int id)
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

            return proveedor;
        }

        public async Task Add(ProveedorDTO proveedorDTO)
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
        }

        public async Task Update(int id, ProveedorDTO proveedorDTO)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);
            if (proveedor == null)
            {
                return;
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
        }

        public async Task Delete(int id)
        {
            var proveedor = await _context.Proveedores.FirstOrDefaultAsync(p => p.IdProveedor == id);
            if (proveedor == null)
            {
                return;
            }

            proveedor.Estado = false;
            _context.Update(proveedor);
            await _context.SaveChangesAsync();
        }
    }
}
