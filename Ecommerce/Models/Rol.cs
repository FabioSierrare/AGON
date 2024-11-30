using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class Rol
    {
        public int Id { get; set; } 
        public string Nombre { get; set; }

        public ICollection<Usuarios> Usuarios { get; set; }
    }
}
