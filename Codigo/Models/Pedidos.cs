using System;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    /// <summary>
    /// Representa un pedido realizado por un cliente.
    /// </summary>
    public class Pedidos
    {
        /// <summary>
        /// Identificador único del pedido.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador del cliente que realizó el pedido.
        /// </summary>
        public int ClienteId { get; set; }

        /// <summary>
        /// Estado actual del pedido (ej. Pendiente, Enviado, Entregado).
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// Total monetario del pedido.
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// Fecha en que se realizó el pedido.
        /// </summary>
        public DateTime FechaPedido { get; set; }

        /// <summary>
        /// Identificador del producto incluido en el pedido.
        /// </summary>
        public int ProductoId { get; set; }

        /// <summary>
        /// Identificador del vendedor que ofrece el producto.
        /// </summary>
        public int VendedorId { get; set; }

        /// <summary>
        /// Cantidad del producto solicitado.
        /// </summary>
        public int Cantidad { get; set; }

        /// <summary>
        /// Método de pago seleccionado por el cliente.
        /// </summary>
        public string MetodoPago { get; set; }

        /// <summary>
        /// Precio por unidad del producto en el momento del pedido.
        /// </summary>
        public decimal PrecioUnitario { get; set; }

        /// <summary>
        /// Información del cliente asociada al pedido (no se serializa en JSON).
        /// </summary>
        [JsonIgnore]
        public Usuarios? Cliente { get; set; }

        /// <summary>
        /// Información del envío asociado al pedido (no se serializa en JSON).
        /// </summary>
        [JsonIgnore]
        public Envios? Envio { get; set; }
    }
}
