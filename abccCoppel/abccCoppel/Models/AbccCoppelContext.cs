using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace abccCoppel.Models;

public partial class AbccCoppelContext : DbContext
{
    public AbccCoppelContext()
    {
    }

    public AbccCoppelContext(DbContextOptions<AbccCoppelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Clase> Clases { get; set; }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Familium> Familia { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-1OPDUR6I\\INSTANCIA19; Database=abccCoppel; Trusted_Connection=True; User Id=sa; Password=Erick123; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clase>(entity =>
        {
            entity.HasKey(e => e.NumClase).HasName("PK__Clase__9751F846BCD3F1D5");

            entity.ToTable("Clase");

            entity.Property(e => e.NumClase).HasColumnName("Num_Clase");
            entity.Property(e => e.NombreClase)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_Clase");
        });

        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.NumDepartamento).HasName("PK__Departam__150A678C9D73EF63");

            entity.ToTable("Departamento");

            entity.Property(e => e.NumDepartamento).HasColumnName("Num_Departamento");
            entity.Property(e => e.NombreDepartamento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_Departamento");
        });

        modelBuilder.Entity<Familium>(entity =>
        {
            entity.HasKey(e => e.NumFamilia).HasName("PK__Familia__2931CDCE68367ABE");

            entity.Property(e => e.NumFamilia).HasColumnName("Num_Familia");
            entity.Property(e => e.NombreFamilia)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Nombre_Familia");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Sku).HasName("PK__Producto__CA1FD3C4BAF5A297");

            entity.Property(e => e.Articulo)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.FechaAlta)
                .HasColumnType("date")
                .HasColumnName("Fecha_Alta");
            entity.Property(e => e.FechaBaja)
                .HasColumnType("date")
                .HasColumnName("Fecha_Baja");
            entity.Property(e => e.Marca)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Modelo)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.NumClase).HasColumnName("Num_Clase");
            entity.Property(e => e.NumDepartamento).HasColumnName("Num_Departamento");
            entity.Property(e => e.NumFamilia).HasColumnName("Num_Familia");

            entity.HasOne(d => d.NumClaseNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.NumClase)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productos__Num_C__59063A47");

            entity.HasOne(d => d.NumDepartamentoNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.NumDepartamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productos__Num_D__59FA5E80");

            entity.HasOne(d => d.NumFamiliaNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.NumFamilia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productos__Num_F__5AEE82B9");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
