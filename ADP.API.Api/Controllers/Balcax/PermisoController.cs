using ADP.API.Model.DTOs.Balcan;
using ADP.API.Model.Model;
using ADP.API.Service.Interfaces.Balcan;
using Microsoft.AspNetCore.Mvc;

namespace ADP.API.Api.Controllers
{
    [ApiController]
    [Route("Balcan/[controller]")]
    public class PermisoController : ControllerBase
    {
        private readonly IPermisoService _permisoService;

        public PermisoController(IPermisoService permisoService)
        {
            _permisoService = permisoService;
        }

        /// <summary>
        /// Obtiene el árbol de navegación (Módulos -> Vistas -> Permisos) para un usuario específico.
        /// </summary>
        /// <param name="id">ID del usuario a consultar</param>
        [HttpGet("usuario/{id}")]
        public async Task<IActionResult> GetPermissionUser(int idUsuario)
        {
            var data = await _permisoService.GetPermissionUserAsync(idUsuario);

            if (data == null)
            {
                return new JsonResult(new ResponseModel<UsuarioPermisosDTO>
                {
                    Success = false,
                    Message = $"El usuario con ID {idUsuario} no fue encontrado.",
                    Data = null
                });
            }

            return new JsonResult(new ResponseModel<UsuarioPermisosDTO>
            {
                Success = true,
                Message = "Permisos de usuario obtenidos exitosamente",
                Data = data
            });
        }

        /// <summary>
        /// Actualiza los permisos de un usuario.
        /// </summary>
        [HttpPost("save")]
        public async Task<IActionResult> SavePermissionUser([FromBody] GuardarPermisoDTO dto)
        {
            if (dto == null || dto.IdUsuario <= 0)
            {
                return new JsonResult(new ResponseModel<bool>
                {
                    Success = false,
                    Message = "Datos de entrada inválidos.",
                    Data = false
                });
            }

            var resultado = await _permisoService.SavePermissionUserAsync(dto);

            if (!resultado)
            {
                return new JsonResult(new ResponseModel<bool>
                {
                    Success = false,
                    Message = "No se pudieron guardar los permisos. Verifique que el usuario exista.",
                    Data = false
                });
            }

            return new JsonResult(new ResponseModel<bool>
            {
                Success = true,
                Message = "Permisos actualizados correctamente.",
                Data = true
            });
        }
    }
}