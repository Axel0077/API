using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Models
{
    public partial class ChinookContext : DbContext
    {
    
        public ChinookContext(DbContextOptions<ChinookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Album> Album { get; set; }
        public virtual DbSet<Artista> Artista { get; set; }
        public virtual DbSet<Cancion> Cancion { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<DetalleFactura> DetalleFactura { get; set; }
        public virtual DbSet<Empleado> Empleado { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Genero> Genero { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>(entity =>
            {
                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Artista)
                    .WithMany(p => p.Album)
                    .HasForeignKey(d => d.ArtistaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Album_Artista");
            });

            modelBuilder.Entity<Artista>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Cancion>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Album)
                    .WithMany(p => p.Cancion)
                    .HasForeignKey(d => d.AlbumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cancion_Album");

                entity.HasOne(d => d.Genero)
                    .WithMany(p => p.Cancion)
                    .HasForeignKey(d => d.GeneroId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cancion_Genero");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email).HasMaxLength(20);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Soporte)
                    .WithMany(p => p.Cliente)
                    .HasForeignKey(d => d.SoporteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Empleado");
            });

            modelBuilder.Entity<DetalleFactura>(entity =>
            {
                entity.Property(e => e.PrecioUnidad).HasColumnType("decimal(6, 2)");

                entity.HasOne(d => d.Cancion)
                    .WithMany(p => p.DetalleFactura)
                    .HasForeignKey(d => d.CancionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleFactura_Cancion");

                entity.HasOne(d => d.Factura)
                    .WithMany(p => p.DetalleFactura)
                    .HasForeignKey(d => d.FacturaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetalleFactura_Factura");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.Property(e => e.Apellidos)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Cargo)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Nombres)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.Property(e => e.FechaFactura).HasColumnType("date");

                entity.Property(e => e.Total).HasColumnType("numeric(6, 2)");

                entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Factura)
                    .HasForeignKey(d => d.ClienteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Factura_Cliente");
            });

            modelBuilder.Entity<Genero>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
