using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace VentasNexTI.Models
{
    public partial class DBVENTASContext : DbContext
    {
        public DBVENTASContext()
        {
        }

        public DBVENTASContext(DbContextOptions<DBVENTASContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categoria { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;
        public virtual DbSet<UsuarioProducto> UsuarioProductos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PK__CATEGORI__A3C02A100306659E");

                entity.ToTable("CATEGORIA");

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.IdProducto)
                    .HasName("PK__PRODUCTO__098892104376A06E");

                entity.ToTable("PRODUCTO");

                entity.Property(e => e.DescripcionEvento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FechaEvento).HasColumnType("date");

                entity.Property(e => e.LugarEvento)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.oCategoria)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.CodCategoria)
                    .HasConstraintName("FK_IDCATEGORIA");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__USUARIO__5B65BF977414A817");

                entity.ToTable("USUARIO");

                entity.Property(e => e.Cedula).HasColumnName("cedula");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombre");
            });

            modelBuilder.Entity<UsuarioProducto>(entity =>
            {
                entity.HasKey(e => e.IdUsuarioProducto)
                    .HasName("PK__USUARIO___0061B62350C8814C");

                entity.ToTable("USUARIO_PRODUCTO");

                entity.HasOne(d => d.oProducto)
                    .WithMany(p => p.UsuarioProductos)
                    .HasForeignKey(d => d.CodProducto)
                    .HasConstraintName("FK_IDPRODUCTO");

                entity.HasOne(d => d.oUsuario)
                    .WithMany(p => p.UsuarioProductos)
                    .HasForeignKey(d => d.CodUsuario)
                    .HasConstraintName("FK_IDUSUARIO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
