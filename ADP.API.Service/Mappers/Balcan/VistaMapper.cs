using ADP.API.Service.DTOs.Balcan;
using APD.API.Model.Entitites.Balcan;

namespace ADP.API.Service.Mappers.Balcan
{
    public static class VistaMapper
    {
        public static VistaDTO ToDTO(Vistum entity)
        {
            if (entity == null) return null!;

            return new VistaDTO
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                Icon = entity.Icon,
                RouterLink = entity.RouterLink,
                IdModulo = entity.IdModulo,
                IdVistaPadre = entity.IdVistaPadre,
                Nivel = entity.Nivel,
                Visible = entity.Visible
            };
        }

        public static Vistum ToEntity(VistaDTO dto)
        {
            if (dto == null) return null!;

            return new Vistum
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Icon = dto.Icon,
                RouterLink = dto.RouterLink,
                IdModulo = dto.IdModulo,
                IdVistaPadre = dto.IdVistaPadre,
                Nivel = dto.Nivel,
                Visible = dto.Visible
            };
        }
    }
}