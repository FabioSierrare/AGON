using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class RespuestasFAQ
    {
        /// <summary>
        /// Identificador único de la respuesta FAQ.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Pregunta formulada por el usuario o cliente.
        /// </summary>
        public string Pregunta { get; set; }

        /// <summary>
        /// Respuesta proporcionada para la pregunta.
        /// </summary>
        public string Respuesta { get; set; }
    }
}
