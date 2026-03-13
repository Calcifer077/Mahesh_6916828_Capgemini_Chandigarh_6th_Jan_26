using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Models;

public partial class HospitalDbContext : DbContext
{
    public HospitalDbContext()
    {
    }

    public HospitalDbContext(DbContextOptions<HospitalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=PC\\SQLEXPRESS;Database=HospitalDB;Trusted_Connection=True;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK__Appointm__8ECDFCC240D29657");

            entity.Property(e => e.AppointmentId).ValueGeneratedNever();
            entity.Property(e => e.AppointmentDate).HasColumnType("datetime");
            entity.Property(e => e.Remarks)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Doctor).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.DoctorId)
                .HasConstraintName("FK__Appointme__Docto__4E88ABD4");

            entity.HasOne(d => d.Patient).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.PatientId)
                .HasConstraintName("FK__Appointme__Patie__4D94879B");
        });

        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PK__Doctors__2DC00EBFC48C57C8");

            entity.Property(e => e.DoctorId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Specialization)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.HasKey(e => e.PatientId).HasName("PK__Patients__970EC36680B89227");

            entity.Property(e => e.PatientId).ValueGeneratedNever();
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
