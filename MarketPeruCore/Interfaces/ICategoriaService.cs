using MarketPeruCore.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarketPeruCore.Interfaces
{
    public interface ICategoriaService
    {
        Task<List<CategoriaDTO>> FindAll();
        Task<List<CategoriaDTO>> FindAllCustom();
        Task<CategoriaDTO> FindById(int id);
        Task Add(CategoriaDTO categoriaDTO);
        Task Update(int id, CategoriaDTO categoriaDTO);
        Task Delete(int id);
    }
}
