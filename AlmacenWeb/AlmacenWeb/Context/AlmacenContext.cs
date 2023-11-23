using AlmacenWeb.Model;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;

namespace AlmacenWeb.Context
{
    public class AlmacenContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Almacen> Almacen { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Inventario> Inventario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=almacenes;user=root;password=admin");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>(e =>
            {
                e.HasKey(u => u.NombreU);
                e.Property(u => u.Contrasena);
                e.Property(u => u.Nombre);
                e.Property(u => u.Acceso);
            });

            modelBuilder.Entity<Almacen>(entiy =>
            {
                entiy.HasKey(a => a.Numero);
                entiy.Property(a => a.Nombre);
                entiy.Property(a => a.Inventarios);
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.HasKey(p => p.Numero_SKU);
                entity.Property(p => p.Nombre);
                entity.Property(p => p.Descripcion);
                entity.Property(p => p.Foto);
            });

            modelBuilder.Entity<Inventario>(entity => {
                entity.HasKey(i => i.Numero);
                entity.Property(i => i.Producto);
                entity.Property(i => i.Cantidad);
                entity.Property(i => i.DUE);
            });
        }
    }
}
