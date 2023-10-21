using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Inventario.Clases;

namespace Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Usuarios : ControllerBase
    {
        [HttpGet]
        public JsonResult showUsers()
        {
            Usuario[] usuarios = new Usuario[5];
            for(int i = 0;i<5;i++)
            {
                usuarios[i] = new Usuario { 
                    Nombre = "Nombre"+(i+1),
                    Password = "Password" + (i+1),
                    Username = "Username" + (i+1),
                    Acceso = i+1
                };
            }
            return new JsonResult(usuarios);
        }
    }
}
