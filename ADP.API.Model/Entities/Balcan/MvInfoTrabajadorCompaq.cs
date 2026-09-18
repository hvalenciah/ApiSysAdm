using System;
using System.Collections.Generic;

namespace APD.API.Model.Entitites.Balcan;

public partial class MvInfoTrabajadorCompaq
{
    public int IdInfoTrabajador { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string UsuarioModificacion { get; set; } = null!;

    public string? CodigoTrabajador { get; set; }

    public string? NombreTrabajador { get; set; }

    public string? ApellidoPaterno { get; set; }

    public string? ApellidoMaterno { get; set; }

    public DateTime? FechaIngreso { get; set; }

    public string? EstadoTrabajador { get; set; }

    public string? NssTrabajador { get; set; }

    public string? Sexo { get; set; }

    public string? CorreoElectronico { get; set; }

    public int? FkIdPuesto { get; set; }

    public string? FkPuestoDescripcion { get; set; }

    public int? FkIdDepartamento { get; set; }

    public string? FkDepartamentoDescripcion { get; set; }

    public int? NumeroDepartamento { get; set; }

    public string? CodigoDireccion { get; set; }

    public string? CodigoGerencia { get; set; }

    public string? CodigoDepartamento { get; set; }

    public string? CodigoArea { get; set; }

    public string? NumeroDeEnlace { get; set; }

    public string? TipoEmpleado { get; set; }
}
