using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    public class RolesPermisos
    {
        /// <summary>
        /// Identificador único de la relación Rol-Permiso.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador del rol asociado.
        /// </summary>
        public int RolId { get; set; }

        /// <summary>
        /// Identificador del permiso asociado.
        /// </summary>
        public int PermisoId { get; set; }
    }
}
