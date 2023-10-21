using Inventario.Clases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Almacenes : ControllerBase
    {
        [HttpGet]
        public JsonResult ShowAll()
        {
            Almacen[] almacenes = new Almacen[3];
            for (int i = 0; i < 3; i++)
            {
                almacenes[i] = new Almacen
                {
                    Numero = i + 1,
                    Nombre = "Almacen" + (i + 1),
                    Inventarios = new Inventarios[3]
                };

                for (int j = 0; j < 3; j++)
                {
                    almacenes[i].Inventarios[j] = new Inventarios
                    {
                        Numero = j + 1,
                        Producto = new Producto[3],
                        Cantidad = 10,
                        DUE = "DUE" + j
                    };

                    for (int k = 0; k < 3; k++)
                    {
                        almacenes[i].Inventarios[j].Producto[k] = new Producto
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
