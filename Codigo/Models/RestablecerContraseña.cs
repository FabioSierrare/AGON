namespace E_Commerce.Models
{
    /// <summary>
    /// Modelo que representa la información necesaria para restablecer una contraseña.
    /// </summary>
    public class RestablecerContraseña
    {
        /// <summary>
        /// Código enviado al correo electrónico del usuario para verificar su identidad.
        /// </summary>
        public string Codigo { get; set; }

        /// <summary>
        /// Nueva contraseña que el usuario desea establecer.
        /// </summary>
        public string NuevaContraseña { get; set; }

        /// <summary>
        /// Confirmación de la nueva contraseña para asegurar coincidencia.
        /// </summary>
        public string ConfirmarContraseña { get; set; }
    }
}

