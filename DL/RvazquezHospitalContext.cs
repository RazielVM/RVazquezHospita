using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class RvazquezHospitalContext : DbContext
{
    public RvazquezHospitalContext()
    {
    }

    public RvazquezHospitalContext(DbContextOptions<RvazquezHospitalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Especialidad> Especialidads { get; set; }

    public virtual DbSet<Hospital> Hospitals { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.; Database=RVazquezHospital; TrustServerCertificate=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Especialidad>(entity =>
        {
            entity.HasKey(e => e.IdEspecialidad).HasName("PK_IdEspecialidad");

            entity.ToTable("Especialidad");

            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Hospital>(entity =>
        {
            entity.HasKey(e => e.IdHospital).HasName("PK_IdHospital");

            entity.ToTable("Hospital");

            entity.Property(e => e.AñoConstruccion).HasColumnType("date");
            entity.Property(e => e.Direccion)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdEspecialidadNavigation).WithMany(p => p.Hospitals)
                .HasForeignKey(d => d.IdEspecialidad)
                .HasConstraintName("FK_IdHospitalEspecialidad");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
