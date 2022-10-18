using MuebleriaRepiAPI.DTO;
using MuebleriaRepiAPI.Interfaces;
using MuebleriaRepiAPI.Models;

namespace MuebleriaRepiAPI.Services
{
    public class MarcaServices : IDataRepository<Marca, MarcaDTO>
    {
        private readonly dbMuebleriaRepiContext _context;

        public MarcaServices(dbMuebleriaRepiContext _context)
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

            if (id == null)
            {
                return false;
            }
            try
            {
                var entidad = await _context.Marcas.FindAsync(id);
                if (entidad == null)
                {
                    return false;
                }
                await Task.FromResult(_context.Marcas.Remove(entidad));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<IEnumerable<MarcaDTO>> GetAllDTO()
        {
            var entity = await Task.FromResult(from marcas in _context.Marcas
                                               select new MarcaDTO
                                               {
                                                  IdMarca = marcas.IdMarca,
                                                  NombreMarca = marcas.NombreMarca,
                                                  ImagenMarca = marcas.ImagenMarca
                                               });
            return entity;
        }

        public async Task<bool> Insert(Marca entity)
        {
            if (entity == null)
            {
                return false;
            }

            try
            {
                await _context.Marcas.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<bool> Update(Marca entity)
        {
            if (entity == null)
            {
                return false;
            }

            try
            {
                await Task.FromResult(_context.Marcas.Update(entity));
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
