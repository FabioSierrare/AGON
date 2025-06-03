using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using E_Commerce.Repositories.Interfaces;

namespace E_Commerce.Models
{
    /// <summary>
    /// Representa la información de un pago realizado por un pedido.
    /// </summary>
    public class Pagos
    {
        /// <summary>
        /// Identificador único del pago.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador del pedido asociado al pago.
        /// </summary>
        public int PedidoId { get; set; }

        /// <summary>
        /// Monto total pagado.
        /// </summary>
        public decimal Monto { get; set; }

        /// <summary>
        /// Método de pago utilizado (ej. tarjeta, efectivo, etc.).
        /// </summary>
        public string? MetodoPago { get; set; }

        /// <summary>
        /// Código de transacción proporcionado por el proveedor de pagos.
        /// </summary>
        public string? CodigoTransaccion { get; set; }

        /// <summary>
        /// Referencia de pago única asociada al proceso de transacción.
        /// </summary>
        public string? ReferenciaPago { get; set; }

        /// <summary>
        /// Información de la factura asociada al pago.
        /// </summary>
        public string? Factura { get; set; }

        /// <summary>
        /// Estado actual de la transacción (ej. Completado, Fallido).
        /// </summary>
        public string EstadoTransaccion { get; set; }

        /// <summary>
        /// Fecha y hora en que se finalizó el pago.
        /// </summary>
        public DateTime? FechaFinalizacionPago { get; set; }
    }
}

