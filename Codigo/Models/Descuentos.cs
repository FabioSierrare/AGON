using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using E_Commerce.Repositories.Interfaces;

namespace E_Commerce.Models
{
    public class Descuentos
    {
        public int Id { get; set; }
        public string Tipo { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public decimal Descuento { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int VendedorId { get; set; }
        [JsonIgnore]
        public ICollection<ProductosDescuento> ProductosDescuento { get; set; }


    }
}
