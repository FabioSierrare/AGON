﻿using E_Commerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace MicroServiceCRUD.Repositories
{

        /// <summary>
        /// Servicio de base de datos que representa el contexto de la aplicación.
        /// Contiene los DbSet de cada entidad y la configuración del modelo.
        /// </summary>
        public class DatabaseService : DbContext
        {
            /// <summary>
            /// Constructor que recibe las opciones del contexto.
            /// </summary>
            /// <param name="options">Opciones de configuración del contexto</param>
            public DatabaseService(DbContextOptions options) : base(options)
            {
            }
            public DbSet<Categorias> Categorias { get; set; }
        public DbSet<ProductosDescuento> ProductosDescuento { get; set; }
        public DbSet<Comentarios> Comentarios { get; set; }
        public DbSet<Cupones> Cupones { get; set; }
        public DbSet<DetallesPedidos> DetallesPedidos { get; set; }
        public DbSet<Envios> Envios { get; set; }
        public DbSet<Inventarios> Inventarios { get; set; }
        public DbSet<ImgPerfil> ImgPerfil { get; set; }
        public DbSet<LogsSistema> LogsSistema { get; set; }
        public DbSet<Notificaciones> Notificaciones { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }
        public DbSet<Permisos> Permisos { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Descuentos> Descuentos { get; set; }
        public DbSet<ReporteAcciones> ReporteAcciones { get; set; }
        public DbSet<RespuestasFAQ> RespuestasFAQ { get; set; }
        public DbSet<RolesPermisos> RolesPermisos { get; set; }
        public DbSet<TicketsSoporte> TicketsSoporte { get; set; }
        public DbSet<TrackingEnvio> TrackingEnvio { get; set; }
        public DbSet<TipoUsuarios> TipoUsuarios { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<UsuariosNotificados> UsuariosNotificados { get; set; }
        public DbSet<Valoraciones> Valoraciones { get; set; }


        /// <summary>
        /// Configuración adicional de entidades del modelo.
        /// </summary>
        /// <param name="modelBuilder">Constructor del modelo</param>

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuarios>(entity =>
            {
                // 1) Mapea la tabla y le “pega” el trigger
                entity.ToTable("Usuarios", tb => tb.HasTrigger("trg_DeleteUsuario_CascadeAll"));

                // 2) Aquí el resto de tu configuración puntual:
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Nombre).HasColumnName("Nombre");
                // …etc…
            });

            // configura el resto de entidades
            EntityConfuguration(modelBuilder);
        }

        /// <summary>
        /// Método personalizado para configurar las entidades y sus propiedades.
        /// </summary>
        /// <param name="modelBuilder">Constructor del modelo</param>
        /// 
        private void EntityConfuguration(ModelBuilder modelBuilder)
        {

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
            modelBuilder.Entity<Permisos>().ToTable("Permisos");
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
            modelBuilder.Entity<TipoUsuarios>().ToTable("TipoUsuarios");
            modelBuilder.Entity<TipoUsuarios>().HasKey(tu => tu.Id);
            modelBuilder.Entity<TipoUsuarios>()
                .Property(tu => tu.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<TipoUsuarios>()
                .Property(tu => tu.Nombre)
                .HasColumnName("Nombre")
                .IsRequired()
                .HasMaxLength(100); // Ajusta el HasMaxLength según la definición en BD, p. ej. NVARCHAR(100)

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
        /// Guarda los cambios realizados en el contexto de forma asincrónica.
        /// </summary>
        /// <returns>True si se guardaron los cambios correctamente</returns>

        public async Task<bool> SaveAsync()
        {
            return await SaveChangesAsync() > 0;
        }
    }
}