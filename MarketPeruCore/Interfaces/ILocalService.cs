using MarketPeruCore.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPeruCore.Interfaces
{
    public interface ILocalService
    {
        Task<List<LocalDTO>> FindAll();
        Task<LocalDTO> FindById(int id);
        Task Add(LocalDTO localDTO);
        Task Update(int id, LocalDTO localDTO);
        Task Delete(int id);
    }
}
