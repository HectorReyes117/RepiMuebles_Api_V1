using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuebleriaRepiAPI.Interfaces;
using MuebleriaRepiAPI.Models;

namespace MuebleriaRepiAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrarController : ControllerBase
    {
        private readonly IRegistrar<Registrar,Login> _context;

        public RegistrarController(IRegistrar<Registrar,Login> context)
        {
            _context = context;
        }


        [HttpPost]
        public async Task<IActionResult> Validar(Login entity)
        {
            try
            {
                var response = await _context.Validar(entity);

                if (response)
                {
                    return StatusCode(StatusCodes.Status200OK, new { usuario = await _context.Get(entity) });
                }
                else
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "Error al iniciar sesion" });
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al iniciar sesion" });
            }
        }


        [HttpPost("Insert")]
        public async Task<IActionResult> InsertRegistrar(Registrar entity)
        {
            try
            {
                string email = entity.Email;
                var response1 = await _context.Validar2(email);
                if (response1)
                {
                    return StatusCode(StatusCodes.Status200OK, new { message = "Ya tiene una cuenta inicie sesion" });
                }
                else
                {
                    var response = await _context.Insert(entity);
                    if (response)
                    {
                        return StatusCode(StatusCodes.Status200OK, new { message = "Cuenta creada correctamente" });
                    }
                    else
                    {
                        return StatusCode(StatusCodes.Status406NotAcceptable, new { message = "Error al crear la cuenta" });
                    }           
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error al crear la cuenta" });
            }
        }


    }
}
