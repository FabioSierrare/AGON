using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class Descuentos
    {
        /// <summary>
        /// Identificador único del descuento.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Tipo de descuento (porcentaje, valor fijo, etc.).
        /// </summary>
        public string Tipo { get; set; }

        /// <summary>
        /// Nombre descriptivo del descuento.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Código del cupón de descuento que puede usar el cliente.
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Valor del descuento aplicado.
        /// </summary>
        public decimal Descuento { get; set; }

        /// <summary>
        /// Fecha de inicio de validez del descuento.
        /// </summary>
        public DateTime FechaInicio { get; set; }

        /// <summary>
        /// Fecha de fin de validez del descuento.
        /// </summary>
        public DateTime FechaFin { get; set; }

        /// <summary>
        /// Identificador del vendedor que creó el descuento.
        /// </summary>
        public int VendedorId { get; set; }
    }
}
