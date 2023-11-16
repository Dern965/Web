using AlmacenWeb.Model;
using Microsoft.EntityFrameworkCore;

namespace AlmacenWeb.Context
{
    public class AlmacenContext : DbContext
    {
        public DbSet<Almacen> almacens { get; set; }
        public DbSet<Producto> products { get; set; }
        public DbSet<Inventario> inventaries { get; set; }
        public DbSet<Usuario> users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseMySQL("server=localhost; database=almacenes;user=root; password=admin");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
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

            modelBuilder.Entity<Usuario>(entity => {
                entity.HasKey(u => u.NombreUsuario);
                entity.Property(u => u.Contraseña);
                entity.Property(u => u.Nombre);
                entity.Property(u => u.Nivel);
            });
        }
    }
}
