/**
 *
 * @author Hector Valencia
 * @email hvalenciah@aguapuebla.mx
 *
 */

namespace ADP.API.Service.DTOs.Balcan
{
    public class VacacionesDTO
    {
        public int IdVacacionesActivas { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; } = null!;
        public int NumeroTrabajador { get; set; }
        public string? PeriodoVacacional { get; set; }
        public int DiasOtorgados { get; set; }
        public int? DiasGozados { get; set; }
        public int DiasPendientes { get; set; }
        public DateOnly Vigencia { get; set; }
        public bool Activo { get; set; }
    }
}