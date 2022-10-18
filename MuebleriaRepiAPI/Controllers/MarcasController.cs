using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuebleriaRepiAPI.DTO;
using MuebleriaRepiAPI.Interfaces;
using MuebleriaRepiAPI.Models;
using MuebleriaRepiAPI.Models.DTO;

namespace MuebleriaRepiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasController : ControllerBase
    {
        private readonly IDataRepository<Marca, MarcaDTO> _context;

        public MarcasController(IDataRepository<Marca, MarcaDTO> context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetMarcasDTO()
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
        public async Task<IActionResult> InsertMarcas(Marca entity)
        {
            try
            {
                var response = await _context.Insert(entity);
                if (response)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "La Marca fue agregada correctamente" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "Error al agregar la Marca" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al agregar la Marca" });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteMarcas(int? id)
        {
            try
            {
                var response = await _context.Delete(id);
                if (response)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "La Marca fue eliminada correctamente" });
                }

                else
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "La Marca no pudo ser borrada, borre los productos que la utilizan" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "La Marca no pudo ser borrada" });

            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMarcas(Marca entity)
        {
            try
            {
                var response = await _context.Update(entity);
                if (response)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Marca actualizado correctamente" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "La Marca no se pudo actualizar correctamente" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "La Marca no se pudo actualizar correctamente" });
            }
        }

    }
}
