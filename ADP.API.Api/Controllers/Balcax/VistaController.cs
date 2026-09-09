using Microsoft.AspNetCore.Mvc;
using ADP.API.Service.Interfaces.Balcan;
using ADP.API.Service.DTOs.Balcan;
using ADP.API.Model.Model;

namespace ADP.API.Api.Controllers
{
    [ApiController]
    [Route("Balcan/[controller]")]
    public class VistaController : ControllerBase
    {
        private readonly IVistaService _vistaService;

        public VistaController(IVistaService vistaService)
        {
            _vistaService = vistaService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = _vistaService.GetAll();
            return new JsonResult(new ResponseModel<object>
            {
                Success = true,
                Message = "Lista de vistas obtenida exitosamente",
                Data = data
            });
        }

        [HttpGet("by-id/{id}")]
        public IActionResult GetById(int id)
        {
            var vista = _vistaService.GetById(id);
            if (vista == null)
            {
                return new JsonResult(new ResponseModel<object>
                {
                    Success = false,
                    Message = "Vista no encontrada",
                    Data = null
                });
            }

            return new JsonResult(new ResponseModel<object>
            {
                Success = true,
                Message = "Vista encontrada",
                Data = vista
            });
        }

        [HttpGet("by-name/{name}")]
        public IActionResult GetByName(string name)
        {
            var vista = _vistaService.GetByName(name);
            if (vista == null)
            {
                return new JsonResult(new ResponseModel<object>
                {
                    Success = false,
                    Message = "Vista no encontrada",
                    Data = null
                });
            }

            return new JsonResult(new ResponseModel<object>
            {
                Success = true,
                Message = "Vista encontrada",
                Data = vista
            });
        }

        [HttpGet("modulo/{id}")]
        public IActionResult GetByModuleId(int id)
        {
            var data = _vistaService.GetByModuleId(id);
            return new JsonResult(new ResponseModel<object>
            {
                Success = true,
                Message = $"Vistas del módulo {id}: {data.Count}",
                Data = data
            });
        }

        [HttpPost("create")]
        public IActionResult Add([FromBody] VistaDTO dto)
        {
            var created = _vistaService.Add(dto);
            return new JsonResult(new ResponseModel<object>
            {
                Success = true,
                Message = "Vista creada exitosamente",
                Data = created
            });
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] VistaDTO dto)
        {
            var result = _vistaService.Update(dto);
            if (!result)
            {
                return new JsonResult(new ResponseModel<object>
                {
                    Success = false,
                    Message = "Vista no encontrada para actualizar",
                    Data = null
                });
            }

            return new JsonResult(new ResponseModel<object>
            {
                Success = true,
                Message = "Vista actualizada correctamente",
                Data = dto
            });
        }

        [HttpPost("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var result = _vistaService.Delete(id);
            if (!result)
            {
                return new JsonResult(new ResponseModel<object>
                {
                    Success = false,
                    Message = "Vista no encontrada para eliminar",
                    Data = null
                });
            }

            return new JsonResult(new ResponseModel<object>
            {
                Success = true,
                Message = "Vista eliminada exitosamente",
                Data = null
            });
        }
    }
}