using AlmacenWeb.DTO;
using AlmacenWeb.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlmacenWeb.Controllers
{
    [Route("DTOUsuario")]
    [ApiController]
    public class DTOUsuarioController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetUsuarios()
        {
            DTO_Usuario[] usuarios = new DTO_Usuario[5];
            for (int i = 0; i < 5; i++)
            {
                usuarios[i] = new DTO_Usuario
                {
                    Nombre = "Nombre" + (i + 1),
                    Contrasena = "Password" + (i + 1),
                    NombreU = "Username" + (i + 1),
                    Acceso = i + 1
                };
            }
            return new JsonResult(usuarios);
        }
        [HttpPost]
        public bool LoginMethod([FromBody] DTO_Usuario usr)
        {
            bool regreso = false;
            if (usr != null)
            {
                if (usr.NombreU == "Dernamix" || usr.Contrasena == "123")
                    regreso = true;
            }
            return regreso;
        }
    }
}
