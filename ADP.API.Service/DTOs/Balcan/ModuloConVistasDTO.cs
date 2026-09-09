namespace ADP.API.Service.DTOs.Balcan
{
    public class ModuloConVistasDTO
    {
        public int IdModulo { get; set; }
        public string NombreModulo { get; set; } = string.Empty;
        public List<VistaDetalleDTO> Vistas { get; set; } = new List<VistaDetalleDTO>();
    }
}