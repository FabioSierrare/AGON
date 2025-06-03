using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    /// <summary>
    /// Representa una empresa encargada del envío de productos.
    /// </summary>
    public class EmpresasEnvio
    {
        /// <summary>
        /// Identificador único de la empresa de envío.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nombre de la empresa de envío.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Información de contacto de la empresa de envío.
        /// </summary>
        public string Contacto { get; set; }
    }
}
