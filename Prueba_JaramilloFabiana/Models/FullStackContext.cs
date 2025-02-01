using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Prueba_JaramilloFabiana.Models;

public partial class FullStackContext : DbContext
{
    public FullStackContext()
    {
    }

    public FullStackContext(DbContextOptions<FullStackContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Campo> Campos { get; set; }

    public virtual DbSet<Formulario> Formularios { get; set; }

    public virtual DbSet<Registro> Registros { get; set; }

    public virtual DbSet<Respuestum> Respuesta { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=full_stack;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Campo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Campo__3214EC0736A9BC0E");

            entity.ToTable("Campo");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo");

            entity.HasOne(d => d.Formulario).WithMany(p => p.Campos)
                .HasForeignKey(d => d.FormularioId)
                .HasConstraintName("FK__Campo__Formulari__398D8EEE");
        });

        modelBuilder.Entity<Formulario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Formular__3214EC07642D7DF6");

            entity.ToTable("Formulario");

            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Registro>(entity =>
        {
            entity.ToTable("Registro");

            entity.Property(e => e.FechaCreacion).HasColumnType("datetime");
        });

        modelBuilder.Entity<Respuestum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Respuest__3214EC07118F2C12");

            entity.Property(e => e.Valor)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Campo).WithMany(p => p.Respuesta)
                .HasForeignKey(d => d.CampoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Respuesta_Campo");

            entity.HasOne(d => d.Registro).WithMany(p => p.Respuesta)
                .HasForeignKey(d => d.RegistroId)
                .HasConstraintName("FK_Respuesta_Registro");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
