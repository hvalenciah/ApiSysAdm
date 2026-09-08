using ADP.API.Service.DTOs.Balcan;

namespace ADP.API.Service.Interfaces.Balcan
{
    public interface IVistaUsuarioService
    {
        List<VistaUsuarioDTO> GetAll();
        VistaUsuarioDTO? GetById(int id);
        List<VistaUsuarioDTO> GetByUserId(int userId);
        VistaUsuarioDTO Add(VistaUsuarioDTO dto);
        bool Update(VistaUsuarioDTO dto);
        bool Delete(int id);
    }
}