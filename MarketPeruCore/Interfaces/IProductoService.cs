using MarketPeruCore.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPeruCore.Interfaces
{
    public interface IProductoService
    {
        Task<List<ProductoDTO>> FindAll();
        Task<ProductoDTO> FindById(int id);
        Task Add(ProductoDTO productoDTO);
        Task Update(int id, ProductoDTO productoDTO);
        Task Delete(int id);
    }
}
