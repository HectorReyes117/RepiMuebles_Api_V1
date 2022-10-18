using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuebleriaRepiAPI.Interfaces;
using MuebleriaRepiAPI.Models;

namespace MuebleriaRepiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitarEmpleadoController : ControllerBase
    {
        private readonly IDataRepositoryV2<SolicitudEmpleado> _context;

        public SolicitarEmpleadoController(IDataRepositoryV2<SolicitudEmpleado> _context)
        {
            this._context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> GetSolicitar()
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
        public async Task<IActionResult> InsertSolicitar(SolicitudEmpleado entity)
        {
            try
            {
                var response = await _context.Insert(entity);
                if (response)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Solicitud enviada correctamente" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "Error al enviar la Solicitud" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al enviar la Solicitud" });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSolicitar(int? id)
        {
            try
            {
                var response = await _context.Delete(id);
                if (response)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Solicitud eliminada correctamente" });
                }

                else
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "La Solicitud no pudo ser borrada" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "La Solicitud no pudo ser borrada" });

            }
        }
    }
}
