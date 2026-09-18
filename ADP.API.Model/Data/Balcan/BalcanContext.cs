using System;
using System.Collections.Generic;
using APD.API.Model.Entitites.Balcan;
using Microsoft.EntityFrameworkCore;

namespace ADP.API.Model.Data.Balcan;

public partial class BalcanContext : DbContext
{
    public BalcanContext()
    {
    }

    public BalcanContext(DbContextOptions<BalcanContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Acuapue> Acuapues { get; set; }

    public virtual DbSet<Configuracion> Configuracions { get; set; }

    public virtual DbSet<Empresa> Empresas { get; set; }

    public virtual DbSet<EnlacesAdministrativo> EnlacesAdministrativos { get; set; }

    public virtual DbSet<InfoPlazasCompaq> InfoPlazasCompaqs { get; set; }

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Modulo> Modulos { get; set; }

    public virtual DbSet<MvInfoTrabajadorCompaq> MvInfoTrabajadorCompaqs { get; set; }

    public virtual DbSet<MvPeriodosVacacionesActiva> MvPeriodosVacacionesActivas { get; set; }

    public virtual DbSet<MvcolaboradoresVisiblesUsuarioEspecial> MvcolaboradoresVisiblesUsuarioEspecials { get; set; }

    public virtual DbSet<PagoPaquete> PagoPaquetes { get; set; }

    public virtual DbSet<Paquete> Paquetes { get; set; }

    public virtual DbSet<PaqueteModulo> PaqueteModulos { get; set; }

    public virtual DbSet<PaqueteTarifa> PaqueteTarifas { get; set; }

    public virtual DbSet<PasswordReset> PasswordResets { get; set; }

    public virtual DbSet<RegistroVacacional> RegistroVacacionals { get; set; }

    public virtual DbSet<Suscripcion> Suscripcions { get; set; }

    public virtual DbSet<Tarifa> Tarifas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuariobalcanNumerocolaborador> UsuariobalcanNumerocolaboradors { get; set; }

    public virtual DbSet<VistaUsuario> VistaUsuarios { get; set; }

    public virtual DbSet<Vistum> Vista { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=BalcanDB");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Acuapue>(entity =>
        {
            entity.ToTable("ACUAPUE", "BALCAN");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Cuenta)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Configuracion>(entity =>
        {
            entity.HasKey(e => e.PidservicioConf);

            entity.ToTable("Configuracion", "BALCAN");

            entity.Property(e => e.PidservicioConf).HasColumnName("PIDServicioConf");
            entity.Property(e => e.NomServicio).HasMaxLength(50);
            entity.Property(e => e.UrlServicio).HasMaxLength(200);
        });

        modelBuilder.Entity<Empresa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Empresa__3214EC075DDE887C");

            entity.ToTable("Empresa", "BALCAN");

            entity.HasIndex(e => e.Telefono, "UQ__Empresa__4EC50480917251D6").IsUnique();

            entity.HasIndex(e => e.Correo, "UQ__Empresa__60695A19BD1A6F6A").IsUnique();

            entity.HasIndex(e => e.Nombre, "UQ__Empresa__75E3EFCFF2C8F8B9").IsUnique();

            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Registrado).HasColumnType("datetime");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EnlacesAdministrativo>(entity =>
        {
            entity.HasKey(e => e.IdUsuarioBc);

            entity.Property(e => e.IdUsuarioBc).HasColumnName("id_UsuarioBC");
            entity.Property(e => e.CodigoEnlace)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("CODIGO_ENLACE");
            entity.Property(e => e.FechaDeCreacion).HasColumnName("FECHA_DE_CREACION");
            entity.Property(e => e.FechaDeModificacion).HasColumnName("FECHA_DE_MODIFICACION");
            entity.Property(e => e.FkCodigoTrabajdor).HasColumnName("FK_CODIGO_TRABAJDOR");
            entity.Property(e => e.FkIdUsuario).HasColumnName("FK_ID_USUARIO");
            entity.Property(e => e.Habilitado)
                .HasDefaultValue(true)
                .HasColumnName("HABILITADO");
            entity.Property(e => e.NumeroEnlace)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("NUMERO_ENLACE");
            entity.Property(e => e.UsuarioModificador)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("USUARIO_MODIFICADOR");

            entity.HasOne(d => d.FkIdUsuarioNavigation).WithMany(p => p.EnlacesAdministrativos)
                .HasForeignKey(d => d.FkIdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EnlacesAdministrativos_Usuario");
        });

        modelBuilder.Entity<InfoPlazasCompaq>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__INFO_PLA__3214EC279611CC23");

            entity.ToTable("INFO_PLAZAS_COMPAQ", "CDP");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CausaBaja)
                .IsUnicode(false)
                .HasColumnName("CAUSA_BAJA");
            entity.Property(e => e.CodigoArea).HasColumnName("CODIGO_AREA");
            entity.Property(e => e.CodigoDepto).HasColumnName("CODIGO_DEPTO");
            entity.Property(e => e.CodigoDireccion).HasColumnName("CODIGO_DIRECCION");
            entity.Property(e => e.CodigoGerencia).HasColumnName("CODIGO_GERENCIA");
            entity.Property(e => e.CodigoPlaza)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CODIGO_PLAZA");
            entity.Property(e => e.CodigoTrabajador)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CODIGO_TRABAJADOR");
            entity.Property(e => e.DescDepartamento)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DESC_DEPARTAMENTO");
            entity.Property(e => e.DescPuesto)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("DESC_PUESTO");
            entity.Property(e => e.Empresa)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("EMPRESA");
            entity.Property(e => e.Estado)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("ESTADO");
            entity.Property(e => e.FechaBaja).HasColumnName("FECHA_BAJA");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.FechaIngreso).HasColumnName("FECHA_INGRESO");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_MODIFICACION");
            entity.Property(e => e.FechaReIngreso).HasColumnName("FECHA_RE_INGRESO");
            entity.Property(e => e.IdDepartamento).HasColumnName("ID_DEPARTAMENTO");
            entity.Property(e => e.IdPuesto).HasColumnName("ID_PUESTO");
            entity.Property(e => e.Materno)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("MATERNO");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");
            entity.Property(e => e.NumeroDepartamento).HasColumnName("NUMERO_DEPARTAMENTO");
            entity.Property(e => e.NumeroPuesto).HasColumnName("NUMERO_PUESTO");
            entity.Property(e => e.Paterno)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("PATERNO");
            entity.Property(e => e.SegmentoNegocio).HasColumnName("SEGMENTO_NEGOCIO");
            entity.Property(e => e.Sexo)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SEXO");
            entity.Property(e => e.TipoCambio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TIPO_CAMBIO");
            entity.Property(e => e.TipoEmpleado)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("TIPO_EMPLEADO");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("USUARIO_MODIFICACION");
        });

        modelBuilder.Entity<Log>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Log__3213E83F5B3F4972");

            entity.ToTable("Log", "BALCAN");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Accion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Registrado).HasColumnType("datetime");
            entity.Property(e => e.Usuario)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Modulo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Modulo__3214EC07D05B50E9");

            entity.ToTable("Modulo", "BALCAN");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<MvInfoTrabajadorCompaq>(entity =>
        {
            entity.HasKey(e => e.IdInfoTrabajador).HasName("PK__MV_INFO___D2C5B6BE587AAFDD");

            entity.ToTable("MV_INFO_TRABAJADOR_COMPAQ");

            entity.Property(e => e.IdInfoTrabajador).HasColumnName("ID_INFO_TRABAJADOR");
            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("APELLIDO_MATERNO");
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("APELLIDO_PATERNO");
            entity.Property(e => e.CodigoArea)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CODIGO_AREA");
            entity.Property(e => e.CodigoDepartamento)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CODIGO_DEPARTAMENTO");
            entity.Property(e => e.CodigoDireccion)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CODIGO_DIRECCION");
            entity.Property(e => e.CodigoGerencia)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("CODIGO_GERENCIA");
            entity.Property(e => e.CodigoTrabajador)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("CODIGO_TRABAJADOR");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(60)
                .IsUnicode(false)
                .HasColumnName("CORREO_ELECTRONICO");
            entity.Property(e => e.EstadoTrabajador)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("ESTADO_TRABAJADOR");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_INGRESO");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_MODIFICACION");
            entity.Property(e => e.FkDepartamentoDescripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FK_DEPARTAMENTO_DESCRIPCION");
            entity.Property(e => e.FkIdDepartamento).HasColumnName("FK_ID_DEPARTAMENTO");
            entity.Property(e => e.FkIdPuesto).HasColumnName("FK_ID_PUESTO");
            entity.Property(e => e.FkPuestoDescripcion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("FK_PUESTO_DESCRIPCION");
            entity.Property(e => e.NombreTrabajador)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("NOMBRE_TRABAJADOR");
            entity.Property(e => e.NssTrabajador)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("NSS_TRABAJADOR");
            entity.Property(e => e.NumeroDeEnlace)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("Numero_de_enlace");
            entity.Property(e => e.NumeroDepartamento).HasColumnName("NUMERO_DEPARTAMENTO");
            entity.Property(e => e.Sexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("SEXO");
            entity.Property(e => e.TipoEmpleado)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("TIPO_EMPLEADO");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("USUARIO_MODIFICACION");
        });

        modelBuilder.Entity<MvPeriodosVacacionesActiva>(entity =>
        {
            entity.HasKey(e => e.IdVacacionesActivas).HasName("PK__MV_PERIO__028EADF1B5430F56");

            entity.ToTable("MV_PERIODOS_VACACIONES_ACTIVAS");

            entity.Property(e => e.IdVacacionesActivas).HasColumnName("ID_VACACIONES_ACTIVAS");
            entity.Property(e => e.Activo).HasColumnName("ACTIVO");
            entity.Property(e => e.DiasGozados).HasColumnName("DIAS_GOZADOS");
            entity.Property(e => e.DiasOtorgados).HasColumnName("DIAS_OTORGADOS");
            entity.Property(e => e.DiasPendientes).HasColumnName("DIAS_PENDIENTES");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_MODIFICACION");
            entity.Property(e => e.NumeroTrabajador).HasColumnName("NUMERO_TRABAJADOR");
            entity.Property(e => e.PeriodoVacacional)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("PERIODO_VACACIONAL");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("USUARIO_MODIFICACION");
            entity.Property(e => e.Vigencia).HasColumnName("VIGENCIA");
        });

        modelBuilder.Entity<MvcolaboradoresVisiblesUsuarioEspecial>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_MVColab");

            entity.ToTable("MVColaboradores_Visibles_UsuarioEspecial");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CodigoTrabajador).HasColumnName("CODIGO_TRABAJADOR");
            entity.Property(e => e.FechaModificacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("FECHA_MODIFICACION");
            entity.Property(e => e.FkIdUsuario).HasColumnName("FK_ID_USUARIO");
            entity.Property(e => e.UsuarioModificador)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("USUARIO_MODIFICADOR");
            entity.Property(e => e.Visible)
                .HasDefaultValue(true)
                .HasColumnName("VISIBLE");
        });

        modelBuilder.Entity<PagoPaquete>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PagoPaqu__3214EC075748B27E");

            entity.ToTable("PagoPaquete", "BALCAN");

            entity.HasOne(d => d.IdPaqueteTarifaNavigation).WithMany(p => p.PagoPaquetes)
                .HasForeignKey(d => d.IdPaqueteTarifa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PaqueteTarifa - Pagos");

            entity.HasOne(d => d.IdSuscripcionNavigation).WithMany(p => p.PagoPaquetes)
                .HasForeignKey(d => d.IdSuscripcion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Suscripcion - Pagos");
        });

        modelBuilder.Entity<Paquete>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Paquete__3214EC07A09F67E8");

            entity.ToTable("Paquete", "BALCAN");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nmodulos).HasColumnName("NModulos");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nusuarios).HasColumnName("NUsuarios");
        });

        modelBuilder.Entity<PaqueteModulo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PaqueteM__3214EC071AA7A83B");

            entity.ToTable("PaqueteModulo", "BALCAN");

            entity.HasOne(d => d.IdModuloNavigation).WithMany(p => p.PaqueteModulos)
                .HasForeignKey(d => d.IdModulo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Modulo - Paquetes");

            entity.HasOne(d => d.IdPaqueteNavigation).WithMany(p => p.PaqueteModulos)
                .HasForeignKey(d => d.IdPaquete)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Paquete - Modulos");
        });

        modelBuilder.Entity<PaqueteTarifa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__PaqueteT__3214EC076C02FCE0");

            entity.ToTable("PaqueteTarifa", "BALCAN");

            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdPaqueteNavigation).WithMany(p => p.PaqueteTarifas)
                .HasForeignKey(d => d.IdPaquete)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Paquete - Tarifas");

            entity.HasOne(d => d.IdTarifaNavigation).WithMany(p => p.PaqueteTarifas)
                .HasForeignKey(d => d.IdTarifa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Tarifa - Paquetes");
        });

        modelBuilder.Entity<PasswordReset>(entity =>
        {
            entity.HasKey(e => e.PasswordResetId).HasName("PK__Password__05DE4B075A2C4BA3");

            entity.ToTable("PasswordReset", "BALCAN");

            entity.Property(e => e.PasswordResetId)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("PasswordReset_Id");
            entity.Property(e => e.PasswordResetFechaCreacion)
                .HasDefaultValueSql("(sysutcdatetime())")
                .HasColumnName("PasswordReset_FechaCreacion");
            entity.Property(e => e.PasswordResetFechaExpiracion).HasColumnName("PasswordReset_FechaExpiracion");
            entity.Property(e => e.PasswordResetFechaUso).HasColumnName("PasswordReset_FechaUso");
            entity.Property(e => e.PasswordResetIsUsed).HasColumnName("PasswordReset_IsUsed");
            entity.Property(e => e.PasswordResetTokenHash)
                .HasMaxLength(255)
                .HasColumnName("PasswordReset_TokenHash");
            entity.Property(e => e.UsuarioFk).HasColumnName("Usuario_fk");

            entity.HasOne(d => d.UsuarioFkNavigation).WithMany(p => p.PasswordResets)
                .HasForeignKey(d => d.UsuarioFk)
                .HasConstraintName("FK_PasswordResetTokens_Users");
        });

        modelBuilder.Entity<RegistroVacacional>(entity =>
        {
            entity.HasKey(e => e.Idregistrovacacional);

            entity.ToTable("RegistroVacacional", "BALCAN");

            entity.Property(e => e.Idregistrovacacional).HasColumnName("idregistrovacacional");
            entity.Property(e => e.Archivo).HasColumnName("archivo");
            entity.Property(e => e.Codigoempleado)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("codigoempleado");
            entity.Property(e => e.Diastomados)
                .HasMaxLength(20)
                .HasColumnName("diastomados");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Fechafin)
                .HasColumnType("datetime")
                .HasColumnName("fechafin");
            entity.Property(e => e.Fechainicio)
                .HasColumnType("datetime")
                .HasColumnName("fechainicio");
            entity.Property(e => e.Fecharegistro)
                .HasColumnType("datetime")
                .HasColumnName("fecharegistro");
        });

        modelBuilder.Entity<Suscripcion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Suscripc__3213E83FD69F525F");

            entity.ToTable("Suscripcion", "BALCAN");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Registrado).HasColumnType("datetime");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Suscripcions)
                .HasForeignKey(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Empresa - Suscripcion");

            entity.HasOne(d => d.IdPaqueteNavigation).WithMany(p => p.Suscripcions)
                .HasForeignKey(d => d.IdPaquete)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Suscripciones - Paquete");
        });

        modelBuilder.Entity<Tarifa>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tarifa__3214EC0768C53FAC");

            entity.ToTable("Tarifa", "BALCAN");

            entity.Property(e => e.Registrado).HasColumnType("datetime");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC077598D68F");

            entity.ToTable("Usuario", "BALCAN");

            entity.HasIndex(e => e.Correo, "UQ__Usuario__60695A19AAFE9212").IsUnique();

            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Avatar)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("avatar");
            entity.Property(e => e.Contrasena).HasMaxLength(255);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Registrado).HasColumnType("datetime");
            entity.Property(e => e.Telefono)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Token)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.UsuarioFechaActualizacion).HasColumnName("Usuario_fecha_actualizacion");
            entity.Property(e => e.UsuarioFechaCreacion).HasColumnName("Usuario_fecha_creacion");
            entity.Property(e => e.UsuarioFechaEliminacion).HasColumnName("Usuario_fecha_eliminacion");
            entity.Property(e => e.UsuarioFkModificado).HasColumnName("Usuario_fk_modificado");

            entity.HasOne(d => d.IdEmpresaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdEmpresa)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Empresa - Usuarios");

            entity.HasOne(d => d.UsuarioFkModificadoNavigation).WithMany(p => p.InverseUsuarioFkModificadoNavigation)
                .HasForeignKey(d => d.UsuarioFkModificado)
                .HasConstraintName("Usuario_fk_modificado");
        });

        modelBuilder.Entity<UsuariobalcanNumerocolaborador>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__USUARIOB__3214EC275617488E");

            entity.ToTable("USUARIOBALCAN_NUMEROCOLABORADOR", "BALCAN");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.FechaCreacion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_CREACION");
            entity.Property(e => e.FechaModificacion)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_MODIFICACION");
            entity.Property(e => e.FkIdUsuarioBalcan).HasColumnName("FK_ID_USUARIO_BALCAN");
            entity.Property(e => e.NumeroColaborador)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("NUMERO_COLABORADOR");
            entity.Property(e => e.Saux1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SAUX1");
            entity.Property(e => e.Saux2)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SAUX2");
            entity.Property(e => e.Saux3)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SAUX3");
            entity.Property(e => e.Saux4)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SAUX4");
            entity.Property(e => e.Saux5)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("SAUX5");
            entity.Property(e => e.UsuarioModificacion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("USUARIO_MODIFICACION");
        });

        modelBuilder.Entity<VistaUsuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VistaUsu__3214EC075804BCC5");

            entity.ToTable("VistaUsuario", "BALCAN");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.VistaUsuarios)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Usuario - Permisos");

            entity.HasOne(d => d.IdVistaNavigation).WithMany(p => p.VistaUsuarios)
                .HasForeignKey(d => d.IdVista)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Vista - Permisos");
        });

        modelBuilder.Entity<Vistum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vista__3214EC07827B2CCD");

            entity.ToTable("Vista", "BALCAN");

            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.RouterLink)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Visible).HasColumnName("VIsible");

            entity.HasOne(d => d.IdModuloNavigation).WithMany(p => p.Vista)
                .HasForeignKey(d => d.IdModulo)
                .HasConstraintName("Modulo - Vistas");

            entity.HasOne(d => d.IdVistaPadreNavigation).WithMany(p => p.InverseIdVistaPadreNavigation)
                .HasForeignKey(d => d.IdVistaPadre)
                .HasConstraintName("Vista - Vistas");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
