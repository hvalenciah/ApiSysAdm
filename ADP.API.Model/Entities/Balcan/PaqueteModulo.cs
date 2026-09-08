using System;
using System.Collections.Generic;

namespace APD.API.Model.Entitites.Balcan;

public partial class PaqueteModulo
{
    public int Id { get; set; }

    public int Nivel { get; set; }

    public int IdPaquete { get; set; }

    public int IdModulo { get; set; }

    public virtual Modulo IdModuloNavigation { get; set; } = null!;

    public virtual Paquete IdPaqueteNavigation { get; set; } = null!;
}
