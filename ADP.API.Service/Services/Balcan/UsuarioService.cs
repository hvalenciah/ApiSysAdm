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
    public class UsuarioService : IUsuarioService
    {
        private readonly BalcanContext _context;

        public UsuarioService(BalcanContext context)
        {
            _context = context;
        }

        public List<UsuarioDTO> GetAll()
        {
            return _context.Usuarios
                .Select(u => UsuarioMapper.ToDTO(u))
                .ToList();
        }

        public UsuarioDTO? GetById(int id)
        {
            var user = _context.Usuarios
                .FirstOrDefault(u => u.Id == id);

            return user == null ? null : UsuarioMapper.ToDTO(user);
        }

        public List<UsuarioDTO> GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return new List<UsuarioDTO>();

            var search = name.Trim();

            return _context.Usuarios
                .Where(u => u.Nombre.Contains(search))
                .Select(u => UsuarioMapper.ToDTO(u))
                .ToList();
        }

        public List<UsuarioDTO> GetByLastName(string lastName)
        {
            if (string.IsNullOrWhiteSpace(lastName))
                return new List<UsuarioDTO>();

            var search = lastName.Trim();

            return _context.Usuarios
                .Where(u => u.Apellidos.Contains(search))
                .Select(u => UsuarioMapper.ToDTO(u))
                .ToList();
        }
        public UsuarioDTO? GetByFullName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                return null;

            var search = fullName.Trim();

            var user = _context.Usuarios
                .FirstOrDefault(u => u.Nombre.Contains(search) || 
                                     u.Apellidos.Contains(search) ||
                                     (u.Nombre + " " + u.Apellidos).Contains(search));

            return user == null ? null : UsuarioMapper.ToDTO(user);
        }

        public UsuarioDTO? GetByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return null;

            var user = _context.Usuarios
                .FirstOrDefault(u => u.Correo.ToLower() == email.ToLower());

            return user == null ? null : UsuarioMapper.ToDTO(user);
        }

        public UsuarioDTO? GetByPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return null;

            var search = phone.Trim();

            var user = _context.Usuarios
                .FirstOrDefault(u => u.Telefono != null && 
                                    u.Telefono.Contains(search));

            return user == null ? null : UsuarioMapper.ToDTO(user);
        }

        public UsuarioDTO Add(UsuarioDTO dto)
        {
            var entity = UsuarioMapper.ToEntity(dto);
            entity.UsuarioFechaCreacion = DateTime.Now;

            _context.Usuarios.Add(entity);
            _context.SaveChanges();

            dto.Id = entity.Id;
            return UsuarioMapper.ToDTO(entity);
        }

        public bool Update(UsuarioDTO dto)
        {
            var entity = _context.Usuarios
                .FirstOrDefault(u => u.Id == dto.Id);

            if (entity == null) return false;

            UsuarioMapper.UpdateEntity(entity, dto);

            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var entity = _context.Usuarios
                .FirstOrDefault(u => u.Id == id);

            if (entity == null) return false;

            // Borrado lógico actualizando fecha de eliminación
            entity.Habilitado = false;
            entity.UsuarioFechaEliminacion = DateTime.Now;
            _context.SaveChanges();
            return true;
        }

        public List<UsuarioDTO> Search(string t)
        {
            if (string.IsNullOrWhiteSpace(t))
                return new List<UsuarioDTO>();

            var search = t.Trim();

            return _context.Usuarios
                .Where(u => 
                            u.Nombre.Contains(search) ||
                            u.Apellidos.Contains(search) ||
                            u.Correo.Contains(search) ||
                            (u.Telefono != null && u.Telefono.Contains(search)) ||
                            (u.Avatar != null && u.Avatar.Contains(search))
                        )
                .Select(u => UsuarioMapper.ToDTO(u))
                .ToList();
        }
    }
}