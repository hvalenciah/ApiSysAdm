namespace ADP.API.Model.DTOs
{
    public class ModuloPermisoDTO
    {
        public int IdModulo { get; set; }
        public string NombreModulo { get; set; } = string.Empty;
        public List<PermisoNodoDTO> Vistas { get; set; } = new List<PermisoNodoDTO>();
    }
}