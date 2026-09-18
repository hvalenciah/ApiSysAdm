/**
 *
 * @author Hector Valencia
 * @email hvalenciah@aguapuebla.mx
 *
 */

using ADP.API.Service.DTOs.Balcan;

namespace ADP.API.Service.Interfaces.Balcan
{
    public interface ITrabajadorService
    {
        List<TrabajadorDTO> GetAll();
        TrabajadorDTO? GetById(int id);
        TrabajadorDTO? GetByCode(string codigoTrabajador);
        List<TrabajadorDTO> GetByFullName(string nombreCompleto);
    }
}