using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Almacenes.Model;
using Almacenes.Context;
using Microsoft.EntityFrameworkCore;

namespace Almacenes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetInventario()
        {
            List<Inventario> listaInventario = new List<Inventario>();
            using (AlmacenContext context = new AlmacenContext())
            {
                var aux = context.Inventarios;
                foreach (var item in aux)
                {
                    listaInventario.Add(new Inventario
                    {
                        Numero = item.Numero,
                        Producto = item.Producto,
                        Cantidad = item.Cantidad,
                        DUE = item.DUE
                    });
                }
            }
            return new JsonResult(listaInventario);
        }
        [HttpPost]
        public JsonResult PostInventario(Inventario inventario)
        {
            bool comprobacion = false;
            using (AlmacenContext context = new AlmacenContext())
            {
                context.Inventarios.Add(inventario);
                context.SaveChanges();
                comprobacion = true;
            }
            return new JsonResult(comprobacion);
        }
        [HttpPatch]
        public JsonResult UpdateInventario([FromBody] Inventario inventario)
        {
            bool comprobacion = false;
            using (AlmacenContext context = new AlmacenContext())
            {
                var existe = context.Inventarios.SingleOrDefault(a => a.Numero == inventario.Numero);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.Inventarios.Attach(inventario);
                    context.Entry(inventario).State = EntityState.Modified;
                    context.SaveChanges();
                    comprobacion = true;
                }
            }
            return new JsonResult(comprobacion);
        }
        /*[HttpPatch]
        public JsonResult DeleteInventario([FromBody] Inventario inventario)
        {
            bool comprobacion = false;
            using (AlmacenContext context = new AlmacenContext())
            {
                var existe = context.Inventarios.SingleOrDefault(a => a.Numero == inventario.Numero);
                if (existe != null)
                {
                    context.Inventarios.Remove(inventario);
                    context.SaveChanges();
                    comprobacion = true;
                }
            }
            return new JsonResult(comprobacion);
        }*/
    }
}
