namespace ADP.API.Model.DTOs.Balcan
{
    public class PermisoAccionDTO
    {
        public int IdVista { get; set; }
        public bool Consultar { get; set; }
        public bool Agregar { get; set; }
        public bool Actualizar { get; set; }
        public bool Borrar { get; set; }
        public bool Autorizar { get; set; }
    }
}