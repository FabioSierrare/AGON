using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    /// <summary>
    /// Representa un reporte de acciones realizadas por un usuario en el sistema.
    /// </summary>
    public class ReporteAcciones
    {
        /// <summary>
        /// Identificador único del reporte de acción.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador del usuario que realizó la acción.
        /// </summary>
        public int UsuarioId { get; set; }

        /// <summary>
        /// Descripción detallada de la acción realizada.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Fecha y hora en que se generó el reporte.
        /// </summary>
        public DateTime FechaReporte { get; set; }
    }
}
