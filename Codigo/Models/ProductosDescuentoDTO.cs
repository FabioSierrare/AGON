namespace E_Commerce.Models
{
    /// <summary>
    /// DTO que representa un producto con su información de descuento aplicada.
    /// </summary>
    public class ProductosDescuentoDTO
    {
        /// <summary>
        /// Identificador del producto.
        /// </summary>
        public int ProductoId { get; set; }

        /// <summary>
        /// Nombre del producto.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Precio original del producto sin descuento.
        /// </summary>
        public decimal PrecioOriginal { get; set; }

        /// <summary>
        /// URL de la imagen del producto.
        /// </summary>
        public string UrlImagen { get; set; }

        /// <summary>
        /// Porcentaje de descuento aplicado al producto.
        /// </summary>
        public decimal PorcentajeDescuento { get; set; }
    }
}
