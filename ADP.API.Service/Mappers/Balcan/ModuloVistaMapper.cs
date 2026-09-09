using ADP.API.Service.DTOs.Balcan;
using APD.API.Model.Entitites.Balcan;

namespace ADP.API.Service.Mappers.Balcan
{
    public static class ModuloVistaMapper
    {
        public static VistaDTO ToDTO(Vistum entity)
        {
            if (entity == null) return null;

            return new VistaDTO
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                RouterLink = entity.RouterLink,
                Icon = entity.Icon,
                Visible = entity.Visible,
                IdModulo = entity.IdModulo,
                IdVistaPadre = entity.IdVistaPadre
            };
        }
    }
}