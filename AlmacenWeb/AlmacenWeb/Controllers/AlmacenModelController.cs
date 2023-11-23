using AlmacenWeb.Context;
using AlmacenWeb.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlmacenWeb.Controllers
{
    [Route("ModelAlmacen")]
    [ApiController]
    public class AlmacenModelController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetAlmacen()
        {
            List<Almacen> almacenes = new List<Almacen>();
            using (AlmacenContext context = new AlmacenContext())
            {
                var aux = context.Almacen;
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
                context.Almacen.Add(alm);
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
                var existe = context.Almacen.SingleOrDefault(a => a.Numero == alm.Numero);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.Almacen.Attach(alm);
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
                var existe = context.Almacen.SingleOrDefault(a => a.Numero == alm.Numero);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.Almacen.Attach(alm);
                    context.Entry(alm).State = EntityState.Deleted;
                    context.SaveChanges();
                    comprobacion = true;
                }
            }
            return new JsonResult(comprobacion);
        }
    }
}
