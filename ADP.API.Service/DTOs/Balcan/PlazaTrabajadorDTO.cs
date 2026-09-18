/**
 *
 * @author Hector Valencia
 * @email hvalenciah@aguapuebla.mx
 *
 */

namespace ADP.API.Service.DTOs.Balcan
{
    public class PlazaTrabajadorDTO
    {
        public int Id { get; set; }
        public string? CodigoPlaza { get; set; }
        public string? CodigoTrabajador { get; set; }
        public string? Nombre { get; set; }
        public string? Paterno { get; set; }
        public string? Materno { get; set; }
        public DateOnly? FechaIngreso { get; set; }
        public DateOnly? FechaReIngreso { get; set; }
        public DateOnly? FechaBaja { get; set; }
        public string? CausaBaja { get; set; }
        public string? Estado { get; set; }
        public string? TipoEmpleado { get; set; }
        public int? SegmentoNegocio { get; set; }
        public int? CodigoPuesto { get; set; }
        public string? NombrePuesto { get; set; }
        public int? CodigoDepartamento { get; set; }
        public string? NombreDepartamento { get; set; }
        public int? CodigoGerencia { get; set; }
        public string? NombreGerencia { get; set; }
        public int? CodigoDireccion { get; set; }
        public string? NombreDireccion { get; set; }
    }
}