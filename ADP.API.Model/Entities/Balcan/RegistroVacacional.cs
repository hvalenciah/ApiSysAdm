using System;
using System.Collections.Generic;

namespace APD.API.Model.Entitites.Balcan;

public partial class RegistroVacacional
{
    public int Idregistrovacacional { get; set; }

    public string Codigoempleado { get; set; } = null!;

    public byte[]? Archivo { get; set; }

    public string? Diastomados { get; set; }

    public bool Estado { get; set; }

    public DateTime Fechainicio { get; set; }

    public DateTime Fechafin { get; set; }

    public DateTime? Fecharegistro { get; set; }
}
