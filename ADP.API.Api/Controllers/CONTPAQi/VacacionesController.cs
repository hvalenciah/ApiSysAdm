using Microsoft.AspNetCore.Mvc;
using ADP.API.Service.Interfaces.Balcan;
using ADP.API.Service.DTOs.Balcan;
using ADP.API.Model.Model;

namespace ADP.API.Api.Controllers
{
    [ApiController]
    [Route("CONTPAQi/[controller]")]
    public class VacacionesController : ControllerBase
    {
        private readonly IVacacionesService _vacacionesService;

        public VacacionesController(IVacacionesService vacacionesService)
        {
            _vacacionesService = vacacionesService;
        }

        [HttpGet]
        public ActionResult<ResponseModel<List<VacacionesDTO>>> GetAll()
        {
            var data = _vacacionesService.GetAll();
            return Ok(new ResponseModel<List<VacacionesDTO>>
            {
                Success = true,
                Message = "Lista de periodos vacacionales obtenida exitosamente",
                Data = data
            });
        }

        [HttpGet("by-id/{id}")]
        public ActionResult<ResponseModel<VacacionesDTO>> GetById(int id)
        {
            var data = _vacacionesService.GetById(id);
            if (data == null)
            {
                return NotFound(new ResponseModel<VacacionesDTO>
                {
                    Success = false,
                    Message = $"No se encontró el registro de vacaciones con el ID: {id}",
                    Data = null
                });
            }

            return Ok(new ResponseModel<VacacionesDTO>
            {
                Success = true,
                Message = "Periodo vacacional obtenido exitosamente",
                Data = data
            });
        }

        [HttpGet("by-trabajador/{codigo_trabajador}")]
        public ActionResult<ResponseModel<List<VacacionesDTO>>> GetByNumeroTrabajador(int codigo_trabajador)
        {
            var data = _vacacionesService.GetByTrabajador(codigo_trabajador);
            return Ok(new ResponseModel<List<VacacionesDTO>>
            {
                Success = true,
                Message = $"Se encontraron {data.Count} periodo(s) vacacional(es) para el trabajador: {codigo_trabajador}",
                Data = data
            });
        }

        [HttpPost("update")]
        public ActionResult<ResponseModel<VacacionesDTO>> Update([FromBody] VacacionesDTO dto)
        {
            var data = _vacacionesService.Update(dto);
            if (data == null)
            {
                return NotFound(new ResponseModel<VacacionesDTO>
                {
                    Success = false,
                    Message = $"No se encontró el registro de vacaciones con ID: {dto.IdVacacionesActivas} para actualizar",
                    Data = null
                });
            }

            return Ok(new ResponseModel<VacacionesDTO>
            {
                Success = true,
                Message = "Registro de vacaciones actualizado exitosamente",
                Data = data
            });
        }
    }
}