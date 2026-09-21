using Microsoft.AspNetCore.Mvc;
using ADP.API.Service.Interfaces.Balcan;
using ADP.API.Service.DTOs.Balcan;
using ADP.API.Model.Model;

namespace ADP.API.Api.Controllers
{
    [ApiController]
    [Route("CONTPAQi/[controller]")]
    public class PlazaTrabajadorController : ControllerBase
    {
        private readonly IPlazaTrabajadorService _plazaTrabajadorService;

        public PlazaTrabajadorController(IPlazaTrabajadorService plazaTrabajadorService)
        {
            _plazaTrabajadorService = plazaTrabajadorService;
        }

        [HttpGet]
        public ActionResult<ResponseModel<List<PlazaTrabajadorDTO>>> GetAll()
        {
            var data = _plazaTrabajadorService.GetAll();
            return Ok(new ResponseModel<List<PlazaTrabajadorDTO>>
            {
                Success = true,
                Message = "Lista de plazas y trabajadores obtenida exitosamente",
                Data = data
            });
        }

        [HttpGet("by-id/{id}")]
        public ActionResult<ResponseModel<PlazaTrabajadorDTO>> GetById(int id)
        {
            var data = _plazaTrabajadorService.GetById(id);
            if (data == null)
            {
                return NotFound(new ResponseModel<PlazaTrabajadorDTO>
                {
                    Success = false,
                    Message = $"No se encontró la plaza con el ID: {id}",
                    Data = null
                });
            }

            return Ok(new ResponseModel<PlazaTrabajadorDTO>
            {
                Success = true,
                Message = "Plaza obtenida exitosamente",
                Data = data
            });
        }

        [HttpGet("by-plaza/{codigo_plaza}")]
        public ActionResult<ResponseModel<PlazaTrabajadorDTO>> GetByPlaza(string codigo_plaza)
        {
            var data = _plazaTrabajadorService.GetByPlaza(codigo_plaza);
            if (data == null)
            {
                return NotFound(new ResponseModel<PlazaTrabajadorDTO>
                {
                    Success = false,
                    Message = $"No se encontró registro para el código de plaza: {codigo_plaza}",
                    Data = null
                });
            }

            return Ok(new ResponseModel<PlazaTrabajadorDTO>
            {
                Success = true,
                Message = "Registro obtenido exitosamente",
                Data = data
            });
        }

        [HttpGet("by-trabajador/{codigo_trabajador}")]
        public ActionResult<ResponseModel<PlazaTrabajadorDTO>> GetByTrabajador(string codigo_trabajador)
        {
            var data = _plazaTrabajadorService.GetByTrabajador(codigo_trabajador);
            if (data == null)
            {
                return NotFound(new ResponseModel<PlazaTrabajadorDTO>
                {
                    Success = false,
                    Message = $"No se encontró registro para el código de trabajador: {codigo_trabajador}",
                    Data = null
                });
            }

            return Ok(new ResponseModel<PlazaTrabajadorDTO>
            {
                Success = true,
                Message = "Registro obtenido exitosamente",
                Data = data
            });
        }

        [HttpGet("by-fullname/{name}")]
        public ActionResult<ResponseModel<List<PlazaTrabajadorDTO>>> GetByFullName(string name)
        {
            var data = _plazaTrabajadorService.GetByFullName(name);
            return Ok(new ResponseModel<List<PlazaTrabajadorDTO>>
            {
                Success = true,
                Message = $"Se encontraron {data.Count} registro(s) con el nombre especificado",
                Data = data
            });
        }
    }
}