using E_Commerce.Models;

namespace E_Commerce.Repositories.Interfaces
{
    /// <summary>
    /// Define un contrato para las operaciones CRUD sobre las empresas de envío.
    /// </summary>
    public interface IEmpresasEnvio
    {
        /// <summary>
        /// Obtiene la lista de todas las empresas de envío registradas.
        /// </summary>
        /// <returns>Una lista de objetos <see cref="EmpresasEnvio"/>.</returns>
        Task<List<EmpresasEnvio>> GetEmpresasEnvios();

        /// <summary>
        /// Agrega una nueva empresa de envío a la base de datos.
        /// </summary>
        /// <param name="empresasEnvio">La entidad <see cref="EmpresasEnvio"/> a agregar.</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa.</returns>
        Task<bool> PostEmpresasEnvios(EmpresasEnvio empresasEnvio);

        /// <summary>
        /// Actualiza una empresa de envío existente.
        /// </summary>
        /// <param name="empresasEnvio">La entidad <see cref="EmpresasEnvio"/> con los datos actualizados.</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa.</returns>
        Task<bool> PutEmpresasEnvios(EmpresasEnvio empresasEnvio);

        /// <summary>
        /// Elimina una empresa de envío de la base de datos.
        /// </summary>
        /// <param name="id">El identificador único de la empresa de envío a eliminar.</param>
        /// <returns>Un valor booleano que indica si la operación fue exitosa.</returns>
        Task<bool> DeleteEmpresasEnvios(int id);
    }
}
