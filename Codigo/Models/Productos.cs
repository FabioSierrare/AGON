using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using E_Commerce.Repositories.Interfaces;

namespace E_Commerce.Models
{
    /// <summary>
    /// Representa un producto dentro del sistema de comercio electrónico.
    /// </summary>
    public class Productos
    {
        /// <summary>
        /// Identificador único del producto.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre del producto.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Descripción detallada del producto.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Precio actual del producto.
        /// </summary>
        public decimal Precio { get; set; }

        /// <summary>
        /// Cantidad disponible en inventario.
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Fecha en la que el producto fue creado o registrado.
        /// </summary>
        public DateTime FechaCreacion { get; set; }

        /// <summary>
        /// Identificador de la categoría a la que pertenece el producto.
        /// </summary>
        public int CategoriaId { get; set; }

        /// <summary>
        /// Identificador del vendedor que ofrece el producto.
        /// </summary>
        public int VendedorId { get; set; }

        /// <summary>
        /// URL de la imagen del producto.
        /// </summary>
        public string UrlImagen { get; set; }

        /// <summary>
        /// Categoría relacionada del producto. No se serializa en JSON.
        /// </summary>
        [JsonIgnore]
        public Categorias? Categoria { get; set; }

        /// <summary>
        /// Lista de relaciones del producto con descuentos. No se serializa en JSON.
        /// </summary>
        [JsonIgnore]
        public ICollection<ProductosDescuento>? ProductosDescuento { get; set; }
    }
}
