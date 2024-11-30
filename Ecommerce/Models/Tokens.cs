using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class Tokens
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuarios Usuario { get; set; } 
        public string TokenValue { get; set; }
        public DateTime Expira { get; set; }
    }
}
