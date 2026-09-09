using Microsoft.AspNetCore.Mvc;
using ADP.API.Service.Interfaces.Balcan;
using ADP.API.Service.DTOs.Balcan;
using ADP.API.Model.Model;

namespace ADP.API.Api.Controllers
{
    [ApiController]
    [Route("Balcan/[controller]")]
    public class ModuloController : ControllerBase
    {
        private readonly IModuloService _moduloService;

        public ModuloController(IModuloService moduloService)
        {
            _moduloService = moduloService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = _moduloService.GetAll();
            return new JsonResult(new ResponseModel<object>
            {
                Success = true,
                Message = "Lista de módulos obtenida exitosamente",
                Data = data
            });
        }

        [HttpGet("by-id/{id}")]
        public IActionResult GetById(int id)
        {
            var modulo = _moduloService.GetById(id);
            if (modulo == null)
            {
                return new JsonResult(new ResponseModel<object>
                {
                    Success = false,
                    Message = "Módulo no encontrado",
                    Data = null
                });
            }

            return new JsonResult(new ResponseModel<object>
            {
                Success = true,
                Message = "Módulo encontrado",
                Data = modulo
            });
        }

        [HttpGet("by-name/{name}")]
        public IActionResult GetByName(string name)
        {
            var modulo = _moduloService.GetByName(name);
            if (modulo == null)
            {
                return new JsonResult(new ResponseModel<object>
                {
                    Success = false,
                    Message = "Módulo no encontrado",
                    Data = null
                });
            }

            return new JsonResult(new ResponseModel<object>
            {
                Success = true,
                Message = "Módulo encontrado",
                Data = modulo
            });
        }

        [HttpPost("create")]
        public IActionResult Add([FromBody] ModuloDTO dto)
        {
            var created = _moduloService.Add(dto);
            return new JsonResult(new ResponseModel<object>
            {
                Success = true,
                Message = "Módulo creado exitosamente",
                Data = created
            });
        }

        [HttpPost("update")]
        public IActionResult Update([FromBody] ModuloDTO dto)
        {
            var result = _moduloService.Update(dto);
            if (!result)
            {
                return new JsonResult(new ResponseModel<object>
                {
                    Success = false,
                    Message = "Módulo no encontrado para actualizar",
                    Data = null
                });
            }

            return new JsonResult(new ResponseModel<object>
            {
                Success = true,
                Message = "Módulo actualizado correctamente",
                Data = dto
            });
        }

        [HttpPost("delete")]
        public IActionResult Delete([FromBody] int id)
        {
            var result = _moduloService.Delete(id);
            if (!result)
            {
                return new JsonResult(new ResponseModel<object>
                {
                    Success = false,
                    Message = "Módulo no encontrado para eliminar",
                    Data = null
                });
            }

            return new JsonResult(new ResponseModel<object>
            {
                Success = true,
                Message = "Módulo eliminado exitosamente",
                Data = null
            });
        }
    }
}