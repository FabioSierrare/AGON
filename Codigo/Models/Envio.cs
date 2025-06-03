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
    /// Representa los detalles del envío de un pedido.
    /// </summary>
    public class Envio
    {
        /// <summary>
        /// Identificador del pedido asociado al envío.
        /// </summary>
        public int ID_Pedido { get; set; }

        /// <summary>
        /// Nombre del cliente que recibe el pedido.
        /// </summary>
        public string Cliente { get; set; }

        /// <summary>
        /// Nombre de la empresa de transporte encargada del envío.
        /// </summary>
        public string Empresa_Transporte { get; set; }

        /// <summary>
        /// Código de seguimiento del envío.
        /// </summary>
        public string Tracking { get; set; }

        /// <summary>
        /// Estado actual del envío.
        /// </summary>
        public string EstadoEnvio { get; set; }

        /// <summary>
        /// Fecha en la que se realizó el envío.
        /// </summary>
        public DateTime? FechaEnvio { get; set; }

        /// <summary>
        /// Fecha estimada o real de entrega del pedido.
        /// </summary>
        public DateTime? FechaEntrega { get; set; }
    }
}