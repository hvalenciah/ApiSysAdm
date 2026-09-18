/**
 *
 * @author Hector Valencia
 * @email hvalenciah@aguapuebla.mx
 *
 */

using APD.API.Model.Entitites.Balcan;
using ADP.API.Service.DTOs.Balcan;
using ADP.API.Service.Enums.Balcan;

namespace ADP.API.Service.Mappers.Balcan
{
    public static class PlazaTrabajadorMapper
    {
        public static PlazaTrabajadorDTO ToDTO(InfoPlazasCompaq plaza, MvInfoTrabajadorCompaq? trabajador)
        {
            // Parsear códigos de Dirección y Gerencia de string a int (provenientes de MvInfoTrabajadorCompaq)
            int? codigoDireccion = int.TryParse(trabajador?.CodigoDireccion, out int dir) ? dir : null;
            int? codigoGerencia = int.TryParse(trabajador?.CodigoGerencia, out int ger) ? ger : null;

            return new PlazaTrabajadorDTO
            {
                Id = plaza.Id,
                CodigoPlaza = plaza.CodigoPlaza,
                CodigoTrabajador = plaza.CodigoTrabajador,
                Nombre = plaza.Nombre?.ToUpper(),
                Paterno = plaza.Paterno?.ToUpper(),
                Materno = plaza.Materno?.ToUpper(),
                FechaIngreso = plaza.FechaIngreso,
                FechaReIngreso = plaza.FechaReIngreso,
                FechaBaja = plaza.FechaBaja,
                CausaBaja = plaza.CausaBaja,
                Estado = plaza.Estado,
                TipoEmpleado = plaza.TipoEmpleado,

                SegmentoNegocio = plaza.SegmentoNegocio,
                
                // Datos de INFO_PLAZAS_COMPAQ
                CodigoPuesto = plaza.NumeroPuesto,
                NombrePuesto = plaza.DescPuesto?.ToUpper(),
                CodigoDepartamento = plaza.NumeroDepartamento,
                NombreDepartamento = plaza.DescDepartamento?.ToUpper(),
                
                // Mapeo desde ENUM con datos de MV_INFO_TRABAJADOR_COMPAQ                
                CodigoGerencia = codigoGerencia,
                NombreGerencia = GerenciasEnum.GetNombreGerencia(codigoGerencia),
                CodigoDireccion = codigoDireccion,
                NombreDireccion = DireccionesEnum.GetNombreDireccion(codigoDireccion)
            };
        }
    }
}