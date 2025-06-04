using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    /// <summary>
    /// Define las operaciones para gestionar las respuestas a preguntas frecuentes (FAQ) en el sistema.
    /// </summary>
    public interface IRespuestasFAQ
    {
        /// <summary>
        /// Obtiene una lista de todas las respuestas FAQ almacenadas en el sistema.
        /// </summary>
        /// <returns>
        /// Una lista de objetos <see cref="RespuestasFAQ"/>.
        /// </returns>
        Task<List<RespuestasFAQ>> GetRespuestasFAQ();

        /// <summary>
        /// Registra una nueva respuesta FAQ en la base de datos.
        /// </summary>
        /// <param name="respuestasFAQ">El objeto <see cref="RespuestasFAQ"/> que se desea agregar.</param>
        /// <returns>
        /// Verdadero si el registro fue exitoso, falso en caso contrario.
        /// </returns>
        Task<bool> PostRespuestaFAQ(RespuestasFAQ respuestasFAQ);

        /// <summary>
        /// Actualiza una respuesta FAQ existente.
        /// </summary>
        /// <param name="respuestasFAQ">El objeto <see cref="RespuestasFAQ"/> con la información actualizada.</param>
        /// <returns>
        /// Verdadero si la actualización fue exitosa, falso en caso contrario.
        /// </returns>
        Task<bool> PutRespuestasFAQ(RespuestasFAQ respuestasFAQ);

        /// <summary>
        /// Elimina una respuesta FAQ según su identificador.
        /// </summary>
        /// <param name="id">El ID de la respuesta FAQ que se desea eliminar.</param>
        /// <returns>
        /// Verdadero si la eliminación fue exitosa, falso si no se encontró el registro.</returns>
        Task<bool> DeleteRespuestasFAQ(int id);
    }
}
