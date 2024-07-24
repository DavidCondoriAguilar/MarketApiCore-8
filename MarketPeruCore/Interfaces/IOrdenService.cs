using MarketPeruCore.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPeruCore.Interfaces
{
    public interface IOrdenService
    {
        Task<List<OrdenDTO>> FindAll();
        Task<OrdenDTO> FindById(int id);
        Task Add(OrdenDTO ordenDTO);
        Task Update(int id, OrdenDTO ordenDTO);
        Task Delete(int id);
    }
}
