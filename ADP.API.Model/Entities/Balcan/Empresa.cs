using System;
using System.Collections.Generic;

namespace APD.API.Model.Entitites.Balcan;

public partial class Empresa
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public DateTime Registrado { get; set; }

    public bool Habilitado { get; set; }

    public virtual ICollection<Suscripcion> Suscripcions { get; set; } = new List<Suscripcion>();

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
