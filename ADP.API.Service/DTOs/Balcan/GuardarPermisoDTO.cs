namespace ADP.API.Model.DTOs.Balcan
{
    public class GuardarPermisoDTO
    {
        public int IdUsuario { get; set; }
        public List<PermisoAccionDTO> Permisos { get; set; } = new List<PermisoAccionDTO>();
    }
}