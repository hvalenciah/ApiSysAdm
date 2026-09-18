using Microsoft.EntityFrameworkCore;
using ADP.API.Model.Data.Balcan;
using ADP.API.Service.DTOs.Balcan;
using ADP.API.Service.Interfaces.Balcan;
using ADP.API.Service.Mappers.Balcan;

namespace ADP.API.Service.Services.Balcan
{
    public class ModuloVistaService : IModuloVistaService
    {
        private readonly BalcanContext _context;

        public ModuloVistaService(BalcanContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Obtiene todos los módulos con sus respectivas vistas.
        /// </summary>
        public IEnumerable<ModuloConVistasDTO> GetAll()
        {
            var modulos = _context.Modulos
                .Include(m => m.Vista)
                .ToList();

            return modulos.Select(ModuloVistaMapper.ToModuloConVistasDTO);
        }

        /// <summary>
        /// Obtiene un módulo con todas sus vistas asociadas.
        /// </summary>
        public ModuloConVistasDTO? GetByModuleIdAsync(int idModulo)
        {
            var modulo = _context.Modulos
                .Include(m => m.Vista)
                .FirstOrDefault(m => m.Id == idModulo);

            if (modulo == null) return null;

            return ModuloVistaMapper.ToModuloConVistasDTO(modulo);
        }

        /// <summary>
        /// Asocia una vista a un módulo actualizando la clave foránea en la entidad Vistum.
        /// </summary>
        public bool AddViewToModuleAsync(ModuloVistaDTO dto)
        {
            var moduloExiste = _context.Modulos.Any(m => m.Id == dto.IdModulo);
            if (!moduloExiste) return false;

            var vista = _context.Vista.FirstOrDefault(v => v.Id == dto.IdVista);
            if (vista == null) return false;

            vista.IdModulo = dto.IdModulo;
            _context.SaveChanges();

            return true;
        }

        /// <summary>
        /// Sincroniza/modifica la lista completa de vistas asociadas a un módulo.
        /// Desasocia las vistas previas que ya no estén presentes y asocia la lista de vistas solicitadas.
        /// </summary>
        public bool UpdateModuleViewsAsync(ActualizarModuloVistasDTO dto)
        {
            var modulo = _context.Modulos.FirstOrDefault(m => m.Id == dto.IdModulo);
            if (modulo == null) return false;

            // 1. Obtener todas las vistas actualmente asociadas a este módulo
            var vistasActuales = _context.Vista
                .Where(v => v.IdModulo == dto.IdModulo)
                .ToList();

            // 2. Desasociar (set IdModulo = null) las vistas que ya no forman parte de la lista enviada
            foreach (var vista in vistasActuales)
            {
                if (!dto.VistasIds.Contains(vista.Id))
                {
                    vista.IdModulo = null;
                }
            }

            // 3. Asociar las nuevas vistas especificadas en la lista que existan en la BD
            if (dto.VistasIds != null && dto.VistasIds.Any())
            {
                var nuevasVistas = _context.Vista
                    .Where(v => dto.VistasIds.Contains(v.Id))
                    .ToList();

                foreach (var vista in nuevasVistas)
                {
                    vista.IdModulo = dto.IdModulo;
                }
            }

            _context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Remueve la asociación de la vista con el módulo (establece IdModulo en null).
        /// </summary>
        public bool DeleteViewFromModuleAsync(ModuloVistaDTO dto)
        {
            var vista = _context.Vista.FirstOrDefault(v => v.Id == dto.IdVista && v.IdModulo == dto.IdModulo);
            if (vista == null) return false;

            vista.IdModulo = null;
            _context.SaveChanges();

            return true;
        }
    }
}