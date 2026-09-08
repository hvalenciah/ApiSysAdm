using System;
using System.Collections.Generic;

namespace APD.API.Model.Entitites.Balcan;

public partial class Configuracion
{
    public int PidservicioConf { get; set; }

    public string NomServicio { get; set; } = null!;

    public string UrlServicio { get; set; } = null!;
}
