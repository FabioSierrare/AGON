using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    /// <summary>
    /// Representa una valoración realizada por un usuario sobre un producto.
    /// </summary>
    public class Valoraciones
    {
        /// <summary>
        /// Identificador único de la valoración.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador del usuario que realizó la valoración.
        /// </summary>
        public int UsuarioId { get; set; }

        /// <summary>
        /// Identificador del producto valorado.
        /// </summary>
        public int ProductoId { get; set; }

        /// <summary>
        /// Valor asignado al producto (por ejemplo, de 1 a 5).
        /// </summary>
        public int Valor { get; set; }

        /// <summary>
        /// Fecha en que se realizó la valoración.
        /// </summary>
        public DateTime FechaValoracion { get; set; }
    }
}
