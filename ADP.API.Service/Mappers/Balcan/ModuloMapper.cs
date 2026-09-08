using ADP.API.Service.DTOs.Balcan;
using APD.API.Model.Entitites.Balcan;

namespace ADP.API.Service.Mappers.Balcan
{
    public static class ModuloMapper
    {
        public static ModuloDTO ToDTO(Modulo entity)
        {
            if (entity == null) return null!;

            return new ModuloDTO
            {
                Id = entity.Id,
                Nombre = entity.Nombre
            };
        }

        public static Modulo ToEntity(ModuloDTO dto)
        {
            if (dto == null) return null!;

            return new Modulo
            {
                Id = dto.Id,
                Nombre = dto.Nombre
            };
        }
    }
}