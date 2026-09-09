using ADP.API.Service.DTOs.Balcan;

namespace ADP.API.Service.Interfaces.Balcan
{
    public interface IModuloVistaService
    {
        IEnumerable<VistaDTO> GetByModuleId(int idModulo);
        VistaDTO AddViewToModule(ModuloVistaDTO dto);
        bool DeleteViewFromModule(ModuloVistaDTO dto);
    }
}