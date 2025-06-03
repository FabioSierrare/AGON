using System;
using System.Text.Json.Serialization;
using E_Commerce.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace E_Commerce.Models
{
    public class Inventarios
    {
        /// <summary>
        /// Identificador único del registro de inventario.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador del producto asociado a este inventario.
        /// </summary>
        public int ProductoId { get; set; }

        /// <summary>
        /// Cantidad disponible del producto en inventario.
        /// </summary>
        public int Cantidad { get; set; }

        /// <summary>
        /// Fecha de la última actualización del inventario.
        /// </summary>
        public DateTime UltimaActualizacion { get; set; }
    }
}
