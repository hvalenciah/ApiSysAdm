using Microsoft.AspNetCore.Mvc;
using ADP.API.Service.Interfaces.Balcan;
using ADP.API.Service.DTOs.Balcan;
using ADP.API.Model.Model;

namespace ADP.API.Api.Controllers
{
    [ApiController]
    [Route("Balcan/[controller]")]
    public class TrabajadorUsuarioController : ControllerBase
    {
        private readonly ITrabajadorUsuarioService _trabajadorUsuarioService;

        public TrabajadorUsuarioController(ITrabajadorUsuarioService trabajadorUsuarioService)
        {
            _trabajadorUsuarioService = trabajadorUsuarioService;
        }

        // GET: /Balcan/TrabajadorUsuario
        [HttpGet]
        public ActionResult<ResponseModel<List<TrabajadorUsuarioDTO>>> Index()
        {
            var data = _trabajadorUsuarioService.GetAll();
            return Ok(new ResponseModel<List<TrabajadorUsuarioDTO>>
            {
                Success = true,
                Message = "Lista de TrabajadorUsuario obtenida exitosamente",
                Data = data
            });
        }

        // GET: /Balcan/TrabajadorUsuario/Usuario/{id}
        [HttpGet("Usuario/{id:int}")]
        public ActionResult<ResponseModel<TrabajadorUsuarioDTO>> GetByIdUsuario(int id)
        {
            var user = _trabajadorUsuarioService.GetByIdUsuario(id);
            if (user == null)
            {
                return NotFound(new ResponseModel<TrabajadorUsuarioDTO>
                {
                    Success = false,
                    Message = "TrabajadorUsuario no encontrado para el usuario especificado",
                    Data = null
                });
            }

            return Ok(new ResponseModel<TrabajadorUsuarioDTO>
            {
                Success = true,
                Message = "TrabajadorUsuario encontrado exitosamente",
                Data = user
            });
        }

        // GET: /Balcan/TrabajadorUsuario/Trabajador/{codigo_trabajador}
        [HttpGet("Trabajador/{codigo_trabajador}")]
        public ActionResult<ResponseModel<TrabajadorUsuarioDTO>> GetByCodeTrabajador(string codigo_trabajador)
        {
            var user = _trabajadorUsuarioService.GetByCodeTrabajador(codigo_trabajador);
            if (user == null)
            {
                return NotFound(new ResponseModel<TrabajadorUsuarioDTO>
                {
                    Success = false,
                    Message = "TrabajadorUsuario no encontrado para el código de trabajador especificado",
                    Data = null
                });
            }

            return Ok(new ResponseModel<TrabajadorUsuarioDTO>
            {
                Success = true,
                Message = "TrabajadorUsuario encontrado exitosamente",
                Data = user
            });
        }
    }
}