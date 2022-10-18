using MuebleriaRepiAPI.Interfaces;
using MuebleriaRepiAPI.Models;

namespace MuebleriaRepiAPI.Services
{
    public class SolicitarServices : IDataRepositoryV2<Solicitar>
    {

        private readonly dbMuebleriaRepiContext _context;

        public SolicitarServices(dbMuebleriaRepiContext _context)
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
                var entidad = await _context.Solicitars.FindAsync(id);
                if (entidad == null)
                {
                    return false;
                }
                await Task.FromResult(_context.Solicitars.Remove(entidad));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<IEnumerable<Solicitar>> GetAll()
        {
            var entity = await Task.FromResult(from solicitar in _context.Solicitars
                                         select new Solicitar
                                         {
                                             IdSolicitar = solicitar.IdSolicitar,
                                             Nombre = solicitar.Nombre,
                                            Apellidos = solicitar.Apellidos,
                                            Cedula = solicitar.Cedula,
                                            Edad = solicitar.Edad,
                                            ViviendaPropia = solicitar.ViviendaPropia,
                                            SectorVive = solicitar.SectorVive,
                                            ArticuloFinanciar = solicitar.ArticuloFinanciar,
                                            DondeSolicitarCredito = solicitar.DondeSolicitarCredito,
                                            CompraAnterior = solicitar.CompraAnterior,
                                            Telefono = solicitar.Telefono,
                                            Celular = solicitar.Celular,
                                            DondeTrabaja = solicitar.DondeTrabaja,
                                            Puestos = solicitar.Puestos,
                                            TiempoEmpresa = solicitar.TiempoEmpresa,
                                            TelefonoLabora = solicitar.TelefonoLabora,
                                            JefeInmediato = solicitar.JefeInmediato,
                                            Salario = solicitar.Salario,
                                            OtrosIngresos = solicitar.OtrosIngresos
                                         });
            return entity;
        }

        public async Task<bool> Insert(Solicitar entity)
        {
            if (entity == null)
            {
                return false;
            }

            try
            {
                await _context.Solicitars.AddAsync(entity);
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
