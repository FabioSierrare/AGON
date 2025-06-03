using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    /// <summary>
    /// Representa la imagen de perfil de un usuario.
    /// </summary>
    public class ImgPerfil
    {
        /// <summary>
        /// Identificador único de la imagen de perfil.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identificador del usuario al que pertenece la imagen de perfil.
        /// </summary>
        public int IdUsuario { get; set; }

        /// <summary>
        /// URL de la imagen de perfil.
        /// </summary>
        public string? URLImg { get; set; }
    }
}
