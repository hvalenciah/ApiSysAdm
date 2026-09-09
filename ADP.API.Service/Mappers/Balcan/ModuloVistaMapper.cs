using System.Linq;
using ADP.API.Service.DTOs.Balcan;
using APD.API.Model.Entitites.Balcan;

namespace ADP.API.Service.Mappers.Balcan
{
    public static class ModuloVistaMapper
    {
        public static VistaDetalleDTO ToVistaDetalleDTO(Vistum entity)
        {
            if (entity == null) return null!;

            return new VistaDetalleDTO
            {
                IdVista = entity.Id,
                Nombre = entity.Nombre,
                RouterLink = entity.RouterLink,
                Icon = entity.Icon,
                Visible = entity.Visible,
                IdVistaPadre = entity.IdVistaPadre
            };
        }

        public static ModuloConVistasDTO ToModuloConVistasDTO(Modulo moduloEntity)
        {
            if (moduloEntity == null) return null!;

            return new ModuloConVistasDTO
            {
                IdModulo = moduloEntity.Id,
                NombreModulo = moduloEntity.Nombre ?? string.Empty,
                Vistas = moduloEntity.Vista != null 
                    ? moduloEntity.Vista.Select(ToVistaDetalleDTO).ToList() 
                    : new List<VistaDetalleDTO>()
            };
        }
    }
}