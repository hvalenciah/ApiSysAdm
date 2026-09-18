using Microsoft.AspNetCore.Mvc;
using ADP.API.Service.Interfaces.Balcan;
using ADP.API.Service.DTOs.Balcan;
using ADP.API.Model.Model;

namespace ADP.API.Api.Controllers
{
    [ApiController]
    [Route("CONTPAQi/[controller]")]
    public class TrabajadorController : ControllerBase
    {
        private readonly ITrabajadorService _trabajadorService;

        public TrabajadorController(ITrabajadorService trabajadorService)
        {
            _trabajadorService = trabajadorService;
        }

        [HttpGet]
        public ActionResult<ResponseModel<List<TrabajadorDTO>>> GetAll()
        {
            var data = _trabajadorService.GetAll();
            return Ok(new ResponseModel<List<TrabajadorDTO>>
            {
                Success = true,
                Message = "Lista de trabajadores obtenida exitosamente",
                Data = data
            });
        }

        [HttpGet("by-id/{id}")]
        public ActionResult<ResponseModel<TrabajadorDTO>> GetById(int id)
        {
            var data = _trabajadorService.GetById(id);
            if (data == null)
            {
                return NotFound(new ResponseModel<TrabajadorDTO>
                {
                    Success = false,
                    Message = $"No se encontró el trabajador con el ID: {id}",
                    Data = null
                });
            }

            return Ok(new ResponseModel<TrabajadorDTO>
            {
                Success = true,
                Message = "Trabajador obtenido exitosamente",
                Data = data
            });
        }

        [HttpGet("by-code/{codigo_trabajador}")]
        public ActionResult<ResponseModel<TrabajadorDTO>> GetByCode(string codigo_trabajador)
        {
            var data = _trabajadorService.GetByCode(codigo_trabajador);
            if (data == null)
            {
                return NotFound(new ResponseModel<TrabajadorDTO>
                {
                    Success = false,
                    Message = $"No se encontró el trabajador con el código: {codigo_trabajador}",
                    Data = null
                });
            }

            return Ok(new ResponseModel<TrabajadorDTO>
            {
                Success = true,
                Message = "Trabajador obtenido exitosamente",
                Data = data
            });
        }

        [HttpGet("by-fullname/{nombrecompleto_trabajador}")]
        public ActionResult<ResponseModel<List<TrabajadorDTO>>> GetByFullName(string nombrecompleto_trabajador)
        {
            var data = _trabajadorService.GetByFullName(nombrecompleto_trabajador);
            return Ok(new ResponseModel<List<TrabajadorDTO>>
            {
                Success = true,
                Message = $"Se encontraron {data.Count} trabajador(es) con el nombre especificado",
                Data = data
            });
        }
    }
}