using System;
using System.Text.Json.Serialization;
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
        public string Estado { get; set; }
        public decimal Total { get; set; }
        public DateTime FechaPedido { get; set; }
        public int ProductoId { get; set; }
        public int VendedorId { get; set; }
        public int Cantidad { get; set; }
        public string MetodoPago { get; set; }
        public decimal PrecioUnitario { get; set; }
        [JsonIgnore]
        public Usuarios? Cliente { get; set; } // Relación con Usuarios
        [JsonIgnore]
        public Envios? Envio { get; set; }
    }
}
