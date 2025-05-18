using System;
using System.Text.Json.Serialization;

namespace E_Commerce.Models
{
    public class Envios
    {
        public int Id { get; set; }

        // Clave foránea para el pedido (esto es lo único que necesitas enviar)
        public int PedidoId { get; set; }

        // Solo se usa internamente por Entity Framework, no se envía por JSON
        [JsonIgnore]
        public Pedidos? Pedido { get; set; }

        public string Empresa { get; set; }
        public string NumeroGuia { get; set; }
        public string EstadoEnvio { get; set; }

        public DateTime FechaEnvio { get; set; }
        public DateTime FechaEntrega { get; set; }

        public string Ubicacion { get; set; }
    }
}
