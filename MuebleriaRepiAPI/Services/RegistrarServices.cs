using MuebleriaRepiAPI.Interfaces;
using MuebleriaRepiAPI.Models;
using System.Linq;

namespace MuebleriaRepiAPI.Services
{
    public class RegistrarServices : IRegistrar<Registrar,Login>
    {
        private readonly dbMuebleriaRepiContext _context;

        public RegistrarServices(dbMuebleriaRepiContext _context)
        {
            this._context = _context;
        }

        public async Task<IEnumerable<Registrar>> Get(Login login)
        {
            var entity = await Task.FromResult(from registrar in _context.Registrars.Where(element => element.Email == login.email && element.Contraseña == login.pass)
                                               select new Registrar
                                               {
                                                   Id = registrar.Id,
                                                   Nombre = registrar.Nombre,
                                                   Apellido = registrar.Apellido,
                                                   NombreUsuario = registrar.NombreUsuario,
                                                   Email = login.email,
                                                   Contraseña = registrar.Contraseña,
                                                   TipoUsuario = registrar.TipoUsuario
                                               });
            return entity;
        }

        public async Task<bool> Validar(Login login)
        {
            if (login == null)
            {
                return false;
            }

            var entity = await Task.FromResult((from registrar in _context.Registrars
                                                where registrar.Email == login.email && registrar.Contraseña == login.pass
                                                select registrar).FirstOrDefault());

            return entity == null ? false : true;
        }

        public async Task<bool> Insert(Registrar entity)
        {
            if (entity == null)
            {
                return false;
            }

            try
            {
                await _context.Registrars.AddAsync(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<bool> Validar2(string email)
        {
            if (email == null)
            {
                return false;
            }

            var entity = await Task.FromResult((from registrar in _context.Registrars
                                                where registrar.Email == email
                                                select registrar).FirstOrDefault());

            return entity == null ? false : true;
        }
    }
}
