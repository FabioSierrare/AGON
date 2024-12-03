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
        public int UsuarioId { get; set; }  // Esta es la clave foránea
        public Usuarios Usuario { get; set; }  // Relación de navegación
        public string Accion { get; set; }
        public DateTime FechaAccion { get; set; }
    }
}
