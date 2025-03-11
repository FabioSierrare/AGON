using E_Commerce.Repositories.Interfaces;
using E_Commerce.Repositories;
using E_Commerce.Repositories;
using E_Commerce.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using MicroServiceCRUD.Repositories;

namespace MicroServiceCRUD
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddExternal(this IServiceCollection services, IConfiguration _configuration)
        {
            // Obtener la cadena de conexión desde la configuración
            string connectionString = _configuration["ConnectionStrings:SQLConnectionStrings"];

            // Registrar el DbContext para la base de datos
            services.AddDbContext<DatabaseService>(options => options.UseSqlServer(connectionString));

            // Registrar interfaces sin el sufijo Repository
            services.AddScoped<IEstadisticas, EstadisticasRepository>();
            services.AddScoped<IComentarios, ComentariosRepository>();
            services.AddScoped<ICupones, CuponesRepository>();
            services.AddScoped<IDetallesPedidos, DetallesPedidosRepository>();
            services.AddScoped<IEmpresasEnvio, EmpresasEnvioRepository>();
            services.AddScoped<IEnvios, EnviosRepository>();
            services.AddScoped<IInventarios, InventariosRepository>();
            services.AddScoped<ILogsSistema, LogsSistemaRepository>();
            services.AddScoped<INotificaciones, NotificacionesRepository>();
            services.AddScoped<IPedidos, PedidosRepository>();
            services.AddScoped<IPermiso, PermisoRepository>();
            services.AddScoped<IProductos, ProductosRepository>();
            services.AddScoped<IProductosDescuento, ProductosDescuentoRepository>();
            services.AddScoped<IDescuentos, DescuentosRepository>();
            services.AddScoped<IReporteAcciones, ReporteAccionesRepository>();
            services.AddScoped<IRespuestasFAQ, RespuestasFAQRepository>();
            services.AddScoped<IRolesPermisos, RolesPermisosRepository>();
            services.AddScoped<ITicketsSoporte, TicketsSoporteRepository>();
            services.AddScoped<ITrackingEnvio, TrackingEnvioRepository>();
            services.AddScoped<IUsuarios, UsuariosRepository>();
            services.AddScoped<IValoraciones, ValoracionesRepository>();

            return services;
        }
    }
}