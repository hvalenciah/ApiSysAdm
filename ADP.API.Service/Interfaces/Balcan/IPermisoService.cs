using ADP.API.Model.DTOs;

namespace ADP.API.Service.Interfaces.Balcan
{
    public interface IPermisoService
    {
        Task<UsuarioPermisosDTO?> GetPermisosPorUsuarioAsync(int idUsuario);
        Task<bool> GuardarPermisosUsuarioAsync(GuardarPermisoDTO dto);
    }
}