using MarketPeruCore.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPeruCore.Interfaces
{
    public interface IGuiaService
    {
        Task<List<GuiaDTO>> FindAll();
        Task<GuiaDTO> FindById(int id);
        Task Add(GuiaDTO guiaDTO);
        Task Update(int id, GuiaDTO guiaDTO);
        Task Delete(int id);
    }
}
