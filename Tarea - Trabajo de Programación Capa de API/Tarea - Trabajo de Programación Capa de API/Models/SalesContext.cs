using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Tarea___Trabajo_de_Programación_Capa_de_API.Models;

public partial class SalesContext : DbContext
{
    public SalesContext()
    {
    }

    public SalesContext(DbContextOptions<SalesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Configuracion> Configuracions { get; set; }

    public virtual DbSet<DetalleVentas> DetalleVenta { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Negocio> Negocios { get; set; }

    public virtual DbSet<NumeroCorrelativo> NumeroCorrelativos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<RolMenu> RolMenus { get; set; }

    public virtual DbSet<TipoDocumentoVentum> TipoDocumentoVenta { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Ventas> Venta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC072EDF4ED3");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaElimino).HasColumnType("datetime");
            entity.Property(e => e.FechaMod).HasColumnType("datetime");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Configuracion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Configur__3214EC077405489D");

            entity.ToTable("Configuracion");

            entity.Property(e => e.Propiedad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Recurso)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Valor)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DetalleVentas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DetalleV__3214EC076885B941");

            entity.Property(e => e.CategoriaProducto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.DescripcionProducto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.MarcaProducto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.oCategoria).WithMany(p => p.DetalleVenta)
                .HasForeignKey(d => d.IdVenta)
                .HasConstraintName("FK__DetalleVe__IdVen__6EF57B66");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Menu__3214EC0794C2A3E8");

            entity.ToTable("Menu");

            entity.Property(e => e.Controlador)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FechaElimino).HasColumnType("datetime");
            entity.Property(e => e.FechaMod).HasColumnType("datetime");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Icono)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PaginaAccion)
                .HasMaxLength(30)
                .IsUnicode(false);

            entity.HasOne(d => d.IdMenuPadreNavigation).WithMany(p => p.InverseIdMenuPadreNavigation)
                .HasForeignKey(d => d.IdMenuPadre)
                .HasConstraintName("FK__Menu__IdMenuPadr__6FE99F9F");
        });

        modelBuilder.Entity<Negocio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Negocio__3214EC07E7AA9544");

            entity.ToTable("Negocio");

            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaElimino).HasColumnType("datetime");
            entity.Property(e => e.FechaMod).HasColumnType("datetime");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreLogo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PorcentajeImpuesto).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SimboloMoneda)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UrlLogo)
                .HasMaxLength(500)
                .IsUnicode(false);
        });

        modelBuilder.Entity<NumeroCorrelativo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__NumeroCo__3214EC0792A90341");

            entity.ToTable("NumeroCorrelativo");

            entity.Property(e => e.FechaActualizacion).HasColumnType("datetime");
            entity.Property(e => e.Gestion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Producto__3214EC07AF524335");

            entity.ToTable("Producto");

            entity.Property(e => e.CodigoBarra)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaElimino).HasColumnType("datetime");
            entity.Property(e => e.FechaMod).HasColumnType("datetime");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Marca)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreImagen)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UrlImagen)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK__Producto__IdCate__70DDC3D8");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rol__3214EC071983D67E");

            entity.ToTable("Rol");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.FechaElimino).HasColumnType("datetime");
            entity.Property(e => e.FechaMod).HasColumnType("datetime");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<RolMenu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RolMenu__3214EC0705730C08");

            entity.ToTable("RolMenu");

            entity.Property(e => e.FechaElimino).HasColumnType("datetime");
            entity.Property(e => e.FechaMod).HasColumnType("datetime");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.RolMenus)
                .HasForeignKey(d => d.IdMenu)
                .HasConstraintName("FK__RolMenu__IdMenu__71D1E811");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.RolMenus)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__RolMenu__IdRol__72C60C4A");
        });

        modelBuilder.Entity<TipoDocumentoVentum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TipoDocu__3214EC07D8EC2FF2");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaElimino).HasColumnType("datetime");
            entity.Property(e => e.FechaMod).HasColumnType("datetime");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC0760A826A2");

            entity.ToTable("Usuario");

            entity.Property(e => e.Clave)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaElimino).HasColumnType("datetime");
            entity.Property(e => e.FechaMod).HasColumnType("datetime");
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreFoto)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UrlFoto)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Usuario__IdRol__73BA3083");
        });

        modelBuilder.Entity<Ventas>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Venta__3214EC07DC9FA15A");

            entity.Property(e => e.CocumentoCliente)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ImpuestoTotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.NombreCliente)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NumeroVenta)
                .HasMaxLength(6)
                .IsUnicode(false);
            entity.Property(e => e.SubTotal).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdTipoDocumentoVentaNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdTipoDocumentoVenta)
                .HasConstraintName("FK__Venta__IdTipoDoc__74AE54BC");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Venta)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Venta__IdUsuario__75A278F5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
