using AlmacenWeb.Context;
using AlmacenWeb.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlmacenWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlmacenController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetAlmacen()
        {
            List<Almacen> almacenes = new List<Almacen>();
            using (AlmacenContext context = new AlmacenContext())
            {
                var aux = context.almacens;
                foreach (var item in aux)
                {
                    almacenes.Add(new Almacen
                    {
                        Numero = item.Numero,
                        Nombre = item.Nombre,
                        Inventarios = item.Inventarios
                    });
                }
            }
            return new JsonResult(almacenes);
        }
        [HttpPost]
        public JsonResult PostAlmacen([FromBody] Almacen alm)
        {
            bool comprobacion = false;
            using (AlmacenContext context = new AlmacenContext())
            {
                context.almacens.Add(alm);
                context.SaveChanges();
                comprobacion = true;
            }
            return new JsonResult(comprobacion);
        }
        [HttpPatch]
        public JsonResult UpdateAlmacen([FromBody] Almacen alm)
        {
            bool comprobacion = false;
            using (AlmacenContext context = new AlmacenContext())
            {
                var existe = context.almacens.SingleOrDefault(a => a.Numero == alm.Numero);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.almacens.Attach(alm);
                    context.Entry(alm).State = EntityState.Modified;
                    context.SaveChanges();
                    comprobacion = true;
                }
            }
            return new JsonResult(comprobacion);
        }
        [HttpDelete]
        public JsonResult DeleteAlmacen([FromBody] Almacen alm)
        {
            bool comprobacion = false;
            using (AlmacenContext context = new AlmacenContext())
            {
                var existe = context.almacens.SingleOrDefault(a => a.Numero == alm.Numero);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.almacens.Attach(alm);
                    context.Entry(alm).State = EntityState.Deleted;
                    context.SaveChanges();
                    comprobacion = true;
                }
            }
            return new JsonResult(comprobacion);
        }
    }
}
