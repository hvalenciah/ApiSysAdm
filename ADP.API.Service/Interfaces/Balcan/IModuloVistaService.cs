using System.Collections.Generic;
using ADP.API.Service.DTOs.Balcan;

namespace ADP.API.Service.Interfaces.Balcan
{
    public interface IModuloVistaService
    {
        IEnumerable<ModuloConVistasDTO> GetAll();
        ModuloConVistasDTO? GetByModuleIdAsync(int id_modulo);
        bool AddViewToModuleAsync(ModuloVistaDTO dto);
        bool UpdateModuleViewsAsync(ActualizarModuloVistasDTO dto);
        bool DeleteViewFromModuleAsync(ModuloVistaDTO dto);
    }
}