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
    public class TrabajadorUsuarioService : ITrabajadorUsuarioService
    {
        private readonly BalcanContext _context;
        private readonly IPlazaTrabajadorService _plazaTrabajadorService;

        public TrabajadorUsuarioService(
            BalcanContext context, 
            IPlazaTrabajadorService plazaTrabajadorService)
        {
            _context = context;
            _plazaTrabajadorService = plazaTrabajadorService;
        }

        public List<TrabajadorUsuarioDTO> GetAll()
        {
            var usuariosConColaborador = (from u in _context.Usuarios
                                          join un in _context.UsuariobalcanNumerocolaboradors
                                              on u.Id equals un.FkIdUsuarioBalcan into unGroup
                                          from un in unGroup.DefaultIfEmpty()
                                          select new 
                                          { 
                                              Usuario = u, 
                                              CodigoTrabajador = un != null ? un.NumeroColaborador : null 
                                          })
                                         .ToList();

            var result = new List<TrabajadorUsuarioDTO>();

            foreach (var item in usuariosConColaborador)
            {
                PlazaTrabajadorDTO? plazaTrabajador = null;

                if (!string.IsNullOrWhiteSpace(item.CodigoTrabajador))
                {
                    plazaTrabajador = _plazaTrabajadorService.GetByTrabajador(item.CodigoTrabajador);
                }

                result.Add(TrabajadorUsuarioMapper.ToDTO(item.Usuario, item.CodigoTrabajador, plazaTrabajador));
            }

            return result;
        }

        public TrabajadorUsuarioDTO? GetByIdUsuario(int id)
        {
            var item = (from u in _context.Usuarios
                        where u.Id == id
                        join un in _context.UsuariobalcanNumerocolaboradors
                            on u.Id equals un.FkIdUsuarioBalcan into unGroup
                        from un in unGroup.DefaultIfEmpty()
                        select new 
                        { 
                            Usuario = u, 
                            CodigoTrabajador = un != null ? un.NumeroColaborador : null 
                        })
                       .FirstOrDefault();

            if (item == null) return null;

            PlazaTrabajadorDTO? plazaTrabajador = null;
            if (!string.IsNullOrWhiteSpace(item.CodigoTrabajador))
            {
                plazaTrabajador = _plazaTrabajadorService.GetByTrabajador(item.CodigoTrabajador);
            }

            return TrabajadorUsuarioMapper.ToDTO(item.Usuario, item.CodigoTrabajador, plazaTrabajador);
        }

        public TrabajadorUsuarioDTO? GetByCodeTrabajador(string codigoTrabajador)
        {
            if (string.IsNullOrWhiteSpace(codigoTrabajador)) 
                return null;

            var item = (from un in _context.UsuariobalcanNumerocolaboradors
                        where un.NumeroColaborador == codigoTrabajador
                        join u in _context.Usuarios 
                            on un.FkIdUsuarioBalcan equals u.Id
                        select new 
                        { 
                            Usuario = u, 
                            CodigoTrabajador = un.NumeroColaborador 
                        })
                       .FirstOrDefault();

            if (item == null) return null;

            var plazaTrabajador = _plazaTrabajadorService.GetByTrabajador(codigoTrabajador);

            return TrabajadorUsuarioMapper.ToDTO(item.Usuario, item.CodigoTrabajador, plazaTrabajador);
        }
    }
}