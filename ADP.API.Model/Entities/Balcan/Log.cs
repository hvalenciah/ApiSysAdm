using System;
using System.Collections.Generic;

namespace APD.API.Model.Entitites.Balcan;

public partial class Log
{
    public int Id { get; set; }

    public string Accion { get; set; } = null!;

    public string Usuario { get; set; } = null!;

    public DateTime Registrado { get; set; }
}
