using ADP.API.Model.Data.Balcan;
using APD.API.Model.Entitites.Balcan;
using ADP.API.Service.Interfaces.Balcan;
using ADP.API.Service.DTOs.Balcan;
using ADP.API.Service.Mappers.Balcan;
using Microsoft.EntityFrameworkCore;

namespace ADP.API.Service.Services.Balcan
{
    public class VistaUsuarioService : IVistaUsuarioService
    {
        private readonly BalcanContext _context;

        public VistaUsuarioService(BalcanContext context)
        {
            _context = context;
        }

        public List<VistaUsuarioDTO> GetAll()
        {
            return _context.VistaUsuarios
                .OrderBy(vu => vu.Id)
                .AsEnumerable()
                .Select(VistaUsuarioMapper.ToDTO)
                .ToList();
        }

        public VistaUsuarioDTO? GetById(int id)
        {
            var entity = _context.VistaUsuarios.FirstOrDefault(vu => vu.Id == id);
            return entity != null ? VistaUsuarioMapper.ToDTO(entity) : null;
        }

        public List<VistaUsuarioDTO> GetByUserId(int userId)
        {
            return _context.VistaUsuarios
                .AsNoTracking()
                .Where(vu => vu.IdUsuario == userId)
                .OrderBy(vu => vu.IdVista)
                .Select(vu => new VistaUsuarioDTO
                {
                    Id = vu.Id,
                    IdUsuario = vu.IdUsuario,
                    IdVista = vu.IdVista,
                    Nombre = vu.IdVistaNavigation.Nombre,
                    Actualizar = vu.Actualizar,
                    Agregar = vu.Agregar,
                    Borrar = vu.Borrar,
                    Consultar = vu.Consultar,
                    Autorizar = vu.Autorizar
                })
                .ToList();
        }

        public VistaUsuarioDTO Add(VistaUsuarioDTO dto)
        {
            var entity = VistaUsuarioMapper.ToEntity(dto);

            _context.VistaUsuarios.Add(entity);
            _context.SaveChanges();

            return VistaUsuarioMapper.ToDTO(entity);
        }

        public bool Update(VistaUsuarioDTO dto)
        {
            var entity = _context.VistaUsuarios.FirstOrDefault(vu => vu.Id == dto.Id);
            if (entity == null) return false;

            entity.IdUsuario = dto.IdUsuario;
            entity.IdVista = dto.IdVista;
            entity.Consultar = dto.Consultar;
            entity.Agregar = dto.Agregar;
            entity.Actualizar = dto.Actualizar;
            entity.Autorizar = dto.Autorizar;
            entity.Borrar = dto.Borrar;

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var entity = _context.VistaUsuarios.FirstOrDefault(vu => vu.Id == id);
            if (entity == null) return false;

            _context.VistaUsuarios.Remove(entity);
            _context.SaveChanges();
            return true;
        }
    }
}