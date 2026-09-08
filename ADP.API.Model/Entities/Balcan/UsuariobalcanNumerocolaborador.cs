using System;
using System.Collections.Generic;

namespace APD.API.Model.Entitites.Balcan;

public partial class UsuariobalcanNumerocolaborador
{
    public int Id { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string UsuarioModificacion { get; set; } = null!;

    public int FkIdUsuarioBalcan { get; set; }

    public string NumeroColaborador { get; set; } = null!;

    public string? Saux1 { get; set; }

    public string? Saux2 { get; set; }

    public string? Saux3 { get; set; }

    public string? Saux4 { get; set; }

    public string? Saux5 { get; set; }
}
