using System;
using System.Collections.Generic;

namespace APD.API.Model.Entitites.Balcan;

public partial class InfoPlazasCompaq
{
    public int Id { get; set; }

    public DateTime FechaCreacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public string? TipoCambio { get; set; }

    public string? CodigoPlaza { get; set; }

    public string? CodigoTrabajador { get; set; }

    public string? Nombre { get; set; }

    public string? Paterno { get; set; }

    public string? Materno { get; set; }

    public string? Sexo { get; set; }

    public DateOnly? FechaIngreso { get; set; }

    public DateOnly? FechaReIngreso { get; set; }

    public DateOnly? FechaBaja { get; set; }

    public string? CausaBaja { get; set; }

    public string? Estado { get; set; }

    public string? TipoEmpleado { get; set; }

    public string? Empresa { get; set; }

    public int? IdPuesto { get; set; }

    public int? NumeroPuesto { get; set; }

    public string? DescPuesto { get; set; }

    public int? IdDepartamento { get; set; }

    public int? NumeroDepartamento { get; set; }

    public string? DescDepartamento { get; set; }

    public int? SegmentoNegocio { get; set; }

    public int? CodigoDireccion { get; set; }

    public int? CodigoGerencia { get; set; }

    public int? CodigoDepto { get; set; }

    public int? CodigoArea { get; set; }
}
