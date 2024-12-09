-- Base de datos y uso
CREATE DATABASE Ecommerce;
USE Ecommerce;

-- Crear tablas con eliminación en cascada
CREATE TABLE Categoria (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100)
);

CREATE TABLE Roles (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100)
);

CREATE TABLE Permisos (
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
    FOREIGN KEY (RolId) REFERENCES Roles(Id) ON DELETE NO ACTION ON UPDATE NO ACTION
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
    FOREIGN KEY (CategoriaId) REFERENCES Categoria(Id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (VendedorId) REFERENCES Usuarios(Id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE ImagenProducto (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UrlImagen NVARCHAR(255),
    ProductoId INT,
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE Pedidos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ClienteId INT,
    Estado NVARCHAR(50),
    Total DECIMAL(18,2),
    FechaPedido DATETIME,
    FOREIGN KEY (ClienteId) REFERENCES Usuarios(Id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE DetallesPedidos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PedidoId INT,
    ProductoId INT,
    Cantidad INT,
    PrecioUnitario DECIMAL(18,2),
    FOREIGN KEY (PedidoId) REFERENCES Pedidos(Id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id) ON DELETE NO ACTION ON UPDATE NO ACTION
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
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (PromocionId) REFERENCES Promociones(Id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE Comentarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioId INT,
    ProductoId INT,
    ComentarioTexto NVARCHAR(500),
    FechaComentario DATETIME,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE Valoraciones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioId INT,
    ProductoId INT,
    Valor INT,
    FechaValoracion DATETIME,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE Envios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PedidoId INT,
    EmpresaEnvio NVARCHAR(100),
    NumeroGuia NVARCHAR(100),
    EstadoEnvio NVARCHAR(50),
    FechaEnvio DATETIME,
    FechaEntrega DATETIME,
    FOREIGN KEY (PedidoId) REFERENCES Pedidos(Id) ON DELETE NO ACTION ON UPDATE NO ACTION
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
    FOREIGN KEY (EnvioId) REFERENCES Envios(Id) ON DELETE NO ACTION ON UPDATE NO ACTION
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
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (NotificacionId) REFERENCES Notificaciones(Id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE RolesPermisos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    RolId INT,
    PermisoId INT,
    FOREIGN KEY (RolId) REFERENCES Roles(Id) ON DELETE NO ACTION ON UPDATE NO ACTION,
    FOREIGN KEY (PermisoId) REFERENCES Permisos(Id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE TicketsSoporte (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioId INT,
    Titulo NVARCHAR(100),
    Descripcion NVARCHAR(500),
    Estado NVARCHAR(50),
    FechaCreacion DATETIME,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE Tokens (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioId INT,
    TokenValue NVARCHAR(255),
    Expira DATETIME,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE NO ACTION ON UPDATE NO ACTION
);

CREATE TABLE ReporteAcciones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioId INT,
    Descripcion NVARCHAR(500),
    FechaReporte DATETIME,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE NO ACTION ON UPDATE NO ACTION
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
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id) ON DELETE NO ACTION ON UPDATE NO ACTION
);


-- Insertar datos en las tablas
INSERT INTO Categoria (Nombre) VALUES ('Electrónica'), ('Ropa'), ('Hogar');
INSERT INTO Roles (Nombre) VALUES ('Administrador'), ('Vendedor'), ('Cliente');
INSERT INTO Permisos (Nombre) VALUES ('Gestionar Usuarios'), ('Gestionar Productos'), ('Gestionar Pedidos');
INSERT INTO Usuarios (Nombre, Correo, Contraseña, Telefono, Direccion, TipoUsuario, FechaCreacion, RolId) VALUES
('Juan Pérez', 'juan@example.com', 'password123', '123456789', 'Calle Falsa 123', 'Cliente', GETDATE(), 3),
('Ana López', 'ana@example.com', 'password456', '987654321', 'Avenida Siempre Viva 456', 'Vendedor', GETDATE(), 2),
('Carlos Ruiz', 'carlos@example.com', 'password789', '555555555', 'Boulevard Principal 789', 'Administrador', GETDATE(), 1);

INSERT INTO Productos (Nombre, Descripcion, Precio, Stock, FechaCreacion, CategoriaId, VendedorId) VALUES
('Laptop', 'Laptop de alto rendimiento', 1500.00, 10, GETDATE(), 1, 2),
('Camiseta', 'Camiseta de algodón', 20.00, 50, GETDATE(), 2, 2),
('Sofá', 'Sofá cómodo y moderno', 500.00, 5, GETDATE(), 3, 2);

INSERT INTO ImagenProducto (UrlImagen, ProductoId) VALUES
('http://example.com/laptop.jpg', 1),
('http://example.com/camiseta.jpg', 2),
('http://example.com/sofa.jpg', 3);

INSERT INTO Pedidos (ClienteId, Estado, Total, FechaPedido) VALUES
(1, 'Pendiente', 1520.00, GETDATE()),
(1, 'Enviado', 500.00, GETDATE()),
(1, 'Entregado', 20.00, GETDATE());

INSERT INTO DetallesPedidos (PedidoId, ProductoId, Cantidad, PrecioUnitario) VALUES
(1, 1, 1, 1500.00),
(2, 3, 1, 500.00),
(3, 2, 1, 20.00);

INSERT INTO Promociones (Nombre, Descuento, FechaInicio, FechaFin) VALUES
('Descuento Verano', 10.00, GETDATE(), DATEADD(DAY, 30, GETDATE())),
('Black Friday', 50.00, GETDATE(), DATEADD(DAY, 60, GETDATE())),
('Navidad', 20.00, GETDATE(), DATEADD(DAY, 90, GETDATE()));

INSERT INTO Cupones (ProductoId, PromocionId) VALUES
(1, 1),
(2, 2),
(3, 3);

INSERT INTO Comentarios (UsuarioId, ProductoId, ComentarioTexto, FechaComentario) VALUES
(1, 1, 'Excelente producto', GETDATE()),
(1, 2, 'Buena calidad', GETDATE()),
(1, 3, 'Muy cómodo', GETDATE());

INSERT INTO Valoraciones (UsuarioId, ProductoId, Valor, FechaValoracion) VALUES
(1, 1, 5, GETDATE()),
(1, 2, 4, GETDATE()),
(1, 3, 5, GETDATE());

INSERT INTO Envios (PedidoId, EmpresaEnvio, NumeroGuia, EstadoEnvio, FechaEnvio, FechaEntrega) VALUES
(1, 'DHL', '12345', 'En tránsito', GETDATE(), DATEADD(DAY, 5, GETDATE())),
(2, 'FedEx', '67890', 'Entregado', GETDATE(), DATEADD(DAY, 2, GETDATE())),
(3, 'UPS', '11223', 'Pendiente', GETDATE(), DATEADD(DAY, 7, GETDATE()));

INSERT INTO EmpresasEnvio (Nombre, Contacto) VALUES
('DHL', 'contacto@dhl.com'),
('FedEx', 'contacto@fedex.com'),
('UPS', 'contacto@ups.com');

INSERT INTO TrackingEnvio (EnvioId, Estado, Ubicacion, Fecha) VALUES
(1, 'En tránsito', 'Centro de distribución', GETDATE()),
(2, 'Entregado', 'Dirección del cliente', GETDATE()),
(3, 'Pendiente', 'Almacén', GETDATE());

INSERT INTO LogsSistema (Nivel, Mensaje, FechaLog) VALUES
('INFO', 'Inicio de sesión exitoso', GETDATE()),
('ERROR', 'Fallo en el sistema de pagos', GETDATE()),
('WARNING', 'Intento de acceso no autorizado', GETDATE());

INSERT INTO Notificaciones (Titulo, Mensaje, FechaEnvio) VALUES
('Bienvenido', 'Gracias por registrarte', GETDATE()),
('Oferta especial', 'Aprovecha nuestros descuentos', GETDATE()),
('Actualización de sistema', 'El sistema estará en mantenimiento', GETDATE());

INSERT INTO UsuariosNotificados (UsuarioId, NotificacionId, Leido, FechaLeido) VALUES
(1, 1, 1, GETDATE()),
(2, 2, 0, NULL),
(3, 3, 1, GETDATE());

INSERT INTO RolesPermisos (RolId, PermisoId) VALUES
(1, 1),
(1, 2),
(2, 3);

INSERT INTO TicketsSoporte (UsuarioId, Titulo, Descripcion, Estado, FechaCreacion) VALUES
(1, 'Error en la compra', 'No se pudo completar la compra', 'Abierto', GETDATE()),
(2, 'Consulta sobre producto', '¿Cuándo reponen stock?', 'Cerrado', GETDATE()),
(3, 'Problema con envío', 'El envío no ha llegado', 'En progreso', GETDATE());

INSERT INTO Tokens (UsuarioId, TokenValue, Expira) VALUES
(1, 'token123', DATEADD(DAY, 7, GETDATE())),
(2, 'token456', DATEADD(DAY, 7, GETDATE())),
(3, 'token789', DATEADD(DAY, 7, GETDATE()));

INSERT INTO ReporteAcciones (UsuarioId, Descripcion, FechaReporte) VALUES
(1, 'Intento de acceso no autorizado', GETDATE()),
(2, 'Actualización de perfil', GETDATE()),
(3, 'Realizó una compra', GETDATE());

INSERT INTO RespuestasFAQ (Pregunta, Respuesta) VALUES
('¿Cómo realizo una compra?', 'Selecciona el producto y sigue los pasos en pantalla'),
('¿Qué métodos de pago aceptan?', 'Tarjeta de crédito, débito y PayPal'),
('¿Cómo contacto con soporte?', 'A través de nuestro formulario de contacto');

INSERT INTO Inventarios (ProductoId, Cantidad, UltimaActualizacion) VALUES
(1, 10, GETDATE()),
(2, 50, GETDATE()),
(3, 5, GETDATE());

select * from Comentarios