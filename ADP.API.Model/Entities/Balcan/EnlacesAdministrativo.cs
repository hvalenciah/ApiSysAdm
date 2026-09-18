using System;
using System.Collections.Generic;

namespace APD.API.Model.Entitites.Balcan;

public partial class EnlacesAdministrativo
{
    public int IdUsuarioBc { get; set; }

    public DateOnly FechaDeCreacion { get; set; }

    public DateOnly? FechaDeModificacion { get; set; }

    public string UsuarioModificador { get; set; } = null!;

    public int FkIdUsuario { get; set; }

    public int? FkCodigoTrabajdor { get; set; }

    public string? CodigoEnlace { get; set; }

    public string? NumeroEnlace { get; set; }

    public bool Habilitado { get; set; }

    public virtual Usuario FkIdUsuarioNavigation { get; set; } = null!;
}
