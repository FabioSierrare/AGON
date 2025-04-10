namespace E_Commerce.Models
{
    public class Busquedas
    {
        public string NombreProducto { get; set; }
        public string Categoria { get; set; }
        public decimal Precio { get; set; }
        public decimal? PrecioConDescuento { get; set; }
        public string UrlImagen { get; set; }
        public decimal? Descuento { get; set; }

    }
}
