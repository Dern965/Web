
namespace AlmacenWeb.DTO
{
    public class DTO_Inventario
    {
        public int Numero { get; set; }
        public DTO_Producto[] Producto { get; set; }
        public int Cantidad { get; set; }
        public string DUE { get; set; }
    }
}
