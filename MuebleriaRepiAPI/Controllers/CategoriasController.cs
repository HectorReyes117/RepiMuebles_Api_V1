using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuebleriaRepiAPI.Interfaces;
using MuebleriaRepiAPI.Models;
using MuebleriaRepiAPI.Models.DTO;

namespace MuebleriaRepiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly IDataRepository<Categorium, CategoriumDTO> _context;

        public CategoriasController(IDataRepository<Categorium, CategoriumDTO> context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriasDTO()
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
        public async Task<IActionResult> InsertCategoria(Categorium entity)
        {
            try
            {
                var response = await _context.Insert(entity);
                if (response)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Categoria agregado correctamente" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "Error al agregar la Categoria" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al agregar la Categoria" });
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategoria(int? id)
        {
            try
            {
                var response = await _context.Delete(id);
                if (response)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Categoria eliminada correctamente" });
                }

                else
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "La categoria no pudo ser borrado, borre los productos que la utilizan"});
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "La Categoria no pudo ser borrada" });

            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategoria(Categorium entity)
        {
            try
            {
                var response = await _context.Update(entity);
                if (response)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Categoria actualizada correctamente" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "La Categoria no se pudo actualizar correctamente" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "La Categoria no se pudo actualizar correctamente" });
            }
        }
    }
}
