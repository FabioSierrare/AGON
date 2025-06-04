using E_Commerce.Context;
using E_Commerce.Models;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Repositories
{
    /// <summary>
    /// Repositorio que gestiona las operaciones CRUD para la entidad EmpresasEnvio.
    /// </summary>
    public class EmpresasEnvioRepository : IEmpresasEnvio
    {
        /// <summary>
        /// Contexto de base de datos de E-Commerce inyectado.
        /// </summary>
        public readonly E_commerceContext context;

        /// <summary>
        /// Constructor que recibe el contexto de base de datos.
        /// </summary>
        /// <param name="context">Instancia de E_commerceContext</param>
        public EmpresasEnvioRepository(E_commerceContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Obtiene todas las empresas de envío registradas.
        /// </summary>
        /// <returns>Lista de objetos EmpresasEnvio</returns>
        public async Task<List<EmpresasEnvio>> GetEmpresasEnvios()
        {
            var data = await context.EmpresasEnvios.ToListAsync();
            return data;
        }

        /// <summary>
        /// Inserta una nueva empresa de envío en la base de datos.
        /// </summary>
        /// <param name="empresasEnvio">Objeto EmpresasEnvio a insertar</param>
        /// <returns>True si se guarda correctamente</returns>
        public async Task<bool> PostEmpresasEnvios(EmpresasEnvio empresasEnvio)
        {
            await context.EmpresasEnvios.AddAsync(empresasEnvio);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Actualiza la información de una empresa de envío existente.
        /// </summary>
        /// <param name="empresasEnvio">Objeto EmpresasEnvio con los datos actualizados</param>
        /// <returns>True si la operación fue exitosa</returns>
        public async Task<bool> PutEmpresasEnvios(EmpresasEnvio empresasEnvio)
        {
            context.EmpresasEnvios.Update(empresasEnvio);
            await context.SaveAsync();
            return true;
        }

        /// <summary>
        /// Elimina una empresa de envío por su ID.
        /// </summary>
        /// <param name="id">ID de la empresa de envío a eliminar</param>
        /// <returns>True si se eliminó correctamente, False si no se encontró</returns>
        public async Task<bool> DeleteEmpresasEnvios(int id)
        {
            var empresasEnvios = await context.EmpresasEnvios.FindAsync(id);
            if (empresasEnvios == null) return false;

            context.EmpresasEnvios.Remove(empresasEnvios);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
