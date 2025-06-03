using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    /// <summary>
    /// Representa una categoría de producto en el sistema.
    /// </summary>
    public class Categorias
    {
        /// <summary>
        /// Identificador único de la categoría.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre de la categoría.
        /// </summary>
        public string Nombre { get; set; }
    }
}
