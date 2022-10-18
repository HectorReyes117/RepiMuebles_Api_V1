using MuebleriaRepiAPI.Interfaces;
using MuebleriaRepiAPI.Models;

namespace MuebleriaRepiAPI.Services
{
    public class CompraServices : IDataRepositoryV2<FormularioCompra>
    {
        private readonly dbMuebleriaRepiContext _context;

        public CompraServices(dbMuebleriaRepiContext _context)
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
                var entidad = await _context.FormularioCompras.FindAsync(id);
                if (entidad == null)
                {
                    return false;
                }
                await Task.FromResult(_context.FormularioCompras.Remove(entidad));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<IEnumerable<FormularioCompra>> GetAll()
        {
            var entity = await Task.FromResult(from compra in _context.FormularioCompras
                                         select new FormularioCompra
                                         {
                                             IdFormularioCompra = compra.IdFormularioCompra,
                                             Nombre = compra.Nombre,
                                             Apellidos = compra.Apellidos,
                                             Cedula = compra.Cedula,
                                             Email = compra.Email,
                                             Telefono = compra.Telefono,
                                             Celular = compra.Celular,
                                             Sucursal = compra.Sucursal,
                                             Direccion = compra.Direccion,
                                             Producto = compra.Producto
                                         });
            return entity;
        }

        public async Task<bool> Insert(FormularioCompra entity)
        {
            if (entity == null)
            {
                return false;
            }

            try
            {
                await _context.FormularioCompras.AddAsync(entity);
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
