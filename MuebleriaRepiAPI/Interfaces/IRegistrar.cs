namespace MuebleriaRepiAPI.Interfaces
{
    public interface IRegistrar<TEntidad,T>
    {
        Task<bool> Validar(T entity);
        Task<IEnumerable<TEntidad>> Get(T entidad);
        Task<bool> Insert(TEntidad entity);

        Task<bool> Validar2(string email);
    }
}
