/**
 *
 * @author Hector Valencia
 * @email hvalenciah@aguapuebla.mx
 *
 */

using ADP.API.Service.DTOs.Balcan;

namespace ADP.API.Service.Interfaces.Balcan
{
    public interface IPlazaTrabajadorService
    {
        List<PlazaTrabajadorDTO> GetAll();
        PlazaTrabajadorDTO? GetById(int id);
        PlazaTrabajadorDTO? GetByCodePlaza(string codigoPlaza);
        PlazaTrabajadorDTO? GetByCodeTrabajador(string codigoTrabajador);        
        List<PlazaTrabajadorDTO> GetByFullName(string fullName);
    }
}