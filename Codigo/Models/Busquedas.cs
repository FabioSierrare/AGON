using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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
        /// Id del producto buscado.
        /// </summary>
        public int ProductoId { get; set; }

        /// <summary>
        /// Descripcion del Producto.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Categoría del producto.
        /// </summary>
        [JsonIgnore]
        public string Categoria { get; set; }

        /// <summary>
        /// Referencia al id de la categoria del producto.
        /// </summary>
        public int CategoriaId { get; set; }

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
