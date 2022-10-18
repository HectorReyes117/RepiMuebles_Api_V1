using Microsoft.EntityFrameworkCore;
using MuebleriaRepiAPI.DTO;
using MuebleriaRepiAPI.Interfaces;
using MuebleriaRepiAPI.Models;
using MuebleriaRepiAPI.Models.DTO;

namespace MuebleriaRepiAPI.Services
{
    public class ProductoServices : IDataRepository<Producto, ProductoDTO>
    {
        private readonly dbMuebleriaRepiContext _context; 

        public ProductoServices(dbMuebleriaRepiContext _context)
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
                var entidad = await _context.Productos.FindAsync(id);
                if (entidad == null)
                {
                    return false;
                }
                await Task.FromResult(_context.Productos.Remove(entidad));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

      

        public async Task<bool> Insert(Producto entity)
        {
            if (entity == null)
            {
                return false;
            }
            
            try
            {
                 await _context.Productos.AddAsync(entity);
                 await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<bool> Update(Producto entity)
        {
            if (entity == null)
            {
                return false;
            }

            try
            {
                await Task.FromResult(_context.Productos.Update(entity));
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<IEnumerable<ProductoDTO>> GetAllDTO()
        {
            var entity = await Task.FromResult(from product in _context.Productos
                                               join categoria in _context.Categoria on product.IdCategoria equals categoria.IdCategoria
                                               join marca in _context.Marcas on product.IdMarca equals marca.IdMarca
                                               select new ProductoDTO
                                               {
                                                  IdProducto = product.IdProducto,
                                                  Nombre = product.Nombre,
                                                  Precio = product.Precio,
                                                  Imagen = product.Imagen,
                                                  IdCategoria = product.IdCategoria,
                                                  Descripcion = product.Descripcion,
                                                  Descuento = product.Descuento,
                                                  IdMarca = product.IdMarca,

                                                   IdCategoriaNavigation = new CategoriumDTO
                                                   {
                                                      IdCategoria = product.IdCategoriaNavigation.IdCategoria,
                                                      Categoria = product.IdCategoriaNavigation.Categoria
                                                   },
                                                   IdMarcaNavigation = new MarcaDTO
                                                  {
                                                      IdMarca = product.IdMarcaNavigation.IdMarca,
                                                      NombreMarca = product.IdMarcaNavigation.NombreMarca,
                                                      ImagenMarca = product.IdMarcaNavigation.ImagenMarca
                                                  }
                                               });
            return entity;
        } 
    }
}
