using ADP.API.Model.Data.Balcan;
using ADP.API.Model.DTOs.Balcan;
using ADP.API.Service.Interfaces.Balcan;
using ADP.API.Service.Mappers.Balcan;
using Microsoft.EntityFrameworkCore;
using APD.API.Model.Entitites.Balcan;

namespace ADP.API.Service.Services.Balcan
{
    public class PermisoService : IPermisoService
    {
        private readonly BalcanContext _context;

        public PermisoService(BalcanContext context)
        {
            _context = context;
        }

        public async Task<UsuarioPermisosDTO?> GetPermission(int idUsuario)
        {
            // 1. Validar existencia del usuario
            var usuario = await _context.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == idUsuario);

            if (usuario == null) return null;

            // 2. Consultar relaciones de VistaUsuario asignadas
            var permisosUsuario = await _context.VistaUsuarios
                .AsNoTracking()
                .Where(vu => vu.IdUsuario == idUsuario)
                .ToListAsync();

            var vistasConPermisoIds = permisosUsuario.Select(pu => pu.IdVista).ToHashSet();

            // 3. Obtener Módulos junto con sus Vistas
            var modulosBD = await _context.Modulos
                .Include(m => m.Vista)
                .AsNoTracking()
                .ToListAsync();

            // Calcular offset de IDs virtuales para evitar colisión de IDs
            var maxIdVista = await _context.Vista.MaxAsync(v => (int?)v.Id) ?? 0;
            int idVirtual = maxIdVista;

            var resultadoModulos = new List<ModuloPermisoDTO>();

            // 4. Mapear jerarquía de Módulos y Vistas Raíz
            foreach (var modulo in modulosBD)
            {
                var moduloDto = new ModuloPermisoDTO
                {
                    IdModulo = modulo.Id,
                    NombreModulo = modulo.Nombre
                };

                var vistasRaiz = modulo.Vista
                    .Where(v => v.IdVistaPadre == null)
                    .Select(v => PermisosMapper.ToNodoDto(v, modulo.Vista.ToList(), vistasConPermisoIds, permisosUsuario, ref idVirtual))
                    .ToList();

                moduloDto.Vistas = vistasRaiz;
                resultadoModulos.Add(moduloDto);
            }

            return new UsuarioPermisosDTO
            {
                IdUsuario = usuario.Id,
                NombreUsuario = $"{usuario.Nombre} {usuario.Apellidos}".Trim(),
                Correo = usuario.Correo,
                Modulos = resultadoModulos
            };
        }

        public async Task<bool> SavePermission(GuardarPermisoDTO dto)
        {
            // 1. Validar si el usuario existe
            var usuarioExiste = await _context.Usuarios.AnyAsync(u => u.Id == dto.IdUsuario);
            if (!usuarioExiste) return false;

            // 2. Obtener las asignaciones actuales en BD para ese usuario
            var permisosExistentes = await _context.VistaUsuarios
                .Where(vu => vu.IdUsuario == dto.IdUsuario)
                .ToListAsync();

            // Si la lista de permisos viene nula o vacía, se eliminan todos los permisos asignados a este usuario
            if (dto.Permisos == null || !dto.Permisos.Any())
            {
                if (permisosExistentes.Any())
                {
                    _context.VistaUsuarios.RemoveRange(permisosExistentes);
                    await _context.SaveChangesAsync();
                }
                return true;
            }

            // 3. Procesar los permisos enviados
            foreach (var permisoDto in dto.Permisos)
            {
                var permisoBD = permisosExistentes.FirstOrDefault(p => p.IdVista == permisoDto.IdVista);

                bool tienePermisoActivo = permisoDto.Consultar || 
                                          permisoDto.Agregar || 
                                          permisoDto.Actualizar || 
                                          permisoDto.Borrar || 
                                          permisoDto.Autorizar;

                if (permisoBD != null)
                {
                    if (tienePermisoActivo)
                    {
                        // Actualizar permisos existentes
                        permisoBD.Consultar = permisoDto.Consultar;
                        permisoBD.Agregar = permisoDto.Agregar;
                        permisoBD.Actualizar = permisoDto.Actualizar;
                        permisoBD.Borrar = permisoDto.Borrar;
                        permisoBD.Autorizar = permisoDto.Autorizar;
                    }
                    else
                    {
                        // Eliminar registro de VistaUsuario por Id si ya no tiene permisos activos
                        _context.VistaUsuarios.Remove(permisoBD);
                    }
                }
                else if (tienePermisoActivo)
                {
                    // Insertar nuevo registro solo si trae al menos un permiso activo
                    var nuevoPermiso = new VistaUsuario
                    {
                        IdUsuario = dto.IdUsuario,
                        IdVista = permisoDto.IdVista,
                        Consultar = permisoDto.Consultar,
                        Agregar = permisoDto.Agregar,
                        Actualizar = permisoDto.Actualizar,
                        Borrar = permisoDto.Borrar,
                        Autorizar = permisoDto.Autorizar
                    };
                    await _context.VistaUsuarios.AddAsync(nuevoPermiso);
                }
            }

            // 4. Aplicar cambios a la base de datos (DELETE / UPDATE / INSERT)
            await _context.SaveChangesAsync();
            return true;
        }
    }
}