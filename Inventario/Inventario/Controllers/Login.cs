using Inventario.Clases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Login : ControllerBase
    {
        [HttpPost]
        public bool LoginMethod([FromBody] Usuario usr)
        {
            bool regreso = false;
            if (usr != null)
            {
                if(usr.Username == "Dernamix" ||  usr.Password =="123")
                    regreso = true;
            }
            return regreso;
        }
    }
}
