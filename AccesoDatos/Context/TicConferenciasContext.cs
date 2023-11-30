using System;
using System.Collections.Generic;
using AccesoDatos.Models;
using Microsoft.EntityFrameworkCore;

namespace AccesoDatos.Context;

public partial class TicConferenciasContext : DbContext
{
    public TicConferenciasContext()
    {
    }

    public TicConferenciasContext(DbContextOptions<TicConferenciasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Conferencia> Conferencias { get; set; }

    public virtual DbSet<Participante> Participantes { get; set; }

    public virtual DbSet<Registro> Registros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-MHORHE3;Database=ticConferencias;Trust Server Certificate=true;User Id=sa;Password=root;MultipleActiveResultSets=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Conferencia>(entity =>
        {
            entity.HasKey(e => e.IdConference);

            entity.ToTable("conferencias");

            entity.Property(e => e.IdConference).HasColumnName("id_conference");
            entity.Property(e => e.Conferencista)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("conferencista");
            entity.Property(e => e.Horario)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("horario");
            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Participante>(entity =>
        {
            entity.HasKey(e => e.IdParticipante).HasName("PK_participantes");

            entity.ToTable("participante");

            entity.Property(e => e.IdParticipante).HasColumnName("id_participante");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(120)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Avatar).HasColumnName("avatar");
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Twitter)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("twitter");
        });

        modelBuilder.Entity<Registro>(entity =>
        {
            entity.ToTable("registro");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Confirmacion).HasColumnName("confirmacion");
            entity.Property(e => e.IdConference).HasColumnName("id_conference");
            entity.Property(e => e.IdParticipante).HasColumnName("id_participante");

            entity.HasOne(d => d.IdConferenceNavigation).WithMany(p => p.Registros)
                .HasForeignKey(d => d.IdConference)
                .HasConstraintName("FK_registro_conferencia");

            entity.HasOne(d => d.IdParticipanteNavigation).WithMany(p => p.Registros)
                .HasForeignKey(d => d.IdParticipante)
                .HasConstraintName("FK_registro_participante");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
