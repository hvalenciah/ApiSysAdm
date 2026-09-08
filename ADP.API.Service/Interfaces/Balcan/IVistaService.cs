using ADP.API.Service.DTOs.Balcan;

namespace ADP.API.Service.Interfaces.Balcan
{
    public interface IVistaService
    {
        List<VistaDTO> GetAll();
        VistaDTO? GetById(int id);
        List<VistaDTO> GetByModuleId(int moduleId);
        VistaDTO Add(VistaDTO dto);
        bool Update(VistaDTO dto);
        bool Delete(int id);
    }
}