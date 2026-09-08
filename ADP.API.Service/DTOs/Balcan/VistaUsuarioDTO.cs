namespace ADP.API.Service.DTOs.Balcan
{
    public class VistaUsuarioDTO
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdVista { get; set; }
        public string? Nombre { get; set;}
        public bool Consultar { get; set; }
        public bool Agregar { get; set; }
        public bool Actualizar { get; set; }
        public bool Autorizar { get; set; }
        public bool Borrar { get; set; }
    }
}