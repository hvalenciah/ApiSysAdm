namespace ADP.API.Service.DTOs.Balcan
{
    public class ActualizarModuloVistasDTO
    {
        public int IdModulo { get; set; }
        public List<int> VistasIds { get; set; } = new List<int>();
    }
}