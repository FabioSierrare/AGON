namespace E_Commerce.Models
{
    /// <summary>
    /// Representa la respuesta estándar para las operaciones del sistema.
    /// </summary>
    public class RespuestaDTO
    {
        /// <summary>
        /// Indica si la operación fue exitosa o no.
        /// </summary>
        public bool Exito { get; set; }

        /// <summary>
        /// Mensaje descriptivo del resultado de la operación.
        /// </summary>
        public string Mensaje { get; set; }
    }
}
