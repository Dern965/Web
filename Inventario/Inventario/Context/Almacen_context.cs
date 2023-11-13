using Microsoft.EntityFrameworkCore;
using Inventario.Clases;

namespace Inventario.Context
{
    public class Almacen_context : DbContext
    {
        public DbSet<Producto> productos {  get; set; }
        public DbSet<Usuario> usuarios { get; set; }

        public Almacen_context(DbContextOptions<Almacen_context> options) : base(options) { }
    }
}
