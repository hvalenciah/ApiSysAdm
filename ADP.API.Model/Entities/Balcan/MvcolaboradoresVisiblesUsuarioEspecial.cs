using System;
using System.Collections.Generic;

namespace APD.API.Model.Entitites.Balcan;

public partial class MvcolaboradoresVisiblesUsuarioEspecial
{
    public int Id { get; set; }

    public int FkIdUsuario { get; set; }

    public int CodigoTrabajador { get; set; }

    public string? UsuarioModificador { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public bool Visible { get; set; }
}
