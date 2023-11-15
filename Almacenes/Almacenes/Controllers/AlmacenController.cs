using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Almacenes.Model;
using Almacenes.Context;
using Microsoft.EntityFrameworkCore;

namespace Almacenes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlmacenController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetAlmacen()
        {
            List<Almacen> listaAlmacen = new List<Almacen>();
            using (AlmacenContext context = new AlmacenContext())
            {
                var aux = context.Almacenes;
                foreach(var item in aux)
                {
                    listaAlmacen.Add(new Almacen
                    {
                        Numero = item.Numero,
                        Nombre = item.Nombre,
                        Inventarios = item.Inventarios
                    });
                }
            }
            return new JsonResult(listaAlmacen);
        }
        [HttpPost]
        public JsonResult PostAlmacen(Almacen almacen)
        {
            bool comprobacion = false;
            using (AlmacenContext context = new AlmacenContext())
            {
                context.Almacenes.Add(almacen);
                context.SaveChanges();
                comprobacion = true;
            }
            return new JsonResult(comprobacion);
        }
        [HttpPatch]
        public JsonResult UpdateAlmacen([FromBody] Almacen almacen)
        {
            bool comprobacion = false;
            using (AlmacenContext context = new AlmacenContext())
            {
                var existe = context.Almacenes.SingleOrDefault(a => a.Numero == almacen.Numero);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.Almacenes.Attach(almacen);
                    context.Entry(almacen).State = EntityState.Modified;
                    context.SaveChanges();
                    comprobacion = true;
                }
            }
            return new JsonResult(comprobacion);
        }
        [HttpPatch]
        public JsonResult DeleteAlmacen([FromBody] Almacen almacen)
        {
            bool comprobacion = false;
            using (AlmacenContext context = new AlmacenContext())
            {
                var existe = context.Almacenes.SingleOrDefault(a => a.Numero == almacen.Numero);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.Almacenes.Attach(almacen);
                    context.Entry(almacen).State = EntityState.Deleted;
                    context.SaveChanges();
                    comprobacion = true;
                }
            }
            return new JsonResult(comprobacion);
        }
    }
}
