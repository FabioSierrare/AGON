using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class Pedidos
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public Usuarios Cliente { get; set; }
        public string Estado { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaPedido { get; set; }

        public ICollection<DetallesPedidos> Detalles { get; set; }
    }
}
