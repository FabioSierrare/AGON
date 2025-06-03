using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    /// <summary>
    /// Representa la relación entre un producto y un descuento en el sistema de comercio electrónico.
    /// </summary>
    public class ProductosDescuento
    {
        /// <summary>
        /// Identificador único de la relación producto-descuento.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador del producto al que se aplica el descuento.
        /// </summary>
        public int ProductoId { get; set; }

        /// <summary>
        /// Identificador del descuento aplicado al producto.
        /// </summary>
        public int DescuentoId { get; set; }

        /// <summary>
        /// Objeto del descuento relacionado. No se serializa en JSON.
        /// </summary>
        [JsonIgnore]
        public Descuentos Descuento { get; set; }

        /// <summary>
        /// Objeto del producto relacionado. No se serializa en JSON.
        /// </summary>
        [JsonIgnore]
        public Productos Producto { get; set; }
    }
}
