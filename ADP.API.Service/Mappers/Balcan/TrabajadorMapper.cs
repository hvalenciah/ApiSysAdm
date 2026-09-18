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
    public static class TrabajadorMapper
    {
        public static TrabajadorDTO ToDTO(MvInfoTrabajadorCompaq entity)
        {
            return new TrabajadorDTO
            {
                IdInfoTrabajador = entity.IdInfoTrabajador,
                CodigoTrabajador = entity.CodigoTrabajador,
                NombreTrabajador = entity.NombreTrabajador?.ToUpper(),
                ApellidoPaterno = entity.ApellidoPaterno?.ToUpper(),
                ApellidoMaterno = entity.ApellidoMaterno?.ToUpper(),
                CorreoElectronico = entity.CorreoElectronico?.ToLower(),
                Sexo = entity.Sexo,
                NssTrabajador = entity.NssTrabajador,
            };
        }

        public static MvInfoTrabajadorCompaq ToEntity(TrabajadorDTO dto)
        {
            return new MvInfoTrabajadorCompaq
            {
                IdInfoTrabajador = dto.IdInfoTrabajador,
                CodigoTrabajador = dto.CodigoTrabajador,
                NombreTrabajador = dto.NombreTrabajador?.ToUpper(),
                ApellidoPaterno = dto.ApellidoPaterno?.ToUpper(),
                ApellidoMaterno = dto.ApellidoMaterno?.ToUpper(),
                CorreoElectronico = dto.CorreoElectronico?.ToLower(),                
                Sexo = dto.Sexo,
                NssTrabajador = dto.NssTrabajador,          
            };
        }
    }
}