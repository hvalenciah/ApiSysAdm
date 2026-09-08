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

    public virtual DbSet<Log> Logs { get; set; }

    public virtual DbSet<Modulo> Modulos { get; set; }

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
