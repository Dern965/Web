using AlmacenWeb.Model;
using AlmacenWeb.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlmacenWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetProducto()
        {
            List<Producto> productos = new List<Producto>();
            using (AlmacenContext context = new AlmacenContext())
            {
                var aux = context.products;
                foreach (var item in aux)
                {
                    productos.Add(new Producto
                    {
                        Numero_SKU = item.Numero_SKU,
                        Nombre = item.Nombre,
                        Descripcion = item.Descripcion,
                        Foto = item.Foto
                    });
                }
            }
            return new JsonResult(productos);
        }
        [HttpPost]
        public JsonResult PostProducto([FromBody] Producto prod)
        {
            bool comprobacion = false;
            using (AlmacenContext context = new AlmacenContext())
            {
                context.products.Add(prod);
                context.SaveChanges();
                comprobacion = true;
            }
            return new JsonResult(comprobacion);
        }
        [HttpPatch]
        public JsonResult UpdateProducto([FromBody] Producto prod)
        {
            bool comprobacion = false;
            using (AlmacenContext context = new AlmacenContext())
            {
                var existe = context.products.SingleOrDefault(a => a.Numero_SKU == prod.Numero_SKU);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.products.Attach(prod);
                    context.Entry(prod).State = EntityState.Modified;
                    context.SaveChanges();
                    comprobacion = true;
                }
            }
            return new JsonResult(comprobacion);
        }
        [HttpDelete]
        public JsonResult DeleteProducto([FromBody] Producto prod)
        {
            bool comprobacion = false;
            using (AlmacenContext context = new AlmacenContext())
            {
                var existe = context.products.SingleOrDefault(a => a.Numero_SKU == prod.Numero_SKU);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.products.Attach(prod);
                    context.Entry(prod).State = EntityState.Deleted;
                    context.SaveChanges();
                    comprobacion = true;
                }
            }
            return new JsonResult(comprobacion);
        }
    }
}
