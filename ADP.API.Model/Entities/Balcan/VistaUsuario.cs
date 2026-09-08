using System;
using System.Collections.Generic;

namespace APD.API.Model.Entitites.Balcan;

public partial class VistaUsuario
{
    public int Id { get; set; }

    public bool Consultar { get; set; }

    public bool Agregar { get; set; }

    public bool Actualizar { get; set; }

    public bool Autorizar { get; set; }

    public bool Borrar { get; set; }

    public int IdVista { get; set; }

    public int IdUsuario { get; set; }

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual Vistum IdVistaNavigation { get; set; } = null!;
}
