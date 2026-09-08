using System;
using System.Collections.Generic;

namespace APD.API.Model.Entitites.Balcan;

public partial class PaqueteTarifa
{
    public int Id { get; set; }

    public decimal Precio { get; set; }

    public int IdTarifa { get; set; }

    public int IdPaquete { get; set; }

    public virtual Paquete IdPaqueteNavigation { get; set; } = null!;

    public virtual Tarifa IdTarifaNavigation { get; set; } = null!;

    public virtual ICollection<PagoPaquete> PagoPaquetes { get; set; } = new List<PagoPaquete>();
}
