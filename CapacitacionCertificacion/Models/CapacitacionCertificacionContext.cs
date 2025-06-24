using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CapacitacionCertificacion.Models;

public partial class CapacitacionCertificacionContext : DbContext
{
    public CapacitacionCertificacionContext()
    {
    }

    public CapacitacionCertificacionContext(DbContextOptions<CapacitacionCertificacionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AsignacionesCurso> AsignacionesCursos { get; set; }

    public virtual DbSet<Certificacione> Certificaciones { get; set; }

    public virtual DbSet<Curso> Cursos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<EvaluacionesSatisfaccion> EvaluacionesSatisfaccions { get; set; }

    public virtual DbSet<InformesCumplimiento> InformesCumplimientos { get; set; }

    public virtual DbSet<Programa> Programas { get; set; }

    public virtual DbSet<Recordatorio> Recordatorios { get; set; }

    public virtual DbSet<TipoInforme> TipoInformes { get; set; }

    public virtual DbSet<TipoRecordatorio> TipoRecordatorios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=MAXI; Database=CapacitacionCertificacion; User=sa; Password=Maxi10022003; Encrypt=False; Connect Timeout=30;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AsignacionesCurso>(entity =>
        {
            entity.HasKey(e => e.IdAsign).HasName("PK__Asignaci__EFEC89EC99EFE626");

            entity.Property(e => e.IdAsign).HasColumnName("ID_Asign");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaAsign).HasColumnName("Fecha_Asign");
            entity.Property(e => e.FechaFinalizacion).HasColumnName("Fecha_Finalizacion");
            entity.Property(e => e.IdCurso).HasColumnName("ID_Curso");
            entity.Property(e => e.IdEmp).HasColumnName("ID_Emp");

            entity.HasOne(d => d.IdCursoNavigation).WithMany(p => p.AsignacionesCursos)
                .HasForeignKey(d => d.IdCurso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asignacion_Curso");

            entity.HasOne(d => d.IdEmpNavigation).WithMany(p => p.AsignacionesCursos)
                .HasForeignKey(d => d.IdEmp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Asignacion_Empleado");
        });

        modelBuilder.Entity<Certificacione>(entity =>
        {
            entity.HasKey(e => e.IdCert).HasName("PK__Certific__731C6D8BA70421C2");

            entity.Property(e => e.IdCert).HasColumnName("ID_Cert");
            entity.Property(e => e.DescripcionCer)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("Descripcion_Cer");
            entity.Property(e => e.FechaEmision).HasColumnName("Fecha_Emision");
            entity.Property(e => e.FechaExpiracion).HasColumnName("Fecha_Expiracion");
            entity.Property(e => e.IdAsign).HasColumnName("ID_Asign");

            entity.HasOne(d => d.IdAsignNavigation).WithMany(p => p.Certificaciones)
                .HasForeignKey(d => d.IdAsign)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Certificaciones_Asignacion");
        });

        modelBuilder.Entity<Curso>(entity =>
        {
            entity.HasKey(e => e.IdCurso).HasName("PK__Cursos__DC72196F902C69F7");

            entity.Property(e => e.IdCurso).HasColumnName("ID_Curso");
            entity.Property(e => e.DuracionHoras).HasColumnName("Duracion_Horas");
            entity.Property(e => e.IdPg).HasColumnName("ID_pg");
            entity.Property(e => e.Modalidad)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreCurso)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Nombre_Curso");

            entity.HasOne(d => d.IdPgNavigation).WithMany(p => p.Cursos)
                .HasForeignKey(d => d.IdPg)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cursos_Programa");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmp).HasName("PK__Empleado__2D4D3A230B29F6A3");

            entity.Property(e => e.IdEmp).HasColumnName("ID_Emp");
            entity.Property(e => e.CorreoEmp)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Correo_Emp");
            entity.Property(e => e.Departamento)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FechaContratacion).HasColumnName("Fecha_Contratacion");
            entity.Property(e => e.NombreEmp)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Nombre_Emp");
        });

        modelBuilder.Entity<EvaluacionesSatisfaccion>(entity =>
        {
            entity.HasKey(e => e.IdEva).HasName("PK__Evaluaci__2D52F12D656700D1");

            entity.ToTable("EvaluacionesSatisfaccion");

            entity.Property(e => e.IdEva).HasColumnName("ID_Eva");
            entity.Property(e => e.Comentario)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.FechaEva).HasColumnName("Fecha_Eva");
            entity.Property(e => e.IdAsign).HasColumnName("ID_Asign");

            entity.HasOne(d => d.IdAsignNavigation).WithMany(p => p.EvaluacionesSatisfaccions)
                .HasForeignKey(d => d.IdAsign)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Evaluacion_Asignacion");
        });

        modelBuilder.Entity<InformesCumplimiento>(entity =>
        {
            entity.HasKey(e => e.IdInfor).HasName("PK__Informes__2C73BC6B6415DFA6");

            entity.ToTable("InformesCumplimiento");

            entity.Property(e => e.IdInfor).HasColumnName("ID_Infor");
            entity.Property(e => e.DescripcionInfor)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Descripcion_Infor");
            entity.Property(e => e.FechaEmision).HasColumnName("Fecha_Emision");
            entity.Property(e => e.IdEmp).HasColumnName("ID_Emp");
            entity.Property(e => e.IdTipoInforme).HasColumnName("ID_Tipo_Informe");

            entity.HasOne(d => d.IdEmpNavigation).WithMany(p => p.InformesCumplimientos)
                .HasForeignKey(d => d.IdEmp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Informe_Empleado");

            entity.HasOne(d => d.IdTipoInformeNavigation).WithMany(p => p.InformesCumplimientos)
                .HasForeignKey(d => d.IdTipoInforme)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Informe_TipoInforme");
        });

        modelBuilder.Entity<Programa>(entity =>
        {
            entity.HasKey(e => e.IdPg).HasName("PK__Programa__8B609C6A496F163D");

            entity.ToTable("Programa");

            entity.Property(e => e.IdPg).HasColumnName("ID_pg");
            entity.Property(e => e.DescripcionPg)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Descripcion_pg");
            entity.Property(e => e.FechaFinPg).HasColumnName("Fecha_fin_pg");
            entity.Property(e => e.FechaInicioPg).HasColumnName("Fecha_inicio_pg");
            entity.Property(e => e.NombrePg)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Nombre_pg");
        });

        modelBuilder.Entity<Recordatorio>(entity =>
        {
            entity.HasKey(e => e.IdRecord).HasName("PK__Recordat__1070D2CED87FF9E3");

            entity.Property(e => e.IdRecord).HasColumnName("ID_Record");
            entity.Property(e => e.FechaEjecucion).HasColumnName("Fecha_Ejecucion");
            entity.Property(e => e.IdEmp).HasColumnName("ID_Emp");
            entity.Property(e => e.IdTipoRecord).HasColumnName("ID_Tipo_Record");
            entity.Property(e => e.MensajeRecord)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("Mensaje_Record");

            entity.HasOne(d => d.IdEmpNavigation).WithMany(p => p.Recordatorios)
                .HasForeignKey(d => d.IdEmp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Recordatorio_Empleado");

            entity.HasOne(d => d.IdTipoRecordNavigation).WithMany(p => p.Recordatorios)
                .HasForeignKey(d => d.IdTipoRecord)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Recordatorio_TipoRecordatorio");
        });

        modelBuilder.Entity<TipoInforme>(entity =>
        {
            entity.HasKey(e => e.IdTipoInforme).HasName("PK__Tipo_Inf__861D91F345DF805B");

            entity.ToTable("Tipo_Informe");

            entity.Property(e => e.IdTipoInforme).HasColumnName("ID_Tipo_Informe");
            entity.Property(e => e.NombreTipo)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Nombre_Tipo");
        });

        modelBuilder.Entity<TipoRecordatorio>(entity =>
        {
            entity.HasKey(e => e.IdTipoRecord).HasName("PK__Tipo_Rec__D14CAD7F2FC51EC1");

            entity.ToTable("Tipo_Recordatorio");

            entity.Property(e => e.IdTipoRecord).HasColumnName("ID_Tipo_Record");
            entity.Property(e => e.DescripcionTipo)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("Descripcion_Tipo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
