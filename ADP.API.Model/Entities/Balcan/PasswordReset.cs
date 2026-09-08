using System;
using System.Collections.Generic;

namespace APD.API.Model.Entitites.Balcan;

public partial class PasswordReset
{
    public Guid PasswordResetId { get; set; }

    public int UsuarioFk { get; set; }

    public string PasswordResetTokenHash { get; set; } = null!;

    public DateTime PasswordResetFechaCreacion { get; set; }

    public DateTime PasswordResetFechaExpiracion { get; set; }

    public bool PasswordResetIsUsed { get; set; }

    public DateTime? PasswordResetFechaUso { get; set; }

    public virtual Usuario UsuarioFkNavigation { get; set; } = null!;
}
