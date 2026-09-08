using System;
using System.Collections.Generic;

namespace APD.API.Model.Entitites.Balcan;

public partial class Suscripcion
{
    public int Id { get; set; }

    public int UsuariosActivados { get; set; }

    public DateTime Registrado { get; set; }

    public int IdEmpresa { get; set; }

    public int IdPaquete { get; set; }

    public virtual Empresa IdEmpresaNavigation { get; set; } = null!;

    public virtual Paquete IdPaqueteNavigation { get; set; } = null!;

    public virtual ICollection<PagoPaquete> PagoPaquetes { get; set; } = new List<PagoPaquete>();
}
