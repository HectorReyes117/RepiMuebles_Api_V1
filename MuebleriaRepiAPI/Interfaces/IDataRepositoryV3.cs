namespace MuebleriaRepiAPI.Interfaces
{
    public interface IDataRepositoryV3<TEntidad>
    {
        Task<bool> Delete(int? id);
        Task<bool> Update(TEntidad entity);
        Task<bool> Insert(TEntidad entity);
        Task<IEnumerable<TEntidad>> GetAllDTO();
    }
}
