namespace MuebleriaRepiAPI.Interfaces
{
    public interface IDataRepository<TEntidad,T>
    {
       
        Task<bool> Delete(int? id);
        Task<bool> Update(TEntidad entity);
        Task<bool> Insert(TEntidad entity);
        Task<IEnumerable<T>> GetAllDTO();

    }
}
