using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace E_Commerce.Models
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string TipoUsuario { get; set; } 
        public DateTime FechaCreacion { get; set; }

        public ICollection<Pedidos> Pedidos { get; set; } 
        public ICollection<Productos> Productos { get; set; }
    }
}
