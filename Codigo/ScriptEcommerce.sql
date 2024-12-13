-- Crear base de datos y usarla
CREATE DATABASE Ecommerce;
USE Ecommerce;

-- Crear tablas independientes primero, sin dependencias externas
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

-- Crear la tabla Promociones
CREATE TABLE Promociones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100),
    Descripcion NVARCHAR(500),
    FechaInicio DATETIME,
    FechaFin DATETIME,
    Descuento DECIMAL(5,2) -- Descuento en porcentaje
);

-- Crear la tabla EmpresasEnvio
CREATE TABLE EmpresasEnvio (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100),
    Contacto NVARCHAR(100)
);

-- Crear la tabla Usuarios antes de Productos
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
    FOREIGN KEY (RolId) REFERENCES Roles(Id) ON DELETE SET NULL ON UPDATE CASCADE
);

-- Crear la tabla Productos
CREATE TABLE Productos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100),
    Descripcion NVARCHAR(500),
    Precio DECIMAL(18,2),
    Stock INT,
    FechaCreacion DATETIME,
    CategoriaId INT,
    VendedorId INT,
    FOREIGN KEY (CategoriaId) REFERENCES Categoria(Id) ON DELETE SET NULL ON UPDATE CASCADE,
    FOREIGN KEY (VendedorId) REFERENCES Usuarios(Id) ON DELETE SET NULL ON UPDATE CASCADE
);

-- Crear la tabla ImagenProducto
CREATE TABLE ImagenProducto (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UrlImagen NVARCHAR(255),
    ProductoId INT,
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Crear las tablas que dependen de los elementos anteriores
CREATE TABLE Pedidos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ClienteId INT,
    Estado NVARCHAR(50),
    Total DECIMAL(18,2),
    FechaPedido DATETIME,
    FOREIGN KEY (ClienteId) REFERENCES Usuarios(Id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE Cupones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProductoId INT,
    PromocionId INT,
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (PromocionId) REFERENCES Promociones(Id) ON DELETE SET NULL ON UPDATE CASCADE
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
    FOREIGN KEY (PedidoId) REFERENCES Pedidos(Id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE TrackingEnvio (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    EnvioId INT,
    Estado NVARCHAR(50),
    Ubicacion NVARCHAR(100),
    Fecha DATETIME,
    FOREIGN KEY (EnvioId) REFERENCES Envios(Id) ON DELETE CASCADE ON UPDATE CASCADE
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
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (NotificacionId) REFERENCES Notificaciones(Id) ON DELETE SET NULL ON UPDATE CASCADE
);

CREATE TABLE RolesPermisos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    RolId INT,
    PermisoId INT,
    FOREIGN KEY (RolId) REFERENCES Roles(Id) ON DELETE CASCADE ON UPDATE CASCADE,
    FOREIGN KEY (PermisoId) REFERENCES Permisos(Id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE TicketsSoporte (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioId INT,
    Titulo NVARCHAR(100),
    Descripcion NVARCHAR(500),
    Estado NVARCHAR(50),
    FechaCreacion DATETIME,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE SET NULL ON UPDATE CASCADE
);

CREATE TABLE Tokens (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioId INT,
    TokenValue NVARCHAR(255),
    Expira DATETIME,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE CASCADE ON UPDATE CASCADE
);

CREATE TABLE ReporteAcciones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioId INT,
    Descripcion NVARCHAR(500),
    FechaReporte DATETIME,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE CASCADE ON UPDATE CASCADE
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
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id) ON DELETE CASCADE ON UPDATE CASCADE
);

-- Insertar datos en las tablas

-- Insertar datos en la tabla Categoria
INSERT INTO Categoria (Nombre)
VALUES 
('Electrónica'),
('Ropa'),
('Hogar');

-- Insertar datos en la tabla Roles
INSERT INTO Roles (Nombre)
VALUES 
('Admin'),
('Vendedor'),
('Cliente');

-- Insertar datos en la tabla Permisos
INSERT INTO Permisos (Nombre)
VALUES 
('Ver Productos'),
('Agregar Producto'),
('Eliminar Producto');

-- Insertar datos en la tabla Promociones
INSERT INTO Promociones (Nombre, Descripcion, FechaInicio, FechaFin, Descuento)
VALUES 
('Descuento Navidad', 'Descuento especial por las fiestas navideñas', '2024-12-01', '2024-12-25', 20.00),
('Black Friday', 'Promoción por el Black Friday con grandes descuentos', '2024-11-25', '2024-11-29', 30.00),
('Cyber Monday', 'Descuento especial solo por Cyber Monday', '2024-11-30', '2024-12-02', 15.00);

-- Insertar datos en la tabla Usuarios
INSERT INTO Usuarios (Nombre, Correo, Contraseña, Telefono, Direccion, TipoUsuario, FechaCreacion, RolId)
VALUES 
('Juan Pérez', 'juan@correo.com', 'contraseña1', '123456789', 'Calle Falsa 123', 'Cliente', GETDATE(), 3),
('Ana Gómez', 'ana@correo.com', 'contraseña2', '987654321', 'Avenida Siempre Viva 456', 'Vendedor', GETDATE(), 2),
('Carlos López', 'carlos@correo.com', 'contraseña3', '456789123', 'Calle del Sol 789', 'Admin', GETDATE(), 1);

-- Insertar datos en la tabla Productos
INSERT INTO Productos (Nombre, Descripcion, Precio, Stock, FechaCreacion, CategoriaId, VendedorId)
VALUES 
('Smartphone', 'Teléfono móvil con pantalla de 6.5 pulgadas', 499.99, 100, GETDATE(), 1, 2),
('Chaqueta', 'Chaqueta de invierno para hombre', 89.99, 50, GETDATE(), 2, 2),
('Sofá', 'Sofá de tres plazas color gris', 299.99, 20, GETDATE(), 3, 2);

-- Insertar datos en la tabla ImagenProducto
INSERT INTO ImagenProducto (UrlImagen, ProductoId)
VALUES 
('https://example.com/smartphone.jpg', 1),
('https://example.com/chaqueta.jpg', 2),
('https://example.com/sofa.jpg', 3);

-- Insertar datos en la tabla Cupones
INSERT INTO Cupones (ProductoId, PromocionId)
VALUES 
(1, 1),
(2, 2),
(3, 3);

-- Insertar datos en la tabla Comentarios
INSERT INTO Comentarios (UsuarioId, ProductoId, ComentarioTexto, FechaComentario)
VALUES 
(1, 1, 'Excelente producto, muy recomendable', GETDATE()),
(2, 2, 'Buena calidad, pero el tamaño no es el que esperaba', GETDATE()),
(3, 3, 'Muy cómodo y espacioso, lo recomiendo', GETDATE());

-- Insertar datos en la tabla Valoraciones
INSERT INTO Valoraciones (UsuarioId, ProductoId, Valor, FechaValoracion)
VALUES 
(1, 1, 5, GETDATE()),
(2, 2, 3, GETDATE()),
(3, 3, 4, GETDATE());

-- Insertar datos en la tabla Envios
INSERT INTO Envios ( EmpresaEnvio, NumeroGuia, EstadoEnvio, FechaEnvio, FechaEntrega)
VALUES 
( 'DHL', '12345', 'En tránsito', GETDATE(), GETDATE()),
( 'FedEx', '67890', 'Entregado', GETDATE(), GETDATE()),
( 'UPS', '11223', 'Pendiente', GETDATE(), NULL);

INSERT INTO TrackingEnvio (EnvioId, Estado, Ubicacion, Fecha)
VALUES 
(2, 'Entregado', 'Guadalajara', '2024-12-10 14:30:00');

INSERT INTO TrackingEnvio (EnvioId, Estado, Ubicacion, Fecha)
VALUES 
(2, 'Entregado', 'Guadalajara', '2024-12-10 14:30:00');

INSERT INTO TrackingEnvio (EnvioId, Estado, Ubicacion, Fecha)
VALUES 
(3, 'Pendiente', 'Monterrey', '2024-12-11 10:00:00');

-- Insertar datos en la tabla LogsSistema
INSERT INTO LogsSistema (Nivel, Mensaje, FechaLog)
VALUES 
('INFO', 'Inicio del sistema', GETDATE()),
('ERROR', 'Fallo en el servidor', GETDATE()),
('WARNING', 'Advertencia de conexión', GETDATE());

-- Insertar datos en la tabla Notificaciones
INSERT INTO Notificaciones (Titulo, Mensaje, FechaEnvio)
VALUES 
('Nuevo Producto', 'Se ha agregado un nuevo producto a la tienda', GETDATE()),
('Descuento Especial', '¡Aprovecha un 20% de descuento en tu compra!', GETDATE());

-- Insertar datos en la tabla UsuariosNotificados
INSERT INTO UsuariosNotificados (UsuarioId, NotificacionId, Leido, FechaLeido)
VALUES 
(1, 1, 0, NULL),
(2, 2, 1, GETDATE());

-- Insertar datos en la tabla RolesPermisos
INSERT INTO RolesPermisos (RolId, PermisoId)
VALUES 
(1, 1),
(2, 2),
(3, 3);
-- Insertar datos en la tabla Pedidos
INSERT INTO Pedidos (ClienteId, Estado, Total, FechaPedido)
VALUES 
(1, 'Pendiente', 589.98, GETDATE()),
(2, 'Completado', 179.98, GETDATE()),
(3, 'Cancelado', 299.99, GETDATE());

-- Insertar datos en la tabla Envios
INSERT INTO Envios (PedidoId, EmpresaEnvio, NumeroGuia, EstadoEnvio, FechaEnvio, FechaEntrega)
VALUES 
(1, 'DHL', '12345', 'En tránsito', GETDATE(), NULL),
(2, 'FedEx', '67890', 'Entregado', GETDATE(), GETDATE()),
(3, 'UPS', '11223', 'Pendiente', GETDATE(), NULL);

-- Insertar datos en la tabla TrackingEnvio
INSERT INTO TrackingEnvio (EnvioId, Estado, Ubicacion, Fecha)
VALUES 
(1, 'En tránsito', 'Ciudad de México', GETDATE()),
(2, 'Entregado', 'Guadalajara', GETDATE()),
(3, 'Pendiente', 'Monterrey', GETDATE());

-- Insertar datos en la tabla TicketsSoporte
INSERT INTO TicketsSoporte (UsuarioId, Titulo, Descripcion, Estado, FechaCreacion)
VALUES 
(1, 'Problema con el pedido', 'No he recibido mi pedido aún', 'Abierto', GETDATE()),
(2, 'Producto defectuoso', 'El producto llegó con un defecto', 'Resuelto', GETDATE()),
(3, 'Consulta de envío', 'Quisiera saber el estado de mi envío', 'En progreso', GETDATE());

-- Insertar datos en la tabla Tokens
INSERT INTO Tokens (UsuarioId, TokenValue, Expira)
VALUES 
(1, 'abcd1234', DATEADD(HOUR, 1, GETDATE())),
(2, 'efgh5678', DATEADD(HOUR, 1, GETDATE())),
(3, 'ijkl9012', DATEADD(HOUR, 1, GETDATE()));

-- Insertar datos en la tabla ReporteAcciones
INSERT INTO ReporteAcciones (UsuarioId, Descripcion, FechaReporte)
VALUES 
(1, 'Intento de acceso no autorizado', GETDATE()),
(2, 'Problema en el sistema de pago', GETDATE()),
(3, 'Consulta sobre políticas de devolución', GETDATE());

-- Insertar datos en la tabla RespuestasFAQ
INSERT INTO RespuestasFAQ (Pregunta, Respuesta)
VALUES 
('¿Cómo puedo realizar un pago?', 'Puedes pagar con tarjeta de crédito, PayPal o transferencia bancaria.'),
('¿Puedo devolver un producto?', 'Sí, puedes devolver productos dentro de los 30 días posteriores a la compra.'),
('¿Cuánto tiempo tarda el envío?', 'El tiempo de envío depende de la empresa de mensajería, pero generalmente de 3 a 7 días hábiles.');

-- Insertar datos en la tabla Inventarios
INSERT INTO Inventarios (ProductoId, Cantidad, UltimaActualizacion)
VALUES 
(1, 100, GETDATE()),
(2, 50, GETDATE()),
(3, 20, GETDATE());

-- Insertar datos en la tabla UsuariosNotificados
INSERT INTO UsuariosNotificados (UsuarioId, NotificacionId, Leido, FechaLeido)
VALUES 
(1, 1, 0, NULL),
(2, 2, 1, GETDATE());

-- Insertar datos en la tabla LogsSistema
INSERT INTO LogsSistema (Nivel, Mensaje, FechaLog)
VALUES 
('INFO', 'Inicio del sistema', GETDATE()),
('ERROR', 'Fallo en el servidor', GETDATE()),
('WARNING', 'Advertencia de conexión', GETDATE());

-- Insertar datos en la tabla Notificaciones
INSERT INTO Notificaciones (Titulo, Mensaje, FechaEnvio)
VALUES 
('Nuevo Producto', 'Se ha agregado un nuevo producto a la tienda', GETDATE()),
('Descuento Especial', '¡Aprovecha un 20% de descuento en tu compra!', GETDATE());
