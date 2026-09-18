using ADP.API.Model.Data.Balcan;
using ADP.API.Service.Interfaces.Balcan;
using ADP.API.Service.DTOs.Balcan;
using ADP.API.Service.Mappers.Balcan;

namespace ADP.API.Service.Services.Balcan
{
    public class VistaService : IVistaService
    {
        private readonly BalcanContext _context;

        public VistaService(BalcanContext context)
        {
            _context = context;
        }

        private IQueryable<VistaDTO> BaseQuery()
        {
            return from v in _context.Vista
                   join m in _context.Modulos on v.IdModulo equals m.Id into modulosGroup
                   from m in modulosGroup.DefaultIfEmpty()
                   select new VistaDTO
                   {
                       Id = v.Id,
                       Nombre = v.Nombre,
                       Icon = v.Icon,
                       RouterLink = v.RouterLink,
                       IdModulo = v.IdModulo,
                       IdVistaPadre = v.IdVistaPadre,
                       Nivel = v.Nivel,
                       Visible = v.Visible
                   };
        }

        public List<VistaDTO> GetAll()
        {
            return BaseQuery().OrderBy(v => v.Id).ToList();
        }

        public VistaDTO? GetById(int id)
        {
            return BaseQuery().FirstOrDefault(v => v.Id == id);
        }

        public VistaDTO? GetByName(string name)
        {
            return BaseQuery().FirstOrDefault(v => v.Nombre == name);
        }

        public List<VistaDTO> GetByModuleId(int moduleId)
        {
            return BaseQuery()
                .Where(v => v.IdModulo == moduleId)
                .OrderBy(v => v.Id)
                .ToList();
        }

        public VistaDTO Add(VistaDTO dto)
        {
            var entity = VistaMapper.ToEntity(dto);

            _context.Vista.Add(entity);
            _context.SaveChanges();

            return GetById(entity.Id)!;
        }

        public bool Update(VistaDTO dto)
        {
            var entity = _context.Vista.FirstOrDefault(v => v.Id == dto.Id);
            if (entity == null) return false;

            entity.Nombre = dto.Nombre;
            entity.Icon = dto.Icon;
            entity.RouterLink = dto.RouterLink;
            entity.IdModulo = dto.IdModulo;
            entity.IdVistaPadre = dto.IdVistaPadre;
            entity.Nivel = dto.Nivel;
            entity.Visible = dto.Visible;

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var entity = _context.Vista.FirstOrDefault(v => v.Id == id);
            if (entity == null) return false;

            _context.Vista.Remove(entity);
            _context.SaveChanges();
            return true;
        }
    }
}