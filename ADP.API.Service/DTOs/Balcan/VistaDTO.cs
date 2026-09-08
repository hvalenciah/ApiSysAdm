namespace ADP.API.Service.DTOs.Balcan
{
    public class VistaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string? Icon { get; set; }
        public string? RouterLink { get; set; }
        public int? IdModulo { get; set; }
        public string? ModuloNombre { get; set; }
        public int? IdVistaPadre { get; set; }
        public int Nivel { get; set; }
        public bool Visible { get; set; }
    }
}