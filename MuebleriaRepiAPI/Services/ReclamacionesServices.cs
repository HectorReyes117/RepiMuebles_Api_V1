using MuebleriaRepiAPI.Interfaces;
using MuebleriaRepiAPI.Models;

namespace MuebleriaRepiAPI.Services
{
    public class ReclamacionesServices : IDataRepositoryV2<Reclamacione>
    {

        private readonly dbMuebleriaRepiContext _context;

        public ReclamacionesServices(dbMuebleriaRepiContext context)
        {
            _context = context;
        }

        public async Task<bool> Delete(int? id)
        {
            if (id == null)
            {
                return false;
            }
            try
            {
                var entidad = await _context.Reclamaciones.FindAsync(id);
                if (entidad == null)
                {
                    return false;
                }
                await Task.FromResult(_context.Reclamaciones.Remove(entidad));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<IEnumerable<Reclamacione>> GetAll()
        {
            var entity = await Task.FromResult(from reclamacion in _context.Reclamaciones
                                         select new Reclamacione
                                         {
                                            IdReclamaciones = reclamacion.IdReclamaciones,
                                            NumeroFactura = reclamacion.NumeroFactura,
                                            Producto = reclamacion.Producto,
                                            Sucursal = reclamacion.Sucursal, 
                                            Nombres = reclamacion.Nombres,
                                            Apellidos = reclamacion.Apellidos,
                                            Telefono = reclamacion.Telefono,
                                            Celular = reclamacion.Celular,
                                            Direccion = reclamacion.Direccion,
                                            Comentario = reclamacion.Comentario
                                        });

            return entity;
        }

        public async Task<bool> Insert(Reclamacione entity)
        {
            if (entity == null)
            {
                return false;
            }

            try
            {
                await _context.Reclamaciones.AddAsync(entity);
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
