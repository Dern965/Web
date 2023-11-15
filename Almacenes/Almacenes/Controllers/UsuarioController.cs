using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Almacenes.Model;
using Almacenes.Context;
using Microsoft.EntityFrameworkCore;

namespace Almacenes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetUsuario()
        {
            List<Usuario> listaUsuario = new List<Usuario>();
            using (AlmacenContext context = new AlmacenContext())
            {
                var aux = context.Usuarios;
                foreach(var item in aux)
                {
                    listaUsuario.Add(new Usuario
                    {
                        NombreUsuario = item.NombreUsuario,
                        Password = item.Password,
                        Nombre = item.Nombre,
                        Nivel = item.Nivel
                    });
                }
            }
            return new JsonResult(listaUsuario);
        }
        [HttpPost]
        public JsonResult PostUsuario(Usuario usuario)
        {
            bool comprobacion = false;
            using (AlmacenContext context = new AlmacenContext())
            {
                context.Usuarios.Add(usuario);
                context.SaveChanges();
                comprobacion = true;
            }
            return new JsonResult(comprobacion);
        }
        [HttpPatch]
        public JsonResult UpdateUsuario([FromBody] Usuario usuario)
        {
            bool comprobacion = false;
            using (AlmacenContext context = new AlmacenContext())
            {
                var existe = context.Usuarios.SingleOrDefault(a => a.NombreUsuario == usuario.NombreUsuario);
                if (existe != null)
                {
                    context.Entry(existe).State = EntityState.Detached;
                    context.Usuarios.Attach(usuario);
                    context.Entry(usuario).State = EntityState.Modified;
                    context.SaveChanges();
                    comprobacion = true;
                }
            }
            return new JsonResult(comprobacion);
        }
        /*[HttpPatch]
        public JsonResult DeleteUsuario([FromBody] Usuario usuario)
        {
            bool comprobacion = false;
            using (AlmacenContext context = new AlmacenContext())
            {
                var existe = context.Usuarios.SingleOrDefault(a => a.NombreUsuario == usuario.NombreUsuario);
                if (existe != null)
                {
                    context.Usuarios.Remove(existe);
                    context.SaveChanges();
                    comprobacion = true;
                }
            }
            return new JsonResult(comprobacion);
        }*/
    }
}
