using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class Cupones
    {
        /// <summary>
        /// Identificador único del cupón.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador del producto asociado al cupón.
        /// </summary>
        public int ProductoId { get; set; }

        /// <summary>
        /// Identificador de la promoción a la que pertenece el cupón.
        /// </summary>
        public int PromocionId { get; set; }
    }
}