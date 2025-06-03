using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    /// <summary>
    /// Modelo que representa un ticket de soporte técnico creado por un usuario.
    /// </summary>
    public class TicketsSoporte
    {
        /// <summary>
        /// Identificador único del ticket de soporte.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador del usuario que creó el ticket.
        /// </summary>
        public int UsuarioId { get; set; }

        /// <summary>
        /// Título del ticket de soporte.
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Descripción detallada del problema o solicitud de soporte.
        /// </summary>
        public string Descripcion { get; set; }

        /// <summary>
        /// Estado actual del ticket (por ejemplo: "Abierto", "En Proceso", "Cerrado").
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// Fecha en la que se creó el ticket de soporte.
        /// </summary>
        public DateTime FechaCreacion { get; set; }
    }
}
