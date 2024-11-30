using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class LogsSistema
    {
        public int Id { get; set; }
        public string Nivel { get; set; } 
        public string Mensaje { get; set; }
        public DateTime FechaLog { get; set; }
    }
}
