using System;
using System.Collections.Generic;

namespace APD.API.Model.Entitites.Balcan;

public partial class Vistum
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Icon { get; set; }

    public string? RouterLink { get; set; }

    public int? IdModulo { get; set; }

    public int? IdVistaPadre { get; set; }

    public int Nivel { get; set; }

    public bool Visible { get; set; }

    public virtual Modulo? IdModuloNavigation { get; set; }

    public virtual Vistum? IdVistaPadreNavigation { get; set; }

    public virtual ICollection<Vistum> InverseIdVistaPadreNavigation { get; set; } = new List<Vistum>();

    public virtual ICollection<VistaUsuario> VistaUsuarios { get; set; } = new List<VistaUsuario>();
}
