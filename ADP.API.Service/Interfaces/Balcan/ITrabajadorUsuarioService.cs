using ADP.API.Service.DTOs.Balcan;

namespace ADP.API.Service.Interfaces.Balcan
{
    public interface ITrabajadorUsuarioService
    {
        List<TrabajadorUsuarioDTO> GetAll();
        TrabajadorUsuarioDTO? GetByIdUsuario(int id);
        TrabajadorUsuarioDTO? GetByCodeTrabajador(string codigoTrabajador);
    }
}