using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuebleriaRepiAPI.Interfaces;
using MuebleriaRepiAPI.Models;
using MuebleriaRepiAPI.Models.DTO;

namespace MuebleriaRepiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IDataRepository<Producto, ProductoDTO> _context;
        public ProductosController(IDataRepository<Producto, ProductoDTO> context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsDTO()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, new { lista = await _context.GetAllDTO() });
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { response = "No se pudieron obtener los datos" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertProduct(Producto entity)
        {
            try
            {
                var response = await _context.Insert(entity);
                if (response)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Producto agregado correctamente" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "Error al agregar el producto" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al agregar el producto" });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int? id)
        {
            try
            {
                var response = await _context.Delete(id);
                if (response)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Producto eliminado correctamente" });
                }

                else
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "El producto no pudo ser borrado" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "El producto no pudo ser borrado" });

            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(Producto entity)
        {
            try
            {
                var response = await _context.Update(entity);
                if (response)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Producto actualizado correctamente" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "El producto no se pudo actualizar correctamente" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "El producto no se pudo actualizar correctamente" });
            }
        }

       
    }
}
