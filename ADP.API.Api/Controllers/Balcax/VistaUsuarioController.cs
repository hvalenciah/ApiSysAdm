using Microsoft.AspNetCore.Mvc;
using ADP.API.Service.Interfaces.Balcan;
using ADP.API.Service.DTOs.Balcan;
using ADP.API.Model.Model;

namespace ADP.API.Api.Controllers
{
    [ApiController]
    [Route("Balcan/[controller]")]
    public class VistaUsuarioController : ControllerBase
    {
        private readonly IVistaUsuarioService _vistaUsuarioService;

        public VistaUsuarioController(IVistaUsuarioService vistaUsuarioService)
        {
            _vistaUsuarioService = vistaUsuarioService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = _vistaUsuarioService.GetAll();
            return new JsonResult(new ResponseModel<object>
            {
                Success = true,
                Message = "Lista de permisos por usuario obtenida exitosamente",
                Data = data
            });
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var item = _vistaUsuarioService.GetById(id);
            if (item == null)
            {
                return new JsonResult(new ResponseModel<object>
                {
                    Success = false,
                    Message = "Permiso no encontrado",
                    Data = null
                });
            }

            return new JsonResult(new ResponseModel<object>
            {
                Success = true,
                Message = "Permiso encontrado",
                Data = item
            });
        }

        [HttpGet("usuario/{id}")]
        public IActionResult GetByUserId(int id)
        {
            var data = _vistaUsuarioService.GetByUserId(id);

            return new JsonResult(new ResponseModel<object>
            {
                Success = true,
                Message = $"Permisos del usuario {id} obtenidos exitosamente",
                Data = data
            });
        }

        [HttpPost("create")]
        public IActionResult Add([FromBody] VistaUsuarioDTO dto)
        {
            var created = _vistaUsuarioService.Add(dto);
            return new JsonResult(new ResponseModel<object>
            {
                Success = true,
                Message = "Permiso asignado exitosamente",
                Data = created
            });
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] VistaUsuarioDTO dto)
        {
            var result = _vistaUsuarioService.Update(dto);
            if (!result)
            {
                return new JsonResult(new ResponseModel<object>
                {
                    Success = false,
                    Message = "Permiso no encontrado para actualizar",
                    Data = null
                });
            }

            return new JsonResult(new ResponseModel<object>
            {
                Success = true,
                Message = "Permiso actualizado correctamente",
                Data = dto
            });
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromBody] int id)
        {
            var result = _vistaUsuarioService.Delete(id);
            if (!result)
            {
                return new JsonResult(new ResponseModel<object>
                {
                    Success = false,
                    Message = "Permiso no encontrado para eliminar",
                    Data = null
                });
            }

            return new JsonResult(new ResponseModel<object>
            {
                Success = true,
                Message = "Permiso eliminado exitosamente",
                Data = null
            });
        }
    }
}