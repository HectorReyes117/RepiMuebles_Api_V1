using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuebleriaRepiAPI.Interfaces;
using MuebleriaRepiAPI.Models;
using MuebleriaRepiAPI.Perfiles;

namespace MuebleriaRepiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly IDataRepositoryV2<FormularioCompra> _context;
        private readonly EnviarCorreo enviar;

        public CompraController(IDataRepositoryV2<FormularioCompra> _context, EnviarCorreo enviar)
        {
           this._context = _context;
            this.enviar = enviar;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompras()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, new { lista = await _context.GetAll() });
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { response = "No se pudieron obtener los datos" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> InsertCompras(FormularioCompra entity)
        {
            try
            {
                var response = await _context.Insert(entity);
                if (response)
                {
                    enviar.Enviar(entity.Nombre,entity.Cedula,entity.Producto,entity.Apellidos);
                    enviar.EnviarUsuario(entity.Producto, entity.Email);
                    return StatusCode(StatusCodes.Status200OK, new { message = "Compra enviada correctamente" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "Error al enviar la Compra" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al enviar la Compra" });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCompras(int? id)
        {
            
            try
            {
                var response = await _context.Delete(id);
                if (response)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Compra eliminada correctamente" });
                }

                else
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "La Compra no pudo ser borrada" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "La Compra no pudo ser borrada" });
            }
        }
    }
}
