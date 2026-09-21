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
    public static class VacacionesMapper
    {
        public static VacacionesDTO ToDTO(MvPeriodosVacacionesActiva entity)
        {
            return new VacacionesDTO
            {
                IdVacacionesActivas = entity.IdVacacionesActivas,
                FechaCreacion = entity.FechaCreacion,
                FechaModificacion = entity.FechaModificacion,
                UsuarioModificacion = entity.UsuarioModificacion,
                NumeroTrabajador = entity.NumeroTrabajador,
                PeriodoVacacional = entity.PeriodoVacacional,
                DiasOtorgados = entity.DiasOtorgados,
                DiasGozados = entity.DiasGozados,
                DiasPendientes = entity.DiasPendientes,
                Vigencia = entity.Vigencia,
                Activo = entity.Activo
            };
        }

        public static MvPeriodosVacacionesActiva ToEntity(VacacionesDTO dto)
        {
            return new MvPeriodosVacacionesActiva
            {
                IdVacacionesActivas = dto.IdVacacionesActivas,
                FechaCreacion = dto.FechaCreacion == default ? DateTime.Now : dto.FechaCreacion,
                FechaModificacion = dto.FechaModificacion,
                UsuarioModificacion = dto.UsuarioModificacion ?? string.Empty,
                NumeroTrabajador = dto.NumeroTrabajador,
                PeriodoVacacional = dto.PeriodoVacacional,
                DiasOtorgados = dto.DiasOtorgados,
                DiasGozados = dto.DiasGozados,
                DiasPendientes = dto.DiasPendientes,
                Vigencia = dto.Vigencia,
                Activo = dto.Activo
            };
        }

        public static void UpdateEntity(MvPeriodosVacacionesActiva entity, VacacionesDTO dto)
        {
            entity.NumeroTrabajador = dto.NumeroTrabajador;
            entity.PeriodoVacacional = dto.PeriodoVacacional;
            entity.DiasOtorgados = dto.DiasOtorgados;
            entity.DiasGozados = dto.DiasGozados;
            entity.DiasPendientes = dto.DiasPendientes;
            entity.Vigencia = dto.Vigencia;
            entity.Activo = dto.Activo;
            entity.FechaModificacion = DateTime.Now;
        }
    }
}