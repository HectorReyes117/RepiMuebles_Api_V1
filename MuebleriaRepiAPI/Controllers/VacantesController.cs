using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuebleriaRepiAPI.Interfaces;
using MuebleriaRepiAPI.Models;

namespace MuebleriaRepiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacantesController : ControllerBase
    {
        private readonly IDataRepositoryV3<Vacante> _context;

        public VacantesController(IDataRepositoryV3<Vacante> _context)
        {
           this._context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> GetVacante()
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
        public async Task<IActionResult> InsertVacante(Vacante entity)
        {
            try
            {
                var response = await _context.Insert(entity);
                if (response)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Vacante agregada correctamente" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "Error al agregar la vacante" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al agregar la vacante" });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteVacante(int? id)
        {
            try
            {
                var response = await _context.Delete(id);
                if (response)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Vacante eliminada correctamente" });
                }

                else
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "La Vacante no pudo ser borrada" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "La vacante no pudo ser borrada" });

            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVacante(Vacante entity)
        {
            try
            {
                var response = await _context.Update(entity);
                if (response)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Vacante actualizada correctamente" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "La vacante no se pudo actualizar correctamente" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "La Vacante no se pudo actualizar correctamente" });
            }
        }
    }
}
