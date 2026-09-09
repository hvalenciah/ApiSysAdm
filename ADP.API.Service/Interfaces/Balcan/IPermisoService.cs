using ADP.API.Model.DTOs.Balcan;

namespace ADP.API.Service.Interfaces.Balcan
{
    public interface IPermisoService
    {
        Task<UsuarioPermisosDTO?> GetPermissionUserAsync(int idUsuario);
        Task<bool> SavePermissionUserAsync(GuardarPermisoDTO dto);
    }
}