using System;
using System.Text.Json.Serialization;
using E_Commerce.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace E_Commerce.Models
{

    /// <summary>
    /// Representa la imagen asociada a un producto.
    /// </summary>
    public class ImagenProducto
    {
        /// <summary>
        /// Identificador único de la imagen.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// URL de la imagen del producto.
        /// </summary>
        public string UrlImagen { get; set; }

        /// <summary>
        /// Identificador del producto al que pertenece esta imagen.
        /// </summary>
        public int ProductoId { get; set; }
    }
}
