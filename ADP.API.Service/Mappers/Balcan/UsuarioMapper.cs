/**
 *
 * @author Hector Valencia
 * @email hvalenciah@aguapuebla.mx
 *
 */

using APD.API.Model.Entitites.Balcan;
using ADP.API.Service.DTOs.Balcan;

namespace ADP.API.Service.Mappers.Balcan
{
    public static class UsuarioMapper
    {
        public static UsuarioDTO ToDTO(Usuario entity)
        {
            return new UsuarioDTO
            {
                Id = entity.Id,
                Nombre = entity.Nombre.ToUpper(),
                Apellidos = entity.Apellidos.ToUpper(),
                Correo = entity.Correo.ToLower(),
                Telefono = entity.Telefono,
                Habilitado = entity.Habilitado,
                Token = entity.Token,
                Contrasena = entity.Contrasena,
                Avatar = entity.Avatar?.ToUpper(),
                IdEmpresa = entity.IdEmpresa,
                Registrado = entity.Registrado,
                UsuarioFechaCreacion = entity.UsuarioFechaCreacion,
                UsuarioFechaActualizacion = entity.UsuarioFechaActualizacion,
                UsuarioFechaEliminacion = entity.UsuarioFechaEliminacion,
                UsuarioFkModificado = entity.UsuarioFkModificado
            };
        }

        public static Usuario ToEntity(UsuarioDTO dto)
        {
            return new Usuario
            {
                Id = dto.Id,
                Nombre = dto.Nombre.ToUpper(),
                Apellidos = dto.Apellidos.ToUpper(),
                Correo = dto.Correo.ToLower(),
                Telefono = dto.Telefono,
                Habilitado = dto.Habilitado,
                Token = dto.Token,
                Contrasena = dto.Contrasena,
                Avatar = dto.Avatar?.ToUpper(),
                IdEmpresa = dto.IdEmpresa,
                Registrado = dto.Registrado == default ? DateTime.Now: dto.Registrado,
                UsuarioFechaCreacion = dto.UsuarioFechaCreacion ?? DateTime.Now,
                UsuarioFechaActualizacion = dto.UsuarioFechaActualizacion,
                UsuarioFechaEliminacion = dto.UsuarioFechaEliminacion,
                UsuarioFkModificado = dto.UsuarioFkModificado
            };
        }

        public static void UpdateEntity(Usuario entity, UsuarioDTO dto)
        {
            entity.Nombre = dto.Nombre.ToUpper();
            entity.Apellidos = dto.Apellidos.ToUpper();
            entity.Correo = dto.Correo.ToLower();
            entity.Telefono = dto.Telefono;
            entity.Habilitado = dto.Habilitado;
            entity.Avatar = dto.Avatar?.ToUpper();
            entity.IdEmpresa = dto.IdEmpresa;
            entity.UsuarioFechaActualizacion = DateTime.Now;
            entity.UsuarioFkModificado = dto.UsuarioFkModificado;

            if (!string.IsNullOrEmpty(dto.Contrasena))
            {
                entity.Contrasena = dto.Contrasena;
            }
        }
    }
}
