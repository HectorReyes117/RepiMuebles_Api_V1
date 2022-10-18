using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MuebleriaRepiAPI.Models
{
    public partial class dbMuebleriaRepiContext : DbContext
    {
        public dbMuebleriaRepiContext()
        {
        }

        public dbMuebleriaRepiContext(DbContextOptions<dbMuebleriaRepiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categorium> Categoria { get; set; } = null!;
        public virtual DbSet<FormularioCompra> FormularioCompras { get; set; } = null!;
        public virtual DbSet<Marca> Marcas { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Reclamacione> Reclamaciones { get; set; } = null!;
        public virtual DbSet<Registrar> Registrars { get; set; } = null!;
        public virtual DbSet<Solicitar> Solicitars { get; set; } = null!;
        public virtual DbSet<SolicitudEmpleado> SolicitudEmpleados { get; set; } = null!;
        public virtual DbSet<Vacante> Vacantes { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__Categori__8A3D240CEB864849");

                entity.HasIndex(e => e.Categoria, "UQ__Categori__08015F8B73F83FED")
                    .IsUnique();

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.Categoria)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<FormularioCompra>(entity =>
            {
                entity.HasKey(e => e.IdFormularioCompra)
                    .HasName("PK__Formular__7DBA1F2DF69977DA");

                entity.ToTable("FormularioCompra");

                entity.Property(e => e.IdFormularioCompra).HasColumnName("idFormularioCompra");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion).HasColumnType("text");

                entity.Property(e => e.Email)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Producto)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Sucursal)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Marca>(entity =>
            {
                entity.HasKey(e => e.IdMarca)
                    .HasName("PK__Marcas__7033181257A2E1E3");

                entity.Property(e => e.IdMarca).HasColumnName("idMarca");

                entity.Property(e => e.ImagenMarca).HasColumnType("text");

                entity.Property(e => e.NombreMarca)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__Producto__07F4A132842BF360");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.Property(e => e.Descripcion).HasColumnType("text");

                entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");

                entity.Property(e => e.IdMarca).HasColumnName("idMarca");

                entity.Property(e => e.Imagen).HasColumnType("text");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("FK__Productos__idCat__2DE6D218");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdMarca)
                    .HasConstraintName("FK__Productos__idMar__2EDAF651");
            });

            modelBuilder.Entity<Reclamacione>(entity =>
            {
                entity.HasKey(e => e.IdReclamaciones)
                    .HasName("PK__Reclamac__AE8BBEFD95BEC5A1");

                entity.Property(e => e.IdReclamaciones).HasColumnName("idReclamaciones");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Comentario).HasColumnType("text");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroFactura)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("Numero_Factura");

                entity.Property(e => e.Producto)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Sucursal)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Registrar>(entity =>
            {
                entity.ToTable("Registrar");

                entity.HasIndex(e => e.NombreUsuario, "UQ__Registra__6B0F5AE02ABCBE1F")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Registra__A9D105348C9A4E64")
                    .IsUnique();

                entity.Property(e => e.Apellido)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TipoUsuario)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Solicitar>(entity =>
            {
                entity.HasKey(e => e.IdSolicitar)
                    .HasName("PK__Solicita__D8054F3B6DA6FEC3");

                entity.ToTable("Solicitar");

                entity.Property(e => e.IdSolicitar).HasColumnName("idSolicitar");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ArticuloFinanciar)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.CompraAnterior)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.DondeSolicitarCredito)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.DondeTrabaja)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.JefeInmediato)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Puestos)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.SectorVive)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.TelefonoLabora)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.TiempoEmpresa)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.ViviendaPropia)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SolicitudEmpleado>(entity =>
            {
                entity.HasKey(e => e.IdSolicitudEmp)
                    .HasName("PK__Solicitu__DB1E7CE7CC8D086C");

                entity.Property(e => e.IdSolicitudEmp).HasColumnName("idSolicitudEmp");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Cedula)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Celular)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion).HasColumnType("text");

                entity.Property(e => e.Email)
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoCivil)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoEstudio)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Estudios)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ExperienciaLaboral)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Genero)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Labora)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Licencia)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Nacionalidad)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.NivelAcademico)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Posicion)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Sucursal)
                    .HasMaxLength(600)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vacante>(entity =>
            {
                entity.HasKey(e => e.IdVacantes)
                    .HasName("PK__Vacantes__91D1655EFB772ADE");

                entity.Property(e => e.IdVacantes).HasColumnName("idVacantes");

                entity.Property(e => e.DescripciónPuesto).HasColumnType("text");

                entity.Property(e => e.EstimacionSalarial)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Posicion)
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Sucursal).HasColumnType("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
