using ADP.API.Model.DTOs.Balcan;

namespace ADP.API.Service.Interfaces.Balcan
{
    public interface IPermisoService
    {
        Task<UsuarioPermisosDTO?> GetPermission(int idUsuario);
        Task<bool> SavePermission(GuardarPermisoDTO dto);
    }
}