using System;
using System.Collections.Generic;

namespace APD.API.Model.Entitites.Balcan;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string? Telefono { get; set; }

    public DateTime Registrado { get; set; }

    public bool Habilitado { get; set; }

    public string? Token { get; set; }

    public string? Contrasena { get; set; }

    public string? Avatar { get; set; }

    public int IdEmpresa { get; set; }

    public DateTime? UsuarioFechaCreacion { get; set; }

    public DateTime? UsuarioFechaEliminacion { get; set; }

    public DateTime? UsuarioFechaActualizacion { get; set; }

    public int? UsuarioFkModificado { get; set; }

    public virtual ICollection<EnlacesAdministrativo> EnlacesAdministrativos { get; set; } = new List<EnlacesAdministrativo>();

    public virtual Empresa IdEmpresaNavigation { get; set; } = null!;

    public virtual ICollection<Usuario> InverseUsuarioFkModificadoNavigation { get; set; } = new List<Usuario>();

    public virtual ICollection<PasswordReset> PasswordResets { get; set; } = new List<PasswordReset>();

    public virtual Usuario? UsuarioFkModificadoNavigation { get; set; }

    public virtual ICollection<VistaUsuario> VistaUsuarios { get; set; } = new List<VistaUsuario>();
}
