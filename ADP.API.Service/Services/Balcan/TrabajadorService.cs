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
    public class TrabajadorService : ITrabajadorService
    {
        private readonly BalcanContext _context;

        public TrabajadorService(BalcanContext context)
        {
            _context = context;
        }

        public List<TrabajadorDTO> GetAll()
        {
            return _context.MvInfoTrabajadorCompaqs
                .Select(t => TrabajadorMapper.ToDTO(t))
                .ToList();
        }

        public TrabajadorDTO? GetById(int id)
        {
            var trabajador = _context.MvInfoTrabajadorCompaqs
                .FirstOrDefault(t => t.IdInfoTrabajador == id);

            return trabajador != null ? TrabajadorMapper.ToDTO(trabajador) : null;
        }

        public TrabajadorDTO? GetByCode(string codigoTrabajador)
        {
            if (string.IsNullOrWhiteSpace(codigoTrabajador))
                return null;

            var trabajador = _context.MvInfoTrabajadorCompaqs
                .FirstOrDefault(t => t.CodigoTrabajador != null && t.CodigoTrabajador.Trim() == codigoTrabajador.Trim());

            return trabajador != null ? TrabajadorMapper.ToDTO(trabajador) : null;
        }

        public List<TrabajadorDTO> GetByFullName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                return new List<TrabajadorDTO>();

            // 1. Limpiar y separar la consulta en palabras individuales
            var words = fullName.Trim()
                                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var query = _context.MvInfoTrabajadorCompaqs.AsQueryable();

            // 2. Acumular condiciones WHERE: Cada palabra debe estar presente en (NombreTrabajador + " " + ApellidoPaterno + " " + ApellidoMaterno)
            foreach (var word in words)
            {
                var w = word.ToLower();
                query = query.Where(t => 
                    ((t.NombreTrabajador ?? "") + " " + 
                    (t.ApellidoPaterno ?? "") + " " + 
                    (t.ApellidoMaterno ?? "")).ToLower().Contains(w));
            }

            // 3. Proyectar a DTO y ejecutar la consulta
            return query.Select(t => TrabajadorMapper.ToDTO(t)).ToList();
        }
    }
}