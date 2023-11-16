using AlmacenWeb.Model;
using AlmacenWeb.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlmacenWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetUsuario()
        {
            List<Usuario> usuarios = new List<Usuario>();
            using (AlmacenContext context = new AlmacenContext())
            {
                var aux = context.users;
                foreach (var item in aux)
                {
                    usuarios.Add(new Usuario
                    {
                        NombreUsuario = item.NombreUsuario,
                        Contraseña = item.Contraseña,
                        Nombre = item.Nombre,
                        Nivel = item.Nivel
                    });
                }
            }
            return new JsonResult(usuarios);
        }
        [HttpPost]
        public JsonResult PostUsuario([FromBody] Usuario user)
        {
            bool comprobacion = false;
            using (AlmacenContext context = new AlmacenContext())
            {
                context.users.Add(user);
                context.SaveChanges();
                comprobacion = true;
            }
            return new JsonResult(comprobacion);
        }
        [HttpPatch]
        public JsonResult UpdateUsuario([FromBody] Usuario user)
        {
            bool comprobacion = false;
            using (AlmacenContext context = new AlmacenContext())
            {
                var existe = context.users.SingleOrDefault(a => a.NombreUsuario == user.NombreUsuario);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.users.Attach(user);
                    context.Entry(user).State = EntityState.Modified;
                    context.SaveChanges();
                    comprobacion = true;
                }
            }
            return new JsonResult(comprobacion);
        }
        [HttpDelete]
        public JsonResult DeleteUsuario([FromBody] Usuario user)
        {
            bool comprobacion = false;
            using (AlmacenContext context = new AlmacenContext())
            {
                var existe = context.users.SingleOrDefault(a => a.NombreUsuario == user.NombreUsuario);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.users.Attach(user);
                    context.Entry(user).State = EntityState.Deleted;
                    context.SaveChanges();
                    comprobacion = true;
                }
            }
            return new JsonResult(comprobacion);
        }
    }
}
