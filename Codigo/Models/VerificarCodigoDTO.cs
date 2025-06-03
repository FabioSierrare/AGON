using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Models
{
    /// <summary>
    /// DTO utilizado para verificar un código de recuperación de contraseña.
    /// </summary>
    public class VerificarCodigoDTO
    {
        /// <summary>
        /// Correo electrónico del usuario al que se envió el código.
        /// </summary>
        public string Correo { get; set; }

        /// <summary>
        /// Código de verificación recibido por el usuario.
        /// </summary>
        public string Codigo { get; set; }
    }
}