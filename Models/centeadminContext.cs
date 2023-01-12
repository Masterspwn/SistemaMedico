using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CentePreNat.Models
{
    public partial class centeadminContext : DbContext
    {
        public centeadminContext()
        {
        }

        public centeadminContext(DbContextOptions<centeadminContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblDinamicafamiliar> TblDinamicafamiliars { get; set; } = null!;
        public virtual DbSet<TblFamiliare> TblFamiliares { get; set; } = null!;
        public virtual DbSet<TblInfoprenatal> TblInfoprenatals { get; set; } = null!;
        public virtual DbSet<TblPaciente> TblPacientes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Conexion", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.31-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<TblDinamicafamiliar>(entity =>
            {
                entity.HasKey(e => e.DimIdTipoFamilia)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_dinamicafamiliar");

                entity.HasIndex(e => e.DimHistorialClinico, "codigotipofam");

                entity.Property(e => e.DimIdTipoFamilia)
                    .ValueGeneratedNever()
                    .HasColumnName("dim_idTipoFamilia");

                entity.Property(e => e.DimHistorialClinico).HasColumnName("dim_HistorialClinico");

                entity.Property(e => e.DimTipoFamilia)
                    .HasMaxLength(100)
                    .HasColumnName("dim_TipoFamilia");

                entity.HasOne(d => d.DimHistorialClinicoNavigation)
                    .WithMany(p => p.TblDinamicafamiliars)
                    .HasForeignKey(d => d.DimHistorialClinico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("codigotipofam");
            });

            modelBuilder.Entity<TblFamiliare>(entity =>
            {
                entity.HasKey(e => e.FamIdFamiliar)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_familiares");

                entity.HasIndex(e => e.FamHistorialClinico, "codigoHistoria");

                entity.Property(e => e.FamIdFamiliar)
                    .ValueGeneratedNever()
                    .HasColumnName("fam_idFamiliar");

                entity.Property(e => e.FamEdad).HasColumnName("fam_edad");

                entity.Property(e => e.FamHistorialClinico).HasColumnName("fam_HistorialClinico");

                entity.Property(e => e.FamNombre)
                    .HasMaxLength(100)
                    .HasColumnName("fam_nombre");

                entity.Property(e => e.FamObservacion)
                    .HasMaxLength(255)
                    .HasColumnName("fam_observacion");

                entity.Property(e => e.FamParentesco)
                    .HasMaxLength(45)
                    .HasColumnName("fam_parentesco");

                entity.Property(e => e.FamProfesion)
                    .HasMaxLength(100)
                    .HasColumnName("fam_profesion");

                entity.HasOne(d => d.FamHistorialClinicoNavigation)
                    .WithMany(p => p.TblFamiliares)
                    .HasForeignKey(d => d.FamHistorialClinico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("codigoHistoria");
            });

            modelBuilder.Entity<TblInfoprenatal>(entity =>
            {
                entity.HasKey(e => e.PreIdInfo)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_infoprenatal");

                entity.HasIndex(e => e.PreHistorialClinico, "codigoHistoriapre");

                entity.Property(e => e.PreIdInfo)
                    .ValueGeneratedNever()
                    .HasColumnName("pre_idInfo");

                entity.Property(e => e.PreAborto)
                    .HasMaxLength(100)
                    .HasColumnName("pre_aborto");

                entity.Property(e => e.PreComplicaciones)
                    .HasMaxLength(100)
                    .HasColumnName("pre_complicaciones");

                entity.Property(e => e.PreEstadoEmocional)
                    .HasMaxLength(100)
                    .HasColumnName("pre_estadoEmocional");

                entity.Property(e => e.PreHistorialClinico).HasColumnName("pre_HistorialClinico");

                entity.Property(e => e.PreMotivo)
                    .HasMaxLength(100)
                    .HasColumnName("pre_motivo");

                entity.Property(e => e.PreNumeroEmbarazo).HasColumnName("pre_numeroEmbarazo");

                entity.Property(e => e.PrePlanificacion)
                    .HasMaxLength(255)
                    .HasColumnName("pre_planificacion");

                entity.Property(e => e.PreSaludMental)
                    .HasMaxLength(100)
                    .HasColumnName("pre_saludMental");

                entity.HasOne(d => d.PreHistorialClinicoNavigation)
                    .WithMany(p => p.TblInfoprenatals)
                    .HasForeignKey(d => d.PreHistorialClinico)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("codigoHistoriapre");
            });

            modelBuilder.Entity<TblPaciente>(entity =>
            {
                entity.HasKey(e => e.PacHistorialClinico)
                    .HasName("PRIMARY");

                entity.ToTable("tbl_paciente");

                entity.Property(e => e.PacHistorialClinico)
                    .ValueGeneratedNever()
                    .HasColumnName("pac_HistorialClinico");

                entity.Property(e => e.PacApellidos)
                    .HasMaxLength(45)
                    .HasColumnName("pac_apellidos");

                entity.Property(e => e.PacDireccion)
                    .HasMaxLength(45)
                    .HasColumnName("pac_direccion");

                entity.Property(e => e.PacEdad).HasColumnName("pac_edad");

                entity.Property(e => e.PacEmail)
                    .HasMaxLength(45)
                    .HasColumnName("pac_email");

                entity.Property(e => e.PacFentregainforme)
                    .HasColumnType("datetime")
                    .HasColumnName("pac_fentregainforme");

                entity.Property(e => e.PacFinformacion)
                    .HasColumnType("datetime")
                    .HasColumnName("pac_finformacion");

                entity.Property(e => e.PacFnacimiento).HasColumnName("pac_fnacimiento");

                entity.Property(e => e.PacGenero)
                    .HasMaxLength(45)
                    .HasColumnName("pac_genero");

                entity.Property(e => e.PacInstitucion)
                    .HasMaxLength(45)
                    .HasColumnName("pac_institucion");

                entity.Property(e => e.PacInstruccion)
                    .HasMaxLength(45)
                    .HasColumnName("pac_instruccion");

                entity.Property(e => e.PacTelefono)
                    .HasMaxLength(45)
                    .HasColumnName("pac_telefono");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
