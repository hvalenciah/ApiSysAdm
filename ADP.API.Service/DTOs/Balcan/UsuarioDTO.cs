/**
 *
 * @author Hector Valencia
 * @email hvalenciah@aguapuebla.mx
 *
 */

namespace ADP.API.Service.DTOs.Balcan
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string? Telefono { get; set; }
        public bool Habilitado { get; set; }
        public string? Token { get; set; }
        public string? Contrasena { get; set; }
        public string? Avatar { get; set; }
        public int IdEmpresa { get; set; }
        public DateTime Registrado { get; set; }
        public DateTime? UsuarioFechaCreacion { get; set; }
        public DateTime? UsuarioFechaActualizacion { get; set; }
        public DateTime? UsuarioFechaEliminacion { get; set; }
        public int? UsuarioFkModificado { get; set; }
    }
}