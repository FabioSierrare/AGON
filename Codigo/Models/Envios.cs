using E_Commerce.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace E_Commerce.Models
{
    public class Envios
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        [JsonIgnore]
        public Pedidos Pedido { get; set; } // Relación con Pedidos
        public string Empresa { get; set; }
        public string NumeroGuia { get; set; }
        public string EstadoEnvio { get; set; }
        public DateTime FechaEnvio { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string Ubicacion { get; set; }
    }
}
