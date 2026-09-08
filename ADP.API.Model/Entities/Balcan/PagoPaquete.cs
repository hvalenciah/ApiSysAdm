using System;
using System.Collections.Generic;

namespace APD.API.Model.Entitites.Balcan;

public partial class PagoPaquete
{
    public int Id { get; set; }

    public bool Estado { get; set; }

    public int IdSuscripcion { get; set; }

    public int IdPaqueteTarifa { get; set; }

    public virtual PaqueteTarifa IdPaqueteTarifaNavigation { get; set; } = null!;

    public virtual Suscripcion IdSuscripcionNavigation { get; set; } = null!;
}
