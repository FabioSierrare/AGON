using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using E_Commerce.Repositories.Interfaces;

namespace E_Commerce.Models
{
    public class Pagos
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public decimal Monto { get; set; }
        public string? MetodoPago { get; set; }
        public string? CodigoTransaccion { get; set; }
        public string? ReferenciaPago { get; set; }
        public string? Factura { get; set; }
        public string EstadoTransaccion { get; set; }
        public DateTime? FechaFinalizacionPago { get; set; }
    }
}
