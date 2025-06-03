using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    /// <summary>
    /// Modelo que representa el estado y la ubicación de un envío en un momento específico.
    /// </summary>
    public class TrackingEnvio
    {
        /// <summary>
        /// Identificador único del seguimiento de envío.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador del envío asociado.
        /// </summary>
        public int EnvioId { get; set; }

        /// <summary>
        /// Estado actual del envío (por ejemplo: "En tránsito", "Entregado").
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// Ubicación del paquete al momento del registro.
        /// </summary>
        public string Ubicacion { get; set; }

        /// <summary>
        /// Fecha y hora del estado registrado.
        /// </summary>
        public DateTime Fecha { get; set; }
    }
}
