using ADP.API.Service.DTOs.Balcan;
using APD.API.Model.Entitites.Balcan;

namespace ADP.API.Service.Mappers.Balcan
{
    public static class VistaUsuarioMapper
    {
        public static VistaUsuarioDTO ToDTO(VistaUsuario entity)
        {
            if (entity == null) return null!;

            return new VistaUsuarioDTO
            {
                Id = entity.Id,
                IdUsuario = entity.IdUsuario,
                IdVista = entity.IdVista,
                Consultar = entity.Consultar,
                Agregar = entity.Agregar,
                Actualizar = entity.Actualizar,
                Autorizar = entity.Autorizar,
                Borrar = entity.Borrar
            };
        }

        public static VistaUsuario ToEntity(VistaUsuarioDTO dto)
        {
            if (dto == null) return null!;

            return new VistaUsuario
            {
                Id = dto.Id,
                IdUsuario = dto.IdUsuario,
                IdVista = dto.IdVista,
                Consultar = dto.Consultar,
                Agregar = dto.Agregar,
                Actualizar = dto.Actualizar,
                Autorizar = dto.Autorizar,
                Borrar = dto.Borrar
            };
        }
    }
}