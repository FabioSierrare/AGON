namespace E_Commerce.Models
{
    public class ProductosDescuentoDTO
    {
        public int ProductoId { get; set; }
        public string Nombre { get; set; }
        public decimal PrecioOriginal { get; set; }
        public string UrlImagen { get; set; }
        public decimal PorcentajeDescuento { get; set; }
    }
}
