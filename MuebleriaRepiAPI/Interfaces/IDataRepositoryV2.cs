using MuebleriaRepiAPI.Models;
using MuebleriaRepiAPI.Models.DTO;

namespace MuebleriaRepiAPI.Interfaces

{
    public interface IDataRepositoryV2<TEntidad>
    {
        Task<bool> Delete(int? id);
        Task<bool> Insert(TEntidad entity);
        Task<IEnumerable<TEntidad>> GetAll();
    }
}
