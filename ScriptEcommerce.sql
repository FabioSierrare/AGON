CREATE DATABASE Ecommerce;

USE Ecommerce;

CREATE TABLE Categoria (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100)
);

CREATE TABLE Roles (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100)
);

CREATE TABLE Usuarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100),
    Correo NVARCHAR(100),
    Contraseña NVARCHAR(100),
    Telefono NVARCHAR(20),
    Direccion NVARCHAR(200),
    TipoUsuario NVARCHAR(50),
    FechaCreacion DATETIME,
    RolId INT,
    FOREIGN KEY (RolId) REFERENCES Roles(Id) ON DELETE SET NULL
);

CREATE TABLE Productos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100),
    Descripcion NVARCHAR(500),
    Precio DECIMAL(18,2),
    Stock INT,
    FechaCreacion DATETIME,
    CategoriaId INT,
    VendedorId INT,
    FOREIGN KEY (CategoriaId) REFERENCES Categoria(Id) ON DELETE CASCADE,
    FOREIGN KEY (VendedorId) REFERENCES Usuarios(Id) ON DELETE SET NULL
);

CREATE TABLE Pedidos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ClienteId INT,
    Estado NVARCHAR(50),
    Total DECIMAL(18,2),
    FechaPedido DATETIME,
    FOREIGN KEY (ClienteId) REFERENCES Usuarios(Id) ON DELETE CASCADE
);

CREATE TABLE DetallesPedidos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PedidoId INT,
    ProductoId INT,
    Cantidad INT,
    PrecioUnitario DECIMAL(18,2),
    FOREIGN KEY (PedidoId) REFERENCES Pedidos(Id) ON DELETE CASCADE,
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id) ON DELETE NO ACTION
);

CREATE TABLE ImagenProducto (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UrlImagen NVARCHAR(255),
    ProductoId INT,
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id) ON DELETE CASCADE
);

CREATE TABLE Promociones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100),
    Descuento DECIMAL(18,2),
    FechaInicio DATETIME,
    FechaFin DATETIME
);

CREATE TABLE Cupones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProductoId INT,
    PromocionId INT,
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id) ON DELETE CASCADE,
    FOREIGN KEY (PromocionId) REFERENCES Promociones(Id) ON DELETE CASCADE
);

CREATE TABLE Comentarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioId INT,
    ProductoId INT,
    ComentarioTexto NVARCHAR(500),
    FechaComentario DATETIME,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE CASCADE,
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id) ON DELETE CASCADE
);

CREATE TABLE Valoraciones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioId INT,
    ProductoId INT,
    Valor INT,
    FechaValoracion DATETIME,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE CASCADE,
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id) ON DELETE CASCADE
);

CREATE TABLE Envios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PedidoId INT,
    EmpresaEnvio NVARCHAR(100),
    NumeroGuia NVARCHAR(100),
    EstadoEnvio NVARCHAR(50),
    FechaEnvio DATETIME,
    FechaEntrega DATETIME,
    FOREIGN KEY (PedidoId) REFERENCES Pedidos(Id) ON DELETE CASCADE
);

CREATE TABLE EmpresasEnvio (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100),
    Contacto NVARCHAR(100)
);

CREATE TABLE TrackingEnvio (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    EnvioId INT,
    Estado NVARCHAR(50),
    Ubicacion NVARCHAR(100),
    Fecha DATETIME,
    FOREIGN KEY (EnvioId) REFERENCES Envios(Id) ON DELETE CASCADE
);

CREATE TABLE LogsSistema (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nivel NVARCHAR(50),
    Mensaje NVARCHAR(500),
    FechaLog DATETIME
);

CREATE TABLE Notificaciones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Titulo NVARCHAR(100),
    Mensaje NVARCHAR(500),
    FechaEnvio DATETIME
);

CREATE TABLE UsuariosNotificados (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioId INT,
    NotificacionId INT,
    Leido BIT,
    FechaLeido DATETIME,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE CASCADE,
    FOREIGN KEY (NotificacionId) REFERENCES Notificaciones(Id) ON DELETE CASCADE
);

CREATE TABLE Permisos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100)
);

CREATE TABLE RolesPermisos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    RolId INT,
    PermisoId INT,
    FOREIGN KEY (RolId) REFERENCES Roles(Id) ON DELETE CASCADE,
    FOREIGN KEY (PermisoId) REFERENCES Permisos(Id) ON DELETE CASCADE
);

CREATE TABLE TicketsSoporte (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioId INT,
    Titulo NVARCHAR(100),
    Descripcion NVARCHAR(500),
    Estado NVARCHAR(50),
    FechaCreacion DATETIME,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE CASCADE
);

CREATE TABLE Tokens (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioId INT,
    TokenValue NVARCHAR(255),
    Expira DATETIME,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE CASCADE
);

CREATE TABLE ReporteAcciones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioId INT,
    Descripcion NVARCHAR(500),
    FechaReporte DATETIME,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE CASCADE
);

CREATE TABLE RespuestasFAQ (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Pregunta NVARCHAR(500),
    Respuesta NVARCHAR(500)
);

CREATE TABLE Inventarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProductoId INT,
    Cantidad INT,
    UltimaActualizacion DATETIME,
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id) ON DELETE CASCADE
);



-- Insertar valores en la tabla Categoria
INSERT INTO Categoria (Nombre) VALUES 
('Electrónica'), 
('Ropa'), 
('Hogar');

-- Insertar valores en la tabla Roles
INSERT INTO Roles (Nombre) VALUES 
('Administrador'), 
('Cliente'), 
('Vendedor');

-- Insertar valores en la tabla Usuarios
INSERT INTO Usuarios (Nombre, Correo, Contraseña, Telefono, Direccion, TipoUsuario, FechaCreacion, RolId) VALUES 
('Juan Perez', 'juan.perez@mail.com', '123456', '1234567890', 'Calle 123', 'Cliente', GETDATE(), 2), 
('Ana López', 'ana.lopez@mail.com', '654321', '0987654321', 'Avenida 456', 'Vendedor', GETDATE(), 3), 
('Admin User', 'admin@mail.com', 'adminpass', '1112223333', 'Admin HQ', 'Administrador', GETDATE(), 1);

-- Insertar valores en la tabla Productos
INSERT INTO Productos (Nombre, Descripcion, Precio, Stock, FechaCreacion, CategoriaId, VendedorId) VALUES 
('Laptop', 'Laptop de alta gama', 1500.99, 10, GETDATE(), 1, 2), 
('Camiseta', 'Camiseta 100% algodón', 19.99, 50, GETDATE(), 2, 2), 
('Sofá', 'Sofá de tres plazas', 450.00, 5, GETDATE(), 3, 2);

-- Insertar valores en la tabla Pedidos
INSERT INTO Pedidos (ClienteId, Estado, Total, FechaPedido) VALUES 
(1, 'Pendiente', 1519.98, GETDATE()), 
(1, 'Completado', 450.00, GETDATE()), 
(1, 'Cancelado', 19.99, GETDATE());

-- Insertar valores en la tabla DetallesPedidos
INSERT INTO DetallesPedidos (PedidoId, ProductoId, Cantidad, PrecioUnitario) VALUES 
(1, 1, 1, 1500.99), 
(2, 3, 1, 450.00), 
(3, 2, 1, 19.99);

-- Insertar valores en la tabla ImagenProducto
INSERT INTO ImagenProducto (UrlImagen, ProductoId) VALUES 
('laptop.jpg', 1), 
('camiseta.jpg', 2), 
('sofa.jpg', 3);

-- Insertar valores en la tabla Promociones
INSERT INTO Promociones (Nombre, Descuento, FechaInicio, FechaFin) VALUES 
('Descuento Verano', 10.00, '2024-06-01', '2024-09-01'), 
('Oferta Navideña', 15.00, '2024-12-01', '2025-01-01'), 
('Promoción Aniversario', 5.00, '2024-01-01', '2024-01-31');

-- Insertar valores en la tabla Cupones
INSERT INTO Cupones (ProductoId, PromocionId) VALUES 
(1, 1), 
(2, 2), 
(3, 3);

-- Insertar valores en la tabla Comentarios
INSERT INTO Comentarios (UsuarioId, ProductoId, ComentarioTexto, FechaComentario) VALUES 
(1, 1, 'Excelente producto', GETDATE()), 
(1, 2, 'Muy buena calidad', GETDATE()), 
(1, 3, 'Súper cómodo', GETDATE());

-- Insertar valores en la tabla Valoraciones
INSERT INTO Valoraciones (UsuarioId, ProductoId, Valor, FechaValoracion) VALUES 
(1, 1, 5, GETDATE()), 
(1, 2, 4, GETDATE()), 
(1, 3, 5, GETDATE());

-- Insertar valores en la tabla Envios
INSERT INTO Envios (PedidoId, EmpresaEnvio, NumeroGuia, EstadoEnvio, FechaEnvio, FechaEntrega) VALUES 
(1, 'DHL', '123456789', 'En tránsito', GETDATE(), GETDATE() + 3), 
(2, 'FedEx', '987654321', 'Entregado', GETDATE() - 2, GETDATE()), 
(3, 'UPS', '456789123', 'Cancelado', NULL, NULL);

-- Insertar valores en la tabla EmpresasEnvio
INSERT INTO EmpresasEnvio (Nombre, Contacto) VALUES 
('DHL', 'dhl@envio.com'), 
('FedEx', 'fedex@envio.com'), 
('UPS', 'ups@envio.com');

-- Insertar valores en la tabla TrackingEnvio
INSERT INTO TrackingEnvio (EnvioId, Estado, Ubicacion, Fecha) VALUES 
(1, 'En tránsito', 'Ciudad A', GETDATE()), 
(2, 'Entregado', 'Ciudad B', GETDATE() - 1), 
(3, 'Cancelado', 'Ciudad C', GETDATE());

-- Insertar valores en la tabla LogsSistema
INSERT INTO LogsSistema (Nivel, Mensaje, FechaLog) VALUES 
('INFO', 'Sistema iniciado', GETDATE()), 
('ERROR', 'Fallo al conectar con la base de datos', GETDATE()), 
('WARN', 'Intento de acceso no autorizado', GETDATE());

-- Insertar valores en la tabla Notificaciones
INSERT INTO Notificaciones (Titulo, Mensaje, FechaEnvio) VALUES 
('Bienvenido', 'Gracias por registrarte', GETDATE()), 
('Promoción activa', 'Descuentos por tiempo limitado', GETDATE()), 
('Recordatorio', 'Tu pedido está en camino', GETDATE());

-- Insertar valores en la tabla UsuariosNotificados
INSERT INTO UsuariosNotificados (UsuarioId, NotificacionId, Leido, FechaLeido) VALUES 
(1, 1, 1, GETDATE()), 
(1, 2, 0, NULL), 
(1, 3, 0, NULL);

-- Insertar valores en la tabla Permisos
INSERT INTO Permisos (Nombre) VALUES 
('Ver productos'), 
('Gestionar usuarios'), 
('Crear pedidos');

-- Insertar valores en la tabla RolesPermisos
INSERT INTO RolesPermisos (RolId, PermisoId) VALUES 
(1, 1), 
(1, 2), 
(2, 1);

-- Insertar valores en la tabla TicketsSoporte
INSERT INTO TicketsSoporte (UsuarioId, Titulo, Descripcion, Estado, FechaCreacion) VALUES 
(1, 'Problema con pedido', 'No recibí mi pedido', 'Pendiente', GETDATE()), 
(1, 'Producto dañado', 'El producto llegó roto', 'Resuelto', GETDATE()), 
(1, 'Consulta general', 'Quiero más información', 'Pendiente', GETDATE());

-- Insertar valores en la tabla Tokens
INSERT INTO Tokens (UsuarioId, TokenValue, Expira) VALUES 
(1, 'abc123', GETDATE() + 1), 
(2, 'def456', GETDATE() + 1), 
(3, 'ghi789', GETDATE() + 1);

-- Insertar valores en la tabla ReporteAcciones
INSERT INTO ReporteAcciones (UsuarioId, Descripcion, FechaReporte) VALUES 
(1, 'Inicio de sesión', GETDATE()), 
(2, 'Actualización de datos', GETDATE()), 
(3, 'Borrado de cuenta', GETDATE());

-- Insertar valores en la tabla RespuestasFAQ
INSERT INTO RespuestasFAQ (Pregunta, Respuesta) VALUES 
('¿Cómo comprar?', 'Sigue los pasos en la sección de ayuda.'), 
('¿Cómo devolver?', 'Consulta nuestra política de devoluciones.'), 
('¿Qué métodos de pago aceptan?', 'Aceptamos tarjetas y PayPal.');

-- Insertar valores en la tabla Inventarios
INSERT INTO Inventarios (ProductoId, Cantidad, UltimaActualizacion) VALUES 
(1, 10, GETDATE()), 
(2, 50, GETDATE()), 
(3, 5, GETDATE());
