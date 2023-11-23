using AlmacenWeb.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AlmacenWeb.Controllers
{
    [Route("DTOAlmacen")]
    [ApiController]
    public class DTOAlmacenController : ControllerBase
    {
        [HttpGet]
        public JsonResult ShowAll()
        {
            DTO_Almacen[] almacenes = new DTO_Almacen[3];
            for (int i = 0; i < 3; i++)
            {
                almacenes[i] = new DTO_Almacen
                {
                    Numero = i + 1,
                    Nombre = "Almacen" + (i + 1),
                    Inventarios = new DTO_Inventario[3]
                };

                for (int j = 0; j < 3; j++)
                {
                    almacenes[i].Inventarios[j] = new DTO_Inventario
                    {
                        Numero = j + 1,
                        Producto = new DTO_Producto[3],
                        Cantidad = 10,
                        DUE = "DUE" + j
                    };

                    for (int k = 0; k < 3; k++)
                    {
                        almacenes[i].Inventarios[j].Producto[k] = new DTO_Producto
                        {
                            SKU = k + 1,
                            Nombre = "Producto" + (k + 1),
                            Descripcion = "Descripcion" + (k + 1),
                            Foto = "Foto" + (k + 1),
                        };
                    }
                }
            }
            return new JsonResult(almacenes);
        }
    }
}
