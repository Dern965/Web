namespace AlmacenWeb.DTO
{
    public class DTO_Almacen
    {
        public int Numero { get; set; }
        public string Nombre { get; set; }
        public DTO_Inventario[] Inventarios { get; set; }
    }
}
