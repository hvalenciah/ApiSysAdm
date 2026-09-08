using System;
using System.Collections.Generic;

namespace APD.API.Model.Entitites.Balcan;

public partial class Paquete
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int Nmodulos { get; set; }

    public int Nusuarios { get; set; }

    public virtual ICollection<PaqueteModulo> PaqueteModulos { get; set; } = new List<PaqueteModulo>();

    public virtual ICollection<PaqueteTarifa> PaqueteTarifas { get; set; } = new List<PaqueteTarifa>();

    public virtual ICollection<Suscripcion> Suscripcions { get; set; } = new List<Suscripcion>();
}
