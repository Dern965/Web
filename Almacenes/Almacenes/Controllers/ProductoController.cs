using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Almacenes.Model;
using Almacenes.Context;
using Microsoft.EntityFrameworkCore;

namespace Almacenes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetProducto()
        {
            List<Producto> listaProducto = new List<Producto>();
            using (AlmacenContext context = new AlmacenContext())
            {
                var aux = context.Productos;
                foreach(var item in aux)
                {
                    listaProducto.Add(new Producto
                    {
                        Num_SKU = item.Num_SKU,
                        Nombre = item.Nombre,
                        Descripcion = item.Descripcion,
                        Foto = item.Foto,
                    });
                }
            }
            return new JsonResult(listaProducto);
        }
        [HttpPost]
        public JsonResult PostProducto(Producto producto)
        {
            bool comprobacion = false;
            using (AlmacenContext context = new AlmacenContext())
            {
                context.Productos.Add(producto);
                context.SaveChanges();
                comprobacion = true;
            }
            return new JsonResult(comprobacion);
        }
        [HttpPatch]
        public JsonResult UpdateProducto([FromBody] Producto producto)
        {
            bool comprobacion = false;
            using (AlmacenContext context = new AlmacenContext())
            {
                var existe = context.Productos.SingleOrDefault(a => a.Num_SKU == producto.Num_SKU);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.Productos.Attach(producto);
                    context.Entry(producto).State = EntityState.Modified;
                    context.SaveChanges();
                    comprobacion = true;
                }
            }
            return new JsonResult(comprobacion);
        }
        /*[HttpPatch]
        public JsonResult DeleteProducto([FromBody] Producto producto)
        {
            bool comprobacion = false;
            using (AlmacenContext context = new AlmacenContext())
            {
                var existe = context.Productos.SingleOrDefault(a => a.Num_SKU == producto.Num_SKU);
                if (existe != null)
                {
                    context.Productos.Remove(existe);
                    context.SaveChanges();
                    comprobacion = true;
                }
            }
            return new JsonResult(comprobacion);
        }*/
    }
}
