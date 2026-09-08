namespace ADP.API.Model.DTOs
{
    public class PermisoNodoDTO
    {
        public int Id { get; set; }
        public int? IdVistaPadre { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public bool IsChecked { get; set; }
        public List<PermisoNodoDTO> Hijos { get; set; } = new List<PermisoNodoDTO>();
    }
}