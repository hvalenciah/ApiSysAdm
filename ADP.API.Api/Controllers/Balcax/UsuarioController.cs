using Microsoft.AspNetCore.Mvc;
using ADP.API.Service.Interfaces.Balcan;
using ADP.API.Service.DTOs.Balcan;
using ADP.API.Model.Model;

namespace ADP.API.Api.Controllers
{
    [ApiController]
    [Route("Balcan/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _UsuarioService;

        public UsuarioController(IUsuarioService UsuarioService)
        {
            _UsuarioService = UsuarioService;
        }

        [HttpGet]
        public ActionResult<ResponseModel<object>> Index()
        {
            var data = _UsuarioService.GetAll();
            return Ok(new ResponseModel<object>
            {
                Success = true,
                Message = "Lista de usuarios obtenida exitosamente",
                Data = data
            });
        }

        [HttpGet("by-id/{id}")]
        public ActionResult<ResponseModel<object>> GetById(int id)
        {
            var user = _UsuarioService.GetById(id);
            if (user == null)
            {
                return NotFound(new ResponseModel<object>
                {
                    Success = false,
                    Message = "Usuario no encontrado",
                    Data = null
                });
            }

            return Ok(new ResponseModel<object>
            {
                Success = true,
                Message = "Usuario encontrado",
                Data = user
            });
        }

        [HttpGet("by-name/{name}")]
        public ActionResult<ResponseModel<object>> GetByName(string name)
        {
            var users = _UsuarioService.GetByName(name);
            return Ok(new ResponseModel<object>
            {
                Success = true,
                Message = $"Se encontraron {users.Count} coincidencias por nombre",
                Data = users
            });
        }

        [HttpGet("by-lastname/{lastname}")]
        public ActionResult<ResponseModel<object>> GetByLastName(string lastname)
        {
            var users = _UsuarioService.GetByLastName(lastname);
            return Ok(new ResponseModel<object>
            {
                Success = true,
                Message = $"Se encontraron {users.Count} coincidencias por apellido",
                Data = users
            });
        }

        [HttpGet("by-email/{email}")]
        public ActionResult<ResponseModel<object>> GetByEmail(string email)
        {
            var user = _UsuarioService.GetByEmail(email);
            if (user == null)
            {
                return NotFound(new ResponseModel<object>
                {
                    Success = false,
                    Message = "Usuario no encontrado",
                    Data = null
                });
            }

            return Ok(new ResponseModel<object>
            {
                Success = true,
                Message = "Usuario encontrado",
                Data = user
            });
        }

        [HttpGet("by-phone/{phone}")]
        public ActionResult<ResponseModel<object>> GetByPhone(string phone)
        {
            var user = _UsuarioService.GetByPhone(phone);
            if (user == null)
            {
                return NotFound(new ResponseModel<object>
                {
                    Success = false,
                    Message = "Usuario no encontrado",
                    Data = null
                });
            }

            return Ok(new ResponseModel<object>
            {
                Success = true,
                Message = "Usuario encontrado",
                Data = user
            });
        }

        [HttpPost("create")]
        public ActionResult<ResponseModel<object>> Add([FromBody] UsuarioDTO dto)
        {
            var createdUser = _UsuarioService.Add(dto);

            return CreatedAtAction(
                nameof(GetById), 
                new { id = createdUser.Id }, 
                new ResponseModel<object>
                {
                    Success = true,
                    Message = "Usuario creado exitosamente",
                    Data = createdUser
                }
            );
        }

        [HttpPost("update")]
        public ActionResult<ResponseModel<object>> Update([FromBody] UsuarioDTO dto)
        {
            var result = _UsuarioService.Update(dto);
            if (!result)
            {
                return NotFound(new ResponseModel<object>
                {
                    Success = false,
                    Message = "Usuario no encontrado para actualizar",
                    Data = null
                });
            }

            return Ok(new ResponseModel<object>
            {
                Success = true,
                Message = "Usuario actualizado correctamente",
                Data = dto
            });
        }

        [HttpPost("delete/{id}")]
        public ActionResult<ResponseModel<object>> Delete(int id)
        {
            var result = _UsuarioService.Delete(id);
            if (!result)
            {
                return NotFound(new ResponseModel<object>
                {
                    Success = false,
                    Message = "Usuario no encontrado para eliminar",
                    Data = null
                });
            }

            return Ok(new ResponseModel<object>
            {
                Success = true,
                Message = "Usuario eliminado exitosamente",
                Data = null
            });
        }

        [HttpGet("search/{t}")]
        public ActionResult<ResponseModel<object>> Search(string t)
        {
            var user = _UsuarioService.Search(t);
            if (user == null)
            {
                return NotFound(new ResponseModel<object>
                {
                    Success = false,
                    Message = "Usuario no encontrado",
                    Data = null
                });
            }

            return Ok(new ResponseModel<object>
            {
                Success = true,
                Message = "Usuario encontrado",
                Data = user
            });
        }
    }
}