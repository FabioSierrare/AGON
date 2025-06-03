using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    /// <summary>
    /// Representa una búsqueda de producto realizada por el usuario.
    /// </summary>
    public class Busquedas
    {
        /// <summary>
        /// Nombre del producto buscado.
        /// </summary>
        public string NombreProducto { get; set; }

        /// <summary>
        /// Categoría del producto.
        /// </summary>
        public string Categoria { get; set; }

        /// <summary>
        /// Precio original del producto.
        /// </summary>
        public decimal Precio { get; set; }

        /// <summary>
        /// Precio del producto con descuento (si aplica).
        /// </summary>
        public decimal? PrecioConDescuento { get; set; }

        /// <summary>
        /// URL de la imagen del producto.
        /// </summary>
        public string UrlImagen { get; set; }

        /// <summary>
        /// Porcentaje de descuento aplicado al producto (si aplica).
        /// </summary>
        public decimal? Descuento { get; set; }
    }
}
