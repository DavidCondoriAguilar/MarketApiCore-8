using MarketPeruCore.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPeruCore.Interfaces
{
    public interface IProveedorService
    {
        Task<List<ProveedorDTO>> FindAll();
        Task<ProveedorDTO> FindById(int id);
        Task Add(ProveedorDTO proveedorDTO);
        Task Update(int id, ProveedorDTO proveedorDTO);
        Task Delete(int id);
    }
}
