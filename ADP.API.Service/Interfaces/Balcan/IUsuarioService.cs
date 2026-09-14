/**
 *
 * @author Hector Valencia
 * @email hvalenciah@aguapuebla.mx
 *
 */

using ADP.API.Service.DTOs.Balcan;

namespace ADP.API.Service.Interfaces.Balcan
{
    public interface IUsuarioService
    {
        List<UsuarioDTO> GetAll();
        UsuarioDTO? GetById(int id);
        List<UsuarioDTO> GetByName(string name);
        List<UsuarioDTO> GetByLastName(string lastName);
        public List<UsuarioDTO> GetByFullname(string fullName);
        UsuarioDTO? GetByEmail(string email);
        UsuarioDTO? GetByPhone(string phone);
        List<UsuarioDTO> GetByAvatar(string avatar);
        UsuarioDTO Add(UsuarioDTO dto);
        bool Update(UsuarioDTO dto);
        bool Delete(int id);
        public List<UsuarioDTO> Search(string t);
    }
}