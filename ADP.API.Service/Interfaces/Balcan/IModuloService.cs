using ADP.API.Service.DTOs.Balcan;

namespace ADP.API.Service.Interfaces.Balcan
{
    public interface IModuloService
    {
        List<ModuloDTO> GetAll();
        ModuloDTO? GetById(int id);
        ModuloDTO Add(ModuloDTO dto);
        bool Update(ModuloDTO dto);
        bool Delete(int id);
    }
}