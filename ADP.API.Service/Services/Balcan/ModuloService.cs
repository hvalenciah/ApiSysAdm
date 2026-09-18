using ADP.API.Model.Data.Balcan;
using ADP.API.Service.Interfaces.Balcan;
using ADP.API.Service.DTOs.Balcan;
using ADP.API.Service.Mappers.Balcan;

namespace ADP.API.Service.Services.Balcan
{
    public class ModuloService : IModuloService
    {
        private readonly BalcanContext _context;

        public ModuloService(BalcanContext context)
        {
            _context = context;
        }

        public List<ModuloDTO> GetAll()
        {
            return _context.Modulos
                .OrderBy(m => m.Id)
                .AsEnumerable()
                .Select(m => ModuloMapper.ToDTO(m))
                .ToList();
        }

        public ModuloDTO? GetById(int id)
        {
            var entity = _context.Modulos.FirstOrDefault(m => m.Id == id);
            return entity != null ? ModuloMapper.ToDTO(entity) : null;
        }

        public ModuloDTO? GetByName(string name)
        {
            var entity = _context.Modulos.FirstOrDefault(m => m.Nombre == name);
            return entity != null ? ModuloMapper.ToDTO(entity) : null;
        }

        public ModuloDTO Add(ModuloDTO dto)
        {
            var entity = ModuloMapper.ToEntity(dto);

            _context.Modulos.Add(entity);
            _context.SaveChanges();

            return ModuloMapper.ToDTO(entity);
        }

        public bool Update(ModuloDTO dto)
        {
            var entity = _context.Modulos.FirstOrDefault(m => m.Id == dto.Id);
            if (entity == null) return false;

            entity.Nombre = dto.Nombre;

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var entity = _context.Modulos.FirstOrDefault(m => m.Id == id);
            if (entity == null) return false;

            _context.Modulos.Remove(entity);
            _context.SaveChanges();
            return true;
        }
    }
}