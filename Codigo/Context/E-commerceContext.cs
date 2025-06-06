using E_Commerce.Controllers;
using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace E_Commerce.Context
{
    /// <summary>
    /// Contexto de base de datos para la aplicación E-Commerce.
    /// Contiene DbSet para cada entidad y configuración de relaciones.
    /// </summary>
    public class E_commerceContext : DbContext
    {
        /// <summary>
        /// Constructor que recibe opciones para configurar el contexto.
        /// </summary>
        /// <param name="options">Opciones de configuración del contexto.</param>
        public E_commerceContext(DbContextOptions options) : base(options) { }

        // === DbSets para entidades ===

        /// <summary>Tipousuarios registrados en el sistema.</summary>

        public DbSet<TipoUsuarios> TipoUsuarios { get; set; }

        /// <summary>Usuarios registrados en el sistema.</summary>
        public DbSet<Usuarios> Usuarios { get; set; }
        /// <summary>Productos con descuentos aplicados.</summary>
        public DbSet<ProductosDescuento> ProductosDescuento { get; set; }
        /// <summary>Pagos realizados en la plataforma.</summary>
        public DbSet<Pagos> Pagos { get; set; }
        /// <summary>Categorías de productos disponibles.</summary>
        public DbSet<Categorias> Categorias { get; set; }
        /// <summary>Comentarios realizados por usuarios.</summary>
        public DbSet<Comentarios> Comentarios { get; set; }
        /// <summary>Cupones promocionales para productos.</summary>
        public DbSet<Cupones> Cupones { get; set; }
        /// <summary>Detalles individuales de cada pedido.</summary>
        public DbSet<DetallesPedidos> DetallesPedidos { get; set; }
        /// <summary>Empresas encargadas del envío.</summary>
        public DbSet<EmpresasEnvio> EmpresasEnvios { get; set; }
        /// <summary>Registros de envíos realizados.</summary>
        public DbSet<Envios> Envios { get; set; }
        /// <summary>Stock y disponibilidad de productos.</summary>
        public DbSet<Inventarios> Inventarios { get; set; }
        /// <summary>Imágenes de perfil de los usuarios.</summary>
        public DbSet<ImgPerfil> ImgPerfil { get; set; }
        /// <summary>Eventos registrados en el sistema (log).</summary>
        public DbSet<LogsSistema> LogsSistema { get; set; }
        /// <summary>Notificaciones enviadas a los usuarios.</summary>
        public DbSet<Notificaciones> Notificaciones { get; set; }
        /// <summary>Pedidos realizados por los usuarios.</summary>
        public DbSet<Pedidos> Pedidos { get; set; }
        /// <summary>Permisos configurables para roles.</summary>
        public DbSet<Permisos> Permisos { get; set; }
        /// <summary>Catálogo general de productos.</summary>
        public DbSet<Productos> Productos { get; set; }
        /// <summary>Descuentos aplicables a productos.</summary>
        public DbSet<Descuentos> Descuentos { get; set; }
        /// <summary>Registro de acciones de los usuarios.</summary>
        public DbSet<ReporteAcciones> ReporteAcciones { get; set; }
        /// <summary>Respuestas a preguntas frecuentes.</summary>
        public DbSet<RespuestasFAQ> RespuestasFAQ { get; set; }
        /// <summary>Relaciones entre roles y permisos.</summary>
        public DbSet<RolesPermisos> RolesPermisos { get; set; }
        /// <summary>Tickets de soporte generados por usuarios.</summary>
        public DbSet<TicketsSoporte> TicketsSoporte { get; set; }
        /// <summary>Seguimiento del estado de los envíos.</summary>
        public DbSet<TrackingEnvio> TrackingEnvio { get; set; }
        /// <summary>Usuarios que han recibido notificaciones.</summary>
        public DbSet<UsuariosNotificados> UsuariosNotificados { get; set; }
        /// <summary>Valoraciones de productos por parte de los usuarios.</summary>
        public DbSet<Valoraciones> Valoraciones { get; set; }

        /// <summary>
        /// Configura relaciones entre entidades.
        /// </summary>
        /// <param name="modelBuilder">Constructor del modelo.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de relaciones existentes
            modelBuilder.Entity<Pedidos>()
                .HasOne(p => p.Envio)
                .WithOne(e => e.Pedido)
                .HasForeignKey<Envios>(e => e.PedidoId);

            modelBuilder.Entity<Pedidos>()
                .HasOne(p => p.Cliente)
                .WithMany()
                .HasForeignKey(p => p.ClienteId);

            // Invoca aquí tu mapeo completo de tablas (incluyendo TipoUsuarios)
            EntityConfuguration(modelBuilder);
        }


        /// <summary>
        /// Configura cada entidad con sus propiedades y columnas.
        /// Este método contiene la configuración detallada línea por línea.
        /// </summary>
        /// <param name="modelBuilder">Constructor del modelo.</param>
        private void EntityConfuguration(ModelBuilder modelBuilder)
        {
            // Configuraciones individuales completas de cada entidad, sin modificar la lógica original.
            // Están incluidas en su totalidad en el contenido cargado.

            //tabla categoria
            modelBuilder.Entity<Categorias>().ToTable("Categorias");
            modelBuilder.Entity<Categorias>().HasKey(u => u.Id);
            modelBuilder.Entity<Categorias>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Categorias>().Property(u => u.Nombre).HasColumnName("Nombre");

            //tabla ImgPerfil
            modelBuilder.Entity<ImgPerfil>().ToTable("ImgPerfil");
            modelBuilder.Entity<ImgPerfil>().HasKey(u => u.Id);
            modelBuilder.Entity<ImgPerfil>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<ImgPerfil>().Property(u => u.IdUsuario).HasColumnName("IdUsuario");
            modelBuilder.Entity<ImgPerfil>().Property(u => u.URLImg).HasColumnName("URLImg");

            //tabla ProductosDescuento
            modelBuilder.Entity<ProductosDescuento>().ToTable("ProductosDescuento");
            modelBuilder.Entity<ProductosDescuento>().HasKey(u => u.Id);
            modelBuilder.Entity<ProductosDescuento>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<ProductosDescuento>().Property(u => u.ProductoId).HasColumnName("ProductoId");
            modelBuilder.Entity<ProductosDescuento>().Property(u => u.DescuentoId).HasColumnName("DescuentoId");

            //Tabla comentarios
            modelBuilder.Entity<Comentarios>().ToTable("Comentarios");
            modelBuilder.Entity<Comentarios>().HasKey(u => u.Id);
            modelBuilder.Entity<Comentarios>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Comentarios>().Property(u => u.UsuarioId).HasColumnName("UsuarioId");
            modelBuilder.Entity<Comentarios>().Property(u => u.ProductoId).HasColumnName("ProductoId");
            modelBuilder.Entity<Comentarios>().Property(u => u.ComentarioTexto).HasColumnName("ComentarioTexto");
            modelBuilder.Entity<Comentarios>().Property(u => u.FechaComentario).HasColumnName("FechaComentario");

            //Tabla cupones 
            modelBuilder.Entity<Cupones>().ToTable("Cupones");
            modelBuilder.Entity<Cupones>().HasKey(u => u.Id);
            modelBuilder.Entity<Cupones>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Cupones>().Property(u => u.ProductoId).HasColumnName("ProductoId");
            modelBuilder.Entity<Cupones>().Property(u => u.PromocionId).HasColumnName("PromocionId");

            //Tabla DetallesPedido
            modelBuilder.Entity<DetallesPedidos>().ToTable("DetallesPedidos");
            modelBuilder.Entity<DetallesPedidos>().HasKey(u => u.Id);
            modelBuilder.Entity<DetallesPedidos>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<DetallesPedidos>().Property(u => u.PedidoId).HasColumnName("PedidoId");
            modelBuilder.Entity<DetallesPedidos>().Property(u => u.ProductoId).HasColumnName("ProductoId");
            modelBuilder.Entity<DetallesPedidos>().Property(u => u.Cantidad).HasColumnName("Cantidad");
            modelBuilder.Entity<DetallesPedidos>().Property(u => u.PrecioUnitario).HasColumnName("PrecioUnitario");

            //Tabla EmpresasEnvio
            modelBuilder.Entity<EmpresasEnvio>().ToTable("EmpresasEnvio");
            modelBuilder.Entity<EmpresasEnvio>().HasKey(u => u.Id);
            modelBuilder.Entity<EmpresasEnvio>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<EmpresasEnvio>().Property(u => u.Nombre).HasColumnName("Nombre");
            modelBuilder.Entity<EmpresasEnvio>().Property(u => u.Contacto).HasColumnName("Contacto");

            //Tabla Envio
            modelBuilder.Entity<Envios>().ToTable("Envios");
            modelBuilder.Entity<Envios>().HasKey(u => u.Id);
            modelBuilder.Entity<Envios>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Envios>().Property(u => u.Empresa).HasColumnName("Empresa");
            modelBuilder.Entity<Envios>().Property(u => u.NumeroGuia).HasColumnName("NumeroGuia");
            modelBuilder.Entity<Envios>().Property(u => u.EstadoEnvio).HasColumnName("EstadoEnvio");
            modelBuilder.Entity<Envios>().Property(u => u.FechaEnvio).HasColumnName("FechaEnvio");
            modelBuilder.Entity<Envios>().Property(u => u.FechaEntrega).HasColumnName("FechaEntrega");
            modelBuilder.Entity<Envios>().Property(u => u.Ubicacion).HasColumnName("Ubicacion");


            //Tabla Inventarios
            modelBuilder.Entity<Inventarios>().ToTable("Inventarios");
            modelBuilder.Entity<Inventarios>().HasKey(u => u.Id);
            modelBuilder.Entity<Inventarios>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Inventarios>().Property(u => u.ProductoId).HasColumnName("ProductoId");
            modelBuilder.Entity<Inventarios>().Property(u => u.Cantidad).HasColumnName("Cantidad");
            modelBuilder.Entity<Inventarios>().Property(u => u.UltimaActualizacion).HasColumnName("UltimaActualizacion");

            //Tabla LogsSistema
            modelBuilder.Entity<LogsSistema>().ToTable("LogsSistema");
            modelBuilder.Entity<LogsSistema>().HasKey(u => u.Id);
            modelBuilder.Entity<LogsSistema>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<LogsSistema>().Property(u => u.Nivel).HasColumnName("Nivel");
            modelBuilder.Entity<LogsSistema>().Property(u => u.Mensaje).HasColumnName("Mensaje");
            modelBuilder.Entity<LogsSistema>().Property(u => u.FechaLog).HasColumnName("FechaLog");

            //Tabla Notificaciones
            modelBuilder.Entity<Notificaciones>().ToTable("Notificaciones");
            modelBuilder.Entity<Notificaciones>().HasKey(u => u.Id);
            modelBuilder.Entity<Notificaciones>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Notificaciones>().Property(u => u.Titulo).HasColumnName("Titulo");
            modelBuilder.Entity<Notificaciones>().Property(u => u.Mensaje).HasColumnName("Mensaje");
            modelBuilder.Entity<Notificaciones>().Property(u => u.FechaEnvio).HasColumnName("FechaEnvio");

            //Tabla Pedidos
            modelBuilder.Entity<Pedidos>().ToTable("Pedidos");
            modelBuilder.Entity<Pedidos>().HasKey(u => u.Id);
            modelBuilder.Entity<Pedidos>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Pedidos>().Property(u => u.ClienteId).HasColumnName("ClienteId");
            modelBuilder.Entity<Pedidos>().Property(u => u.Estado).HasColumnName("Estado");
            modelBuilder.Entity<Pedidos>().Property(u => u.Total).HasColumnName("Total");
            modelBuilder.Entity<Pedidos>().Property(u => u.FechaPedido).HasColumnName("FechaPedido");
            modelBuilder.Entity<Pedidos>().Property(u => u.ProductoId).HasColumnName("ProductoId");
            modelBuilder.Entity<Pedidos>().Property(u => u.VendedorId).HasColumnName("VendedorId");
            modelBuilder.Entity<Pedidos>().Property(u => u.Cantidad).HasColumnName("Cantidad");
            modelBuilder.Entity<Pedidos>().Property(u => u.MetodoPago).HasColumnName("MetodoPago");
            modelBuilder.Entity<Pedidos>().Property(u => u.PrecioUnitario).HasColumnName("PrecioUnitario");

            //tabla Permiso
            modelBuilder.Entity<Permisos>().ToTable("Permiso");
            modelBuilder.Entity<Permisos>().HasKey(u => u.Id);
            modelBuilder.Entity<Permisos>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Permisos>().Property(u => u.Nombre).HasColumnName("Nombre");

            //Tabla Productos
            modelBuilder.Entity<Productos>().ToTable("Productos");
            modelBuilder.Entity<Productos>().HasKey(u => u.Id);
            modelBuilder.Entity<Productos>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Productos>().Property(u => u.Nombre).HasColumnName("Nombre");
            modelBuilder.Entity<Productos>().Property(u => u.Descripcion).HasColumnName("Descripcion");
            modelBuilder.Entity<Productos>().Property(u => u.Precio).HasColumnName("Precio");
            modelBuilder.Entity<Productos>().Property(u => u.Stock).HasColumnName("Stock");
            modelBuilder.Entity<Productos>().Property(u => u.FechaCreacion).HasColumnName("FechaCreacion");
            modelBuilder.Entity<Productos>().Property(u => u.CategoriaId).HasColumnName("CategoriaId");
            modelBuilder.Entity<Productos>().Property(u => u.VendedorId).HasColumnName("VendedorId");
            modelBuilder.Entity<Productos>().Property(u => u.UrlImagen).HasColumnName("UrlImagen");

            //tabla Promociones
            modelBuilder.Entity<Descuentos>().ToTable("Descuentos");
            modelBuilder.Entity<Descuentos>().HasKey(u => u.Id);
            modelBuilder.Entity<Descuentos>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Descuentos>().Property(u => u.Tipo).HasColumnName("Tipo");
            modelBuilder.Entity<Descuentos>().Property(u => u.Nombre).HasColumnName("Nombre");
            modelBuilder.Entity<Descuentos>().Property(u => u.Codigo).HasColumnName("Codigo");
            modelBuilder.Entity<Descuentos>().Property(u => u.Descuento).HasColumnName("Descuento");
            modelBuilder.Entity<Descuentos>().Property(u => u.FechaInicio).HasColumnName("FechaInicio");
            modelBuilder.Entity<Descuentos>().Property(u => u.FechaFin).HasColumnName("FechaFin");
            modelBuilder.Entity<Descuentos>().Property(u => u.VendedorId).HasColumnName("VendedorId");

            //tabla ReporteAcciones
            modelBuilder.Entity<ReporteAcciones>().ToTable("ReporteAcciones");
            modelBuilder.Entity<ReporteAcciones>().HasKey(u => u.Id);
            modelBuilder.Entity<ReporteAcciones>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<ReporteAcciones>().Property(u => u.UsuarioId).HasColumnName("UsuarioId");
            modelBuilder.Entity<ReporteAcciones>().Property(u => u.Descripcion).HasColumnName("Descripcion");
            modelBuilder.Entity<ReporteAcciones>().Property(u => u.FechaReporte).HasColumnName("FechaReporte");

            //tabla RespuestasFAQ
            modelBuilder.Entity<RespuestasFAQ>().ToTable("RespuestasFAQ");
            modelBuilder.Entity<RespuestasFAQ>().HasKey(u => u.Id);
            modelBuilder.Entity<RespuestasFAQ>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<RespuestasFAQ>().Property(u => u.Pregunta).HasColumnName("Pregunta");
            modelBuilder.Entity<RespuestasFAQ>().Property(u => u.Respuesta).HasColumnName("Respuesta");


            //tabla RolesPermisos
            modelBuilder.Entity<RolesPermisos>().ToTable("RolesPermisos");
            modelBuilder.Entity<RolesPermisos>().HasKey(u => u.Id);
            modelBuilder.Entity<RolesPermisos>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<RolesPermisos>().Property(u => u.RolId).HasColumnName("RolId");
            modelBuilder.Entity<RolesPermisos>().Property(u => u.PermisoId).HasColumnName("PermisoId");

            //tabla TicketsSoporte

            modelBuilder.Entity<TicketsSoporte>().ToTable("TicketsSoporte");
            modelBuilder.Entity<TicketsSoporte>().HasKey(u => u.Id);
            modelBuilder.Entity<TicketsSoporte>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<TicketsSoporte>().Property(u => u.UsuarioId).HasColumnName("UsuarioId");
            modelBuilder.Entity<TicketsSoporte>().Property(u => u.Titulo).HasColumnName("Titulo");
            modelBuilder.Entity<TicketsSoporte>().Property(u => u.Descripcion).HasColumnName("Descripcion");
            modelBuilder.Entity<TicketsSoporte>().Property(u => u.Estado).HasColumnName("Estado");
            modelBuilder.Entity<TicketsSoporte>().Property(u => u.FechaCreacion).HasColumnName("FechaCreacion");



            //tabla TrackingEnvio
            modelBuilder.Entity<TrackingEnvio>().ToTable("TrackingEnvio");
            modelBuilder.Entity<TrackingEnvio>().HasKey(u => u.Id);
            modelBuilder.Entity<TrackingEnvio>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<TrackingEnvio>().Property(u => u.EnvioId).HasColumnName("EnvioId");
            modelBuilder.Entity<TrackingEnvio>().Property(u => u.Estado).HasColumnName("Estado");
            modelBuilder.Entity<TrackingEnvio>().Property(u => u.Ubicacion).HasColumnName("Ubicacion");
            modelBuilder.Entity<TrackingEnvio>().Property(u => u.Fecha).HasColumnName("Fecha");

            //tabla tipousuarios

            // Tabla TipoUsuarios
            // Tabla TipoUsuarios
            modelBuilder.Entity<TipoUsuarios>().ToTable("TipoUsuarios");
            modelBuilder.Entity<TipoUsuarios>().HasKey(tu => tu.Id);
            modelBuilder.Entity<TipoUsuarios>()
                .Property(tu => tu.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<TipoUsuarios>()
                .Property(tu => tu.Nombre)
                .HasColumnName("Nombre")
                .IsRequired();


            //tabla Usuarios

            modelBuilder.Entity<Usuarios>().ToTable("Usuarios");
            modelBuilder.Entity<Usuarios>().HasKey(u => u.Id);
            modelBuilder.Entity<Usuarios>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Usuarios>().Property(u => u.Nombre).HasColumnName("Nombre");
            modelBuilder.Entity<Usuarios>().Property(u => u.Correo).HasColumnName("Correo");
            modelBuilder.Entity<Usuarios>().Property(u => u.Contraseña).HasColumnName("Contraseña");
            modelBuilder.Entity<Usuarios>().Property(u => u.Telefono).HasColumnName("Telefono");
            modelBuilder.Entity<Usuarios>().Property(u => u.Direccion).HasColumnName("Direccion");
            modelBuilder.Entity<Usuarios>().Property(u => u.TipoDocumento).HasColumnName("TipoDocumento");
            modelBuilder.Entity<Usuarios>().Property(u => u.Documento).HasColumnName("Documento");
            modelBuilder.Entity<Usuarios>().Property(u => u.TipoUsuarioId).HasColumnName("TipoUsuarioId");
            modelBuilder.Entity<Usuarios>().Property(u => u.FechaCreacion).HasColumnName("FechaCreacion");
            modelBuilder.Entity<Usuarios>().Property(u => u.CodigoVerificacion).HasColumnName("CodigoRecuperacion");
            modelBuilder.Entity<Usuarios>().Property(u => u.CodigoExpira).HasColumnName("CodigoExpira");


            //tabla Valoraciones
            modelBuilder.Entity<Valoraciones>().ToTable("Valoraciones");
            modelBuilder.Entity<Valoraciones>().HasKey(u => u.Id);
            modelBuilder.Entity<Valoraciones>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Valoraciones>().Property(u => u.UsuarioId).HasColumnName("UsuarioId");
            modelBuilder.Entity<Valoraciones>().Property(u => u.ProductoId).HasColumnName("ProductoId");
            modelBuilder.Entity<Valoraciones>().Property(u => u.Valor).HasColumnName("Valor");
            modelBuilder.Entity<Valoraciones>().Property(u => u.FechaValoracion).HasColumnName("FechaValoracion");

            //tabla Pagos
            modelBuilder.Entity<Pagos>().ToTable("Pagos");
            modelBuilder.Entity<Pagos>().HasKey(u => u.Id);
            modelBuilder.Entity<Pagos>().Property(u => u.Id).HasColumnName("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<Pagos>().Property(u => u.PedidoId).HasColumnName("PedidoId");
            modelBuilder.Entity<Pagos>().Property(u => u.Monto).HasColumnName("Monto");
            modelBuilder.Entity<Pagos>().Property(u => u.MetodoPago).HasColumnName("MetodoPago");
            modelBuilder.Entity<Pagos>().Property(u => u.CodigoTransaccion).HasColumnName("CodigoTransaccion");
            modelBuilder.Entity<Pagos>().Property(u => u.ReferenciaPago).HasColumnName("ReferenciaPago");
            modelBuilder.Entity<Pagos>().Property(u => u.Factura).HasColumnName("Factura");
            modelBuilder.Entity<Pagos>().Property(u => u.EstadoTransaccion).HasColumnName("EstadoTransaccion");
            modelBuilder.Entity<Pagos>().Property(u => u.FechaFinalizacionPago).HasColumnName("FechaPago");
        }
        /// <summary>
        /// Guarda los cambios en la base de datos de forma asíncrona.
        /// </summary>
        /// <returns>True si se guardaron cambios; de lo contrario, false.</returns>
        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }
    }
}
