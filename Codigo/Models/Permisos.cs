using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    /// <summary>
    /// Representa un permiso dentro del sistema, utilizado para definir acciones que pueden ser realizadas por los usuarios.
    /// </summary>
    public class Permisos
    {
        /// <summary>
        /// Identificador único del permiso.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre descriptivo del permiso (ej. "EditarProductos", "VerVentas").
        /// </summary>
        public string Nombre { get; set; }
    }
}
