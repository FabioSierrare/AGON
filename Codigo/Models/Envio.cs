using E_Commerce.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;


namespace E_Commerce.Models
{
    public class Envio
    {
        public int ID_Pedido { get; set; }
        public string Cliente { get; set; }
        public string Empresa_Transporte { get; set; }
        public string Tracking { get; set; }
        public string EstadoEnvio { get; set; }
        public DateTime? FechaEnvio { get; set; }
        public DateTime? FechaEntrega { get; set; }
    }
}
