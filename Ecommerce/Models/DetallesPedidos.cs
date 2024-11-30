using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class DetallesPedidos
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public Pedidos Pedido { get; set; }

        public int ProductoId { get; set; }
        public Productos Producto { get; set; }

        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
    }
}
