using AlmacenWeb.Model;
using AlmacenWeb.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlmacenWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetInventario()
        {
            List<Inventario> inventarios = new List<Inventario>();
            using (AlmacenContext context = new AlmacenContext())
            {
                var aux = context.inventaries;
                foreach (var item in aux)
                {
                    inventarios.Add(new Inventario
                    {
                        Numero = item.Numero,
                        Producto = item.Producto,
                        Cantidad = item.Cantidad,
                        DUE = item.DUE
                    });
                }
            }
            return new JsonResult(inventarios);
        }
        [HttpPost]
        public JsonResult PostInventario([FromBody] Inventario inv)
        {
            bool comprobacion = false;
            using (AlmacenContext context = new AlmacenContext())
            {
                context.inventaries.Add(inv);
                context.SaveChanges();
                comprobacion = true;
            }
            return new JsonResult(comprobacion);
        }
        [HttpPatch]
        public JsonResult UpdateInventario([FromBody] Inventario inv)
        {
            bool comprobacion = false;
            using (AlmacenContext context = new AlmacenContext())
            {
                var existe = context.inventaries.SingleOrDefault(a => a.Numero == inv.Numero);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.inventaries.Attach(inv);
                    context.Entry(inv).State = EntityState.Modified;
                    context.SaveChanges();
                    comprobacion = true;
                }
            }
            return new JsonResult(comprobacion);
        }
        [HttpDelete]
        public JsonResult DeleteInventario([FromBody] Inventario inv)
        {
            bool comprobacion = false;
            using (AlmacenContext context = new AlmacenContext())
            {
                var existe = context.inventaries.SingleOrDefault(a => a.Numero == inv.Numero);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.inventaries.Attach(inv);
                    context.Entry(inv).State = EntityState.Deleted;
                    context.SaveChanges();
                    comprobacion = true;
                }
            }
            return new JsonResult(comprobacion);
        }
    }
}
