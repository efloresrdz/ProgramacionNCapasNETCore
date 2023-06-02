using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class ProgramacionNcapasNetcoreContext : DbContext
{
    public ProgramacionNcapasNetcoreContext()
    {
    }

    public ProgramacionNcapasNetcoreContext(DbContextOptions<ProgramacionNcapasNetcoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<ProductoInventario> ProductoInventarios { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioFecha> UsuarioFechas { get; set; }

    public virtual DbSet<UsuarioProducto> UsuarioProductos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database=ProgramacionNCapasNETCore; TrustServerCertificate=True; Trusted_Connection=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK__Departam__787A433DCED70926");

            entity.ToTable("Departamento");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.IdMarca).HasName("PK__Marca__4076A8871782409C");

            entity.ToTable("Marca");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__Producto__098892105FCF53AF");

            entity.ToTable("Producto");

            entity.Property(e => e.CodigoBarras)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Descripcion)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.FechaIngreso).HasColumnType("date");
            entity.Property(e => e.Modelo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdDepartamento)
                .HasConstraintName("FK__Producto__IdDepa__25869641");

            entity.HasOne(d => d.IdMarcaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdMarca)
                .HasConstraintName("FK__Producto__IdMarc__267ABA7A");

            entity.HasOne(d => d.IdProveedorNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdProveedor)
                .HasConstraintName("FK__Producto__IdProv__276EDEB3");

            entity.HasOne(d => d.IdUsuarioModificacionNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdUsuarioModificacion)
                .HasConstraintName("FK__Producto__IdUsua__286302EC");
        });

        modelBuilder.Entity<ProductoInventario>(entity =>
        {
            entity.HasKey(e => e.IdProductoInventario).HasName("PK__Producto__E388F2A2487EA679");

            entity.ToTable("ProductoInventario");

            entity.Property(e => e.Cantidad).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.ProductoInventarios)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__ProductoI__IdPro__2B3F6F97");
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PK__Proveedo__E8B631AF1C49D8B9");

            entity.ToTable("Proveedor");

            entity.Property(e => e.Celular)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.PaginaWeb)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__Usuario__5B65BF97EA6A80DD");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.EmailEmpresarial, "UQ__Usuario__539E972DACDB8E3F").IsUnique();

            entity.HasIndex(e => e.ApellidoMaterno, "UQ__Usuario__71F621E82A73BD36").IsUnique();

            entity.HasIndex(e => e.Curp, "UQ__Usuario__F46C4CBF28607CCB").IsUnique();

            entity.Property(e => e.ApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Celular)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Curp)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CURP");
            entity.Property(e => e.EmailEmpresarial)
                .HasMaxLength(254)
                .IsUnicode(false);
            entity.Property(e => e.FechaNacimiento).HasColumnType("date");
            entity.Property(e => e.FechaRegistro).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sexo)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioModificacionNavigation).WithMany(p => p.InverseIdUsuarioModificacionNavigation)
                .HasForeignKey(d => d.IdUsuarioModificacion)
                .HasConstraintName("FK__Usuario__IdUsuar__1367E606");
        });

        modelBuilder.Entity<UsuarioFecha>(entity =>
        {
            entity.HasKey(e => e.IdUsuarioFecha).HasName("PK__UsuarioF__EE6BEFEDA7F89457");

            entity.ToTable("UsuarioFecha");

            entity.Property(e => e.FechaIngreso).HasColumnType("datetime");
            entity.Property(e => e.FechaSalida).HasColumnType("datetime");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(500)
                .IsUnicode(false);

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuarioFechas)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__UsuarioFe__IdUsu__164452B1");
        });

        modelBuilder.Entity<UsuarioProducto>(entity =>
        {
            entity.HasKey(e => e.IdUsuarioProducto).HasName("PK__UsuarioP__0061B623BE6C623A");

            entity.ToTable("UsuarioProducto");

            entity.Property(e => e.FechaAsignacion).HasColumnType("date");
            entity.Property(e => e.FechaEntrega).HasColumnType("date");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.UsuarioProductos)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__UsuarioPr__IdPro__2F10007B");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.UsuarioProductoIdUsuarioNavigations)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__UsuarioPr__IdUsu__2E1BDC42");

            entity.HasOne(d => d.IdUsuarioModificacionNavigation).WithMany(p => p.UsuarioProductoIdUsuarioModificacionNavigations)
                .HasForeignKey(d => d.IdUsuarioModificacion)
                .HasConstraintName("FK__UsuarioPr__IdUsu__300424B4");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
