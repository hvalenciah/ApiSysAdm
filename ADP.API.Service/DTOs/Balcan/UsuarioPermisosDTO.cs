namespace ADP.API.Model.DTOs.Balcan
{
    public class UsuarioPermisosDTO
    {
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public List<ModuloPermisoDTO> Modulos { get; set; } = new List<ModuloPermisoDTO>();
    }
}