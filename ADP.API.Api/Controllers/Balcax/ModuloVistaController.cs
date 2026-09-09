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

        [HttpGet("{idModulo}/vista")]
        public IActionResult GetByModuleId(int idModulo)
        {
            var vista = _vistaService.GetByModuleId(idModulo);
            return new JsonResult(new ResponseModel<object>
            {
                Success = true,
                Message = "Vistas del módulo obtenidas correctamente",
                Data = vista
            });
        }

        [HttpPost("{idModulo}/asociar-vista")]
        public IActionResult AddViewToModule([FromBody] ModuloVistaDTO dto)
        {
            var vista = _vistaService.AddViewToModule(dto);
            return new JsonResult(new ResponseModel<object>
            {
                Success = true,
                Message = "Vista asociada correctamente al módulo",
                Data = vista
            });
        }

        [HttpPost("{idModulo}/remover-vista")]
        public IActionResult DeleteViewFromModule([FromBody] ModuloVistaDTO dto)
        {
            var vista = _vistaService.DeleteViewFromModule(dto);
            return new JsonResult(new ResponseModel<object>
            {
                Success = true,
                Message = "Vista eliminada del módulo correctamente",
                Data = vista
            });
        }
    }
}