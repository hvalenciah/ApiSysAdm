/**
 *
 * @author Hector Valencia
 * @email hvalenciah@aguapuebla.mx
 *
 */

using ADP.API.Service.DTOs.Balcan;

namespace ADP.API.Service.Interfaces.Balcan
{
    public interface IVacacionesService
    {
        List<VacacionesDTO> GetAll();
        VacacionesDTO? GetById(int id);
        List<VacacionesDTO> GetByTrabajador(int numeroTrabajador);
        VacacionesDTO? Update(VacacionesDTO dto);
    }
}