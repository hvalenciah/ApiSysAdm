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
    public class PlazaTrabajadorService : IPlazaTrabajadorService
    {
        private readonly BalcanContext _context;

        public PlazaTrabajadorService(BalcanContext context)
        {
            _context = context;
        }

        public List<PlazaTrabajadorDTO> GetAll()
        {
            var plazas = _context.InfoPlazasCompaqs.ToList();
            var trabajadores = _context.MvInfoTrabajadorCompaqs.ToList();

            return (from p in plazas
                    join t in trabajadores on p.CodigoTrabajador equals t.CodigoTrabajador into joined
                    from t in joined.DefaultIfEmpty()
                    select PlazaTrabajadorMapper.ToDTO(p, t)).ToList();
        }

        public PlazaTrabajadorDTO? GetById(int id)
        {
            var plaza = _context.InfoPlazasCompaqs.FirstOrDefault(p => p.Id == id);
            if (plaza == null) return null;

            var trabajador = _context.MvInfoTrabajadorCompaqs
                .FirstOrDefault(t => t.CodigoTrabajador == plaza.CodigoTrabajador);

            return PlazaTrabajadorMapper.ToDTO(plaza, trabajador);
        }

        public PlazaTrabajadorDTO? GetByCodePlaza(string codigoPlaza)
        {
            if (string.IsNullOrWhiteSpace(codigoPlaza)) return null;

            var plaza = _context.InfoPlazasCompaqs
                .FirstOrDefault(p => p.CodigoPlaza != null && p.CodigoPlaza.Trim() == codigoPlaza.Trim());

            if (plaza == null) return null;

            var trabajador = _context.MvInfoTrabajadorCompaqs
                .FirstOrDefault(t => t.CodigoTrabajador == plaza.CodigoTrabajador);

            return PlazaTrabajadorMapper.ToDTO(plaza, trabajador);
        }

        public PlazaTrabajadorDTO? GetByCodeTrabajador(string codigoTrabajador)
        {
            if (string.IsNullOrWhiteSpace(codigoTrabajador)) return null;

            var plaza = _context.InfoPlazasCompaqs
                .FirstOrDefault(p => p.CodigoTrabajador != null && p.CodigoTrabajador.Trim() == codigoTrabajador.Trim());

            if (plaza == null) return null;

            var trabajador = _context.MvInfoTrabajadorCompaqs
                .FirstOrDefault(t => t.CodigoTrabajador == plaza.CodigoTrabajador);

            return PlazaTrabajadorMapper.ToDTO(plaza, trabajador);
        }

        public List<PlazaTrabajadorDTO> GetByFullName(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName))
                return new List<PlazaTrabajadorDTO>();

            var words = fullName.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var queryPlazas = _context.InfoPlazasCompaqs.AsQueryable();

            foreach (var word in words)
            {
                var w = word.ToLower();
                queryPlazas = queryPlazas.Where(p =>
                    ((p.Nombre ?? "") + " " +
                     (p.Paterno ?? "") + " " +
                     (p.Materno ?? "")).ToLower().Contains(w));
            }

            var plazas = queryPlazas.ToList();
            var codigosTrabajadores = plazas.Select(p => p.CodigoTrabajador).Distinct().ToList();

            var trabajadores = _context.MvInfoTrabajadorCompaqs
                .Where(t => codigosTrabajadores.Contains(t.CodigoTrabajador))
                .ToList();

            return (from p in plazas
                    join t in trabajadores on p.CodigoTrabajador equals t.CodigoTrabajador into joined
                    from t in joined.DefaultIfEmpty()
                    select PlazaTrabajadorMapper.ToDTO(p, t)).ToList();
        }
    }
}