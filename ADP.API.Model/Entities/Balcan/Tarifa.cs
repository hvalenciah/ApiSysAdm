using System;
using System.Collections.Generic;

namespace APD.API.Model.Entitites.Balcan;

public partial class Tarifa
{
    public int Id { get; set; }

    public DateTime Registrado { get; set; }

    public virtual ICollection<PaqueteTarifa> PaqueteTarifas { get; set; } = new List<PaqueteTarifa>();
}
