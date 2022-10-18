using MuebleriaRepiAPI.Interfaces;
using MuebleriaRepiAPI.Models;

namespace MuebleriaRepiAPI.Services
{
    public class SolicitarEmpleadoServices : IDataRepositoryV2<SolicitudEmpleado>
    {
        private readonly dbMuebleriaRepiContext _context;

        public SolicitarEmpleadoServices(dbMuebleriaRepiContext _context)
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
                var entidad = await _context.SolicitudEmpleados.FindAsync(id);
                if (entidad == null)
                {
                    return false;
                }
                await Task.FromResult(_context.SolicitudEmpleados.Remove(entidad));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<IEnumerable<SolicitudEmpleado>> GetAll()
        {
            var entity = await Task.FromResult(from solicitar in _context.SolicitudEmpleados
                                               select new SolicitudEmpleado
                                               {
                                                   IdSolicitudEmp = solicitar.IdSolicitudEmp,
                                                   Nombre = solicitar.Nombre,
                                                   Apellidos = solicitar.Apellidos,
                                                   Cedula = solicitar.Cedula,
                                                   Email = solicitar.Email,
                                                   Telefono = solicitar.Telefono,
                                                   Celular = solicitar.Celular,
                                                   Edad = solicitar.Edad,
                                                   Genero = solicitar.Genero,
                                                   EstadoCivil = solicitar.EstadoCivil,
                                                   Nacionalidad = solicitar.Nacionalidad,
                                                   Direccion = solicitar.Direccion,
                                                   NivelAcademico = solicitar.NivelAcademico,
                                                   Estudios = solicitar.Estudios,
                                                   EstadoEstudio =  solicitar.EstadoEstudio,
                                                   Labora = solicitar.Labora,
                                                   ExperienciaLaboral = solicitar.ExperienciaLaboral,
                                                   AspiraciónSalarial = solicitar.AspiraciónSalarial,
                                                   Posicion = solicitar.Posicion,
                                                   Sucursal = solicitar.Sucursal,
                                                   Licencia = solicitar.Licencia
                                               });
            return entity;
        }

        public async Task<bool> Insert(SolicitudEmpleado entity)
        {
            if (entity == null)
            {
                return false;
            }

            try
            {
                await _context.SolicitudEmpleados.AddAsync(entity);
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
