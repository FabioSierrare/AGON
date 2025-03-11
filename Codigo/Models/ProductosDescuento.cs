using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class ProductosDescuento
    {
        public int Id { get; set; }
        public int ProductoId { get; set; }
        public int DescuentoId { get; set; }
    }
}
