using System;
using System.Collections.Generic;

namespace APD.API.Model.Entitites.Balcan;

public partial class Modulo
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public virtual ICollection<PaqueteModulo> PaqueteModulos { get; set; } = new List<PaqueteModulo>();

    public virtual ICollection<Vistum> Vista { get; set; } = new List<Vistum>();
}
