using Microsoft.AspNetCore.Mvc;
using ADP.API.Service.Interfaces.Balcan;
using ADP.API.Service.DTOs.Balcan;
using ADP.API.Model.Model;

namespace ADP.API.Api.Controllers
{
    [ApiController]
    [Route("Balcan/[controller]")]
    public class ModuloVistaController : ControllerBase
    {
        private readonly IModuloVistaService _moduloVistaService;

        public ModuloVistaController(IModuloVistaService moduloVistaService)
        {
            _moduloVistaService = moduloVistaService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var modulos = _moduloVistaService.GetAll();

            return Ok(new ResponseModel<object>
            {
                Success = true,
                Message = "Módulos y sus vistas obtenidos correctamente",
                Data = modulos
            });
        }

        [HttpGet("{id_modulo}")]
        public IActionResult GetByModuleId(int id_modulo)
        {
            var moduloConVistas = _moduloVistaService.GetByModuleIdAsync(id_modulo);

            if (moduloConVistas == null)
            {
                return NotFound(new ResponseModel<object>
                {
                    Success = false,
                    Message = $"No se encontró el módulo con ID {id_modulo}",
                    Data = null
                });
            }

            return Ok(new ResponseModel<object>
            {
                Success = true,
                Message = "Vistas del módulo obtenidas correctamente",
                Data = moduloConVistas
            });
        }

        [HttpPost("create")]
        public IActionResult AddViewToModule([FromBody] ModuloVistaDTO dto)
        {
            var result = _moduloVistaService.AddViewToModuleAsync(dto);

            if (!result)
            {
                return BadRequest(new ResponseModel<object>
                {
                    Success = false,
                    Message = "No se pudo asociar la vista al módulo. Verifica los IDs de módulo y vista.",
                    Data = null
                });
            }

            return Ok(new ResponseModel<object>
            {
                Success = true,
                Message = "Vista asociada correctamente al módulo",
                Data = dto
            });
        }

        [HttpPost("update")]
        public IActionResult UpdateModuleViews([FromBody] ActualizarModuloVistasDTO dto)
        {
            var result = _moduloVistaService.UpdateModuleViewsAsync(dto);

            if (!result)
            {
                return BadRequest(new ResponseModel<object>
                {
                    Success = false,
                    Message = $"No se pudieron actualizar las vistas. Verifica que el módulo con ID {dto.IdModulo} exista.",
                    Data = null
                });
            }

            var moduloActualizado = _moduloVistaService.GetByModuleIdAsync(dto.IdModulo);

            return Ok(new ResponseModel<object>
            {
                Success = true,
                Message = "Relaciones del módulo con las vistas actualizadas correctamente",
                Data = moduloActualizado
            });
        }

        [HttpPost("delete")]
        public IActionResult DeleteViewFromModule([FromBody] ModuloVistaDTO dto)
        {
            var result = _moduloVistaService.DeleteViewFromModuleAsync(dto);

            if (!result)
            {
                return NotFound(new ResponseModel<object>
                {
                    Success = false,
                    Message = "No se encontró la vista asociada al módulo especificado.",
                    Data = null
                });
            }

            return Ok(new ResponseModel<object>
            {
                Success = true,
                Message = "Vista eliminada del módulo correctamente",
                Data = dto
            });
        }
    }
}