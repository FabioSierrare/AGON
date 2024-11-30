using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models 
{ 
    public class Auditorias
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuarios Usuario { get; set; } 
        public string Accion { get; set; } 
        public DateTime FechaAccion { get; set; }
    }
}
