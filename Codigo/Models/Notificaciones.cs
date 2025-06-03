using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace E_Commerce.Models
{
    /// <summary>
    /// Representa una notificación enviada al usuario, incluyendo título, mensaje y fecha de envío.
    /// </summary>
    public class Notificaciones
    {
        /// <summary>
        /// Identificador único de la notificación.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Título breve de la notificación.
        /// </summary>
        public string Titulo { get; set; }

        /// <summary>
        /// Contenido o cuerpo principal de la notificación.
        /// </summary>
        public string Mensaje { get; set; }

        /// <summary>
        /// Fecha y hora en la que se envió la notificación.
        /// </summary>
        public DateTime FechaEnvio { get; set; }
    }
}