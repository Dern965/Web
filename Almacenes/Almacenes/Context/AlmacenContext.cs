using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;

using Almacenes.Model;

namespace Almacenes.Context
{
    public class AlmacenContext : DbContext
    {
        public DbSet<Almacen> Almacenes { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseMySQL("server=localhost; port=3306;database=Almacen; user=root; password=admin");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Almacen>(entity =>
            {
                entity.HasKey(e => e.Numero);
                entity.Property(e => e.Nombre);
                entity.Property(e => e.Inventarios);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(e => e.Num_SKU);
                entity.Property(e => e.Nombre);
                entity.Property(e => e.Descripcion);
                entity.Property(e => e.Foto);
            });

            modelBuilder.Entity<Inventario>(entity =>
            {
                entity.HasKey(e => e.Numero);
                entity.Property(e => e.Producto);
                entity.Property(e => e.Cantidad);
                entity.Property(e => e.DUE);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.NombreUsuario);
                entity.Property(e => e.Password);
                entity.Property(e => e.Nombre);
                entity.Property(e => e.Nivel);
            });
        }
    }
}
