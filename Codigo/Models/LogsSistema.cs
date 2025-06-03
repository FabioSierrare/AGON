using System;
using E_Commerce.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace E_Commerce.Models
{
    /// <summary>
    /// Representa un registro de log del sistema, utilizado para seguimiento y depuración.
    /// </summary>
    public class LogsSistema
    {
        /// <summary>
        /// Identificador único del log.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nivel de severidad del log (por ejemplo: Info, Warning, Error).
        /// </summary>
        public string Nivel { get; set; }

        /// <summary>
        /// Mensaje descriptivo del evento registrado.
        /// </summary>
        public string Mensaje { get; set; }

        /// <summary>
        /// Fecha y hora en la que se registró el log.
        /// </summary>
        public DateTime FechaLog { get; set; }
    }
}
