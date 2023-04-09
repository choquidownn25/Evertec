using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Capa.Conexion.Modelos
{
    public partial class bookContext : DbContext
    {
        public bookContext()
        {
        }

        public bookContext(DbContextOptions<bookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autores> Autores { get; set; }
        public virtual DbSet<Editoriales> Editoriales { get; set; }
        public virtual DbSet<Libros> Libros { get; set; }

        // Unable to generate entity type for table 'dbo.autores_has_libros'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-4HMTI941;Database=book;user id=sa;password=2648;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Autores>(entity =>
            {
                entity.ToTable("autores");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Apellido)
                    .HasColumnName("apellido")
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Editoriales>(entity =>
            {
                entity.ToTable("editoriales");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Nombre)
                    .HasColumnName("nombre")
                    .HasMaxLength(50);

                entity.Property(e => e.Sede)
                    .HasColumnName("sede")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Libros>(entity =>
            {
                entity.ToTable("libros");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Ideditoriales).HasColumnName("ideditoriales");

                entity.Property(e => e.NPaginas)
                    .HasColumnName("n_paginas")
                    .HasMaxLength(50);

                entity.Property(e => e.Sinopsis)
                    .HasColumnName("sinopsis")
                    .HasColumnType("text");

                entity.Property(e => e.Titulo)
                    .HasColumnName("titulo")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdeditorialesNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.Ideditoriales)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_libros_editoriales");
            });
        }
    }
}
