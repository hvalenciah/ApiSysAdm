using APD.API.Model.Entitites.Balcan;
using ADP.API.Service.DTOs.Balcan;

namespace ADP.API.Service.Mappers.Balcan
{
    public static class TrabajadorUsuarioMapper
    {
        public static TrabajadorUsuarioDTO ToDTO(
            Usuario usuario, 
            string? codigoTrabajador, 
            PlazaTrabajadorDTO? plazaTrabajador)
        {
            return new TrabajadorUsuarioDTO
            {
                // Atributos de Usuario
                IdUsuario = usuario.Id,
                Correo = usuario.Correo,
                Telefono = usuario.Telefono,
                Habilitado = usuario.Habilitado,

                // Atributos de Trabajador obtenidos de PlazaTrabajadorDTO
                CodigoTrabajador = codigoTrabajador ?? plazaTrabajador?.CodigoTrabajador,
                NombreTrabajador = plazaTrabajador?.Nombre,
                ApellidoPaterno = plazaTrabajador?.Paterno,
                ApellidoMaterno = plazaTrabajador?.Materno,
                FechaIngreso = plazaTrabajador?.FechaIngreso?.ToDateTime(TimeOnly.MinValue),
                Estado = plazaTrabajador?.Estado,
                TipoEmpleado = plazaTrabajador?.TipoEmpleado,
                
                CodigoPuesto = plazaTrabajador?.CodigoPuesto,
                NombrePuesto = plazaTrabajador?.NombrePuesto,
                
                CodigoDepartamento = plazaTrabajador?.CodigoDepartamento,
                NombreDepartamento = plazaTrabajador?.NombreDepartamento,
                
                CodigoGerencia = plazaTrabajador?.CodigoGerencia,
                NombreGerencia = plazaTrabajador?.NombreGerencia,
                
                CodigoDireccion = plazaTrabajador?.CodigoDireccion,
                NombreDireccion = plazaTrabajador?.NombreDireccion
            };
        }
    }
}