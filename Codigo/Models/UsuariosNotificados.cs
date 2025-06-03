using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    /// <summary>
    /// Representa la relación entre un usuario y una notificación enviada dentro del sistema.
    /// </summary>
    public class UsuariosNotificados
    {
        /// <summary>
        /// Identificador único del registro de notificación del usuario.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador del usuario que recibe la notificación.
        /// </summary>
        public int UsuarioId { get; set; }

        /// <summary>
        /// Identificador de la notificación enviada al usuario.
        /// </summary>
        public int NotificacionId { get; set; }

        /// <summary>
        /// Indica si el usuario ha leído la notificación.
        /// </summary>
        public bool Leido { get; set; }

        /// <summary>
        /// Fecha y hora en que el usuario leyó la notificación (si aplica).
        /// </summary>
        public DateTime? FechaLeido { get; set; }
    }
}
