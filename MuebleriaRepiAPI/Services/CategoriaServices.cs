using MuebleriaRepiAPI.Interfaces;
using MuebleriaRepiAPI.Models;
using MuebleriaRepiAPI.Models.DTO;

namespace MuebleriaRepiAPI.Services
{
    public class CategoriaServices : IDataRepository<Categorium, CategoriumDTO>
    {

        private readonly dbMuebleriaRepiContext _context;

        public CategoriaServices(dbMuebleriaRepiContext _context)
        {
            this._context = _context;
        }

        public async Task<bool> Delete(int? id)
        {
            var data = await Task.FromResult(from usuarios in _context.Productos.Where(x => x.IdCategoria == id)
                                       
                                       select new Producto
                                       {
                                           IdCategoria = usuarios.IdCategoria
                                       });

            if (data == null)
            {
                return false;
            }
            try
            {

                var entidad = await _context.Categoria.FindAsync(id);
                if (entidad == null)
                {
                    return false;
                }
                await Task.FromResult(_context.Categoria.Remove(entidad));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<IEnumerable<CategoriumDTO>> GetAllDTO()
        {
            var entity = await Task.FromResult(from categorias in _context.Categoria
                                               select new CategoriumDTO
                                               {
                                                  IdCategoria = categorias.IdCategoria,
                                                  Categoria = categorias.Categoria,
                                               });
            return entity;
        }

        public async Task<bool> Insert(Categorium entity)
        {
            if (entity == null)
            {
                return false;
            }

            try
            {
                await _context.Categoria.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<bool> Update(Categorium entity)
        {
            if (entity == null)
            {
                return false;
            }

            try
            {
                await Task.FromResult(_context.Categoria.Update(entity));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
    }
}
