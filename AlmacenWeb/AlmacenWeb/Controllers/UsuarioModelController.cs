using AlmacenWeb.Context;
using AlmacenWeb.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace AlmacenWeb.Controllers
{
    [Route("ModelUsuarios")]
    [ApiController]
    public class UsuarioModelController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (AlmacenContext context = new AlmacenContext())
            {
                var aux = context.Usuario;
                foreach (var item in aux)
                {
                    usuarios.Add(new Usuario
                    {
                        NombreU = item.NombreU,
                        Contrasena = item.Contrasena,
                        Nombre = item.Nombre,
                        Acceso = item.Acceso
                    });
                }
            }
            return new JsonResult(usuarios);
        }
        [HttpPost]
        public JsonResult PostUsuarios([FromBody]Usuario usr)
        {
            bool comprobacion = false;
            using(AlmacenContext context = new AlmacenContext())
            {
                context.Usuario.Add(usr);
                context.SaveChanges();
                comprobacion = true;
            }
            return new JsonResult(comprobacion);
        }
        [HttpPatch]
        public JsonResult UpdateUsuarios([FromBody] Usuario usr)
        {
            bool comprobacion = false;
            using (AlmacenContext context = new AlmacenContext())
            {
                var existe = context.Usuario.SingleOrDefault(u => u.NombreU == usr.NombreU);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.Usuario.Attach(usr);
                    context.Entry(usr).State = EntityState.Modified;
                    context.SaveChanges();
                    comprobacion = true;
                }
            }
            return new JsonResult(comprobacion);
        }
        [HttpDelete]
        public JsonResult DeleteUsuarios([FromBody] Usuario usr)
        {
            bool comprobacion = false;
            using (AlmacenContext context = new AlmacenContext())
            {
                var existe = context.Usuario.SingleOrDefault(u => u.NombreU == usr.NombreU);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.Usuario.Attach(usr);
                    context.Entry(usr).State = EntityState.Deleted;
                    context.SaveChanges();
                    comprobacion = true;
                }
            }
            return new JsonResult(comprobacion);
        }
    }
}
