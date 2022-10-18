using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuebleriaRepiAPI.Interfaces;
using MuebleriaRepiAPI.Models;

namespace MuebleriaRepiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReclamacionesController : ControllerBase
    {
        private readonly IDataRepositoryV2<Reclamacione> _context;

        public ReclamacionesController(IDataRepositoryV2<Reclamacione> _context)
        {
            this._context = _context;
        }


        [HttpGet]
        public async Task<IActionResult> GetReclamaciones()
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
        public async Task<IActionResult> InsertReclamaciones(Reclamacione entity)
        {
            try
            {
                var response = await _context.Insert(entity);
                if (response)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Reclamacion enviada correctamente" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "Error al enviar la reclamacion" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al enviar la reclamacion" });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteReclamaciones(int? id)
        {
            try
            {
                var response = await _context.Delete(id);
                if (response)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Reclamacion eliminada correctamente" });
                }

                else
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "La Reclamacion no pudo ser borrada" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "La Reclamacion no pudo ser borrada" });

            }
        }
    }
}
