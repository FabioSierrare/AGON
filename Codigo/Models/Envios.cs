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
    /// Representa la información detallada de un envío.
    /// </summary>
    public class Envios
    {
        /// <summary>
        /// Identificador único del envío.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador del pedido asociado a este envío.
        /// </summary>
        public int PedidoId { get; set; }

        /// <summary>
        /// Representación del pedido relacionado. Solo se usa internamente por Entity Framework.
        /// </summary>
        [JsonIgnore]
        public Pedidos? Pedido { get; set; }

        /// <summary>
        /// Nombre de la empresa de transporte utilizada.
        /// </summary>
        public string Empresa { get; set; }

        /// <summary>
        /// Número de guía o código de rastreo del envío.
        /// </summary>
        public string NumeroGuia { get; set; }

        /// <summary>
        /// Estado actual del envío.
        /// </summary>
        public string EstadoEnvio { get; set; }

        /// <summary>
        /// Fecha en la que se realizó el envío.
        /// </summary>
        public DateTime FechaEnvio { get; set; }

        /// <summary>
        /// Fecha en la que se entregó el pedido.
        /// </summary>
        public DateTime FechaEntrega { get; set; }

        /// <summary>
        /// Última ubicación registrada del paquete en tránsito.
        /// </summary>
        public string Ubicacion { get; set; }
    }
}
