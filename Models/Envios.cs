using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class Envios
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public Pedidos Pedido { get; set; } 
        public string EmpresaEnvio { get; set; }
        public string NumeroGuia { get; set; }
        public string EstadoEnvio { get; set; }
        public DateTime FechaEnvio { get; set; }
        public DateTime? FechaEntrega { get; set; }
    }
}
