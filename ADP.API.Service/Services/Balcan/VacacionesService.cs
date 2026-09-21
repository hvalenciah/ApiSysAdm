/**
 *
 * @author Hector Valencia
 * @email hvalenciah@aguapuebla.mx
 *
 */

using ADP.API.Model.Data.Balcan;
using ADP.API.Service.Interfaces.Balcan;
using ADP.API.Service.DTOs.Balcan;
using ADP.API.Service.Mappers.Balcan;

namespace ADP.API.Service.Services.Balcan
{
    public class VacacionesService : IVacacionesService
    {
        private readonly BalcanContext _context;

        public VacacionesService(BalcanContext context)
        {
            _context = context;
        }

        public List<VacacionesDTO> GetAll()
        {
            return _context.MvPeriodosVacacionesActivas
                .Select(v => VacacionesMapper.ToDTO(v))
                .ToList();
        }

        public VacacionesDTO? GetById(int id)
        {
            var vacaciones = _context.MvPeriodosVacacionesActivas
                .FirstOrDefault(v => v.IdVacacionesActivas == id);

            return vacaciones != null ? VacacionesMapper.ToDTO(vacaciones) : null;
        }

        public List<VacacionesDTO> GetByTrabajador(int codigo_trabajador)
        {
            return _context.MvPeriodosVacacionesActivas
                .Where(v => v.NumeroTrabajador == codigo_trabajador)
                .Select(v => VacacionesMapper.ToDTO(v))
                .ToList();
        }

        public VacacionesDTO? Update(VacacionesDTO dto)
        {
            var entity = _context.MvPeriodosVacacionesActivas
                .FirstOrDefault(v => v.IdVacacionesActivas == dto.IdVacacionesActivas);

            if (entity == null) return null;

            VacacionesMapper.UpdateEntity(entity, dto);

            _context.MvPeriodosVacacionesActivas.Update(entity);
            _context.SaveChanges();

            return VacacionesMapper.ToDTO(entity);
        }
    }
}