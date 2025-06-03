using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    /// <summary>
    /// Representa el detalle de un pedido, incluyendo producto, cantidad y precio unitario.
    /// </summary>
    public class DetallesPedidos
    {
        /// <summary>
        /// Identificador único del detalle del pedido.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador del pedido al que pertenece este detalle.
        /// </summary>
        public int PedidoId { get; set; }

        /// <summary>
        /// Identificador del producto incluido en el pedido.
        /// </summary>
        public int ProductoId { get; set; }

        /// <summary>
        /// Cantidad del producto solicitado en este detalle del pedido.
        /// </summary>
        public int Cantidad { get; set; }

        /// <summary>
        /// Precio unitario del producto al momento del pedido.
        /// </summary>
        public decimal PrecioUnitario { get; set; }
    }
}
