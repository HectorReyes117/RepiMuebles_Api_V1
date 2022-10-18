using MuebleriaRepiAPI.Interfaces;
using MuebleriaRepiAPI.Models;

namespace MuebleriaRepiAPI.Services
{
    public class VacanteServices:IDataRepositoryV3<Vacante>
    {
        private readonly dbMuebleriaRepiContext _context;

        public VacanteServices(dbMuebleriaRepiContext _context)
        {
            this._context = _context;
        }

        public async Task<bool> Delete(int? id)
        {
            if (id == null)
            {
                return false;
            }
            try
            {
                var entidad = await _context.Vacantes.FindAsync(id);
                if (entidad == null)
                {
                    return false;
                }
                await Task.FromResult(_context.Vacantes.Remove(entidad));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<IEnumerable<Vacante>> GetAllDTO()
        {
            var entity = await Task.FromResult(from vacante in _context.Vacantes
                                               select new Vacante
                                               {
                                                   IdVacantes = vacante.IdVacantes,
                                                   Posicion = vacante.Posicion,
                                                   DescripciónPuesto = vacante.DescripciónPuesto,
                                                   EstimacionSalarial = vacante.EstimacionSalarial,
                                                   Sucursal = vacante.Sucursal
                                               });
            return entity;
        }

        public async Task<bool> Insert(Vacante entity)
        {
            if (entity == null)
            {
                return false;
            }

            try
            {
                await _context.Vacantes.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<bool> Update(Vacante entity)
        {
            if (entity == null)
            {
                return false;
            }

            try
            {
                await Task.FromResult(_context.Vacantes.Update(entity));
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
