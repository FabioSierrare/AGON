-- Crear base de datos Ecommerce
CREATE DATABASE Ecommerce;
USE Ecommerce;

-- Crear tablas de referencia y relaciones
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
    FOREIGN KEY (RolId) REFERENCES Roles(Id) ON DELETE SET NULL
);

-- Tablas de Productos y Categorías
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

CREATE TABLE ImagenProducto (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UrlImagen NVARCHAR(255),
    ProductoId INT,
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id) ON DELETE CASCADE
);

-- Tabla de Pedidos y detalles
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
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id) ON DELETE CASCADE
);

-- Tabla de Promociones y cupones
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

-- Tablas de comentarios y valoraciones
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

-- Tablas de Envíos y Tracking
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

-- Tablas de Logs y Notificaciones
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

-- Tablas de Roles y Permisos
CREATE TABLE RolesPermisos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    RolId INT,
    PermisoId INT,
    FOREIGN KEY (RolId) REFERENCES Roles(Id) ON DELETE CASCADE,
    FOREIGN KEY (PermisoId) REFERENCES Permisos(Id) ON DELETE CASCADE
);

-- Soporte y Tickets
CREATE TABLE TicketsSoporte (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioId INT,
    Titulo NVARCHAR(100),
    Descripcion NVARCHAR(500),
    Estado NVARCHAR(50),
    FechaCreacion DATETIME,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE CASCADE
);

-- Token para autenticación
CREATE TABLE Tokens (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioId INT,
    TokenValue NVARCHAR(255),
    Expira DATETIME,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE CASCADE
);

-- Reporte de acciones de los usuarios
CREATE TABLE ReporteAcciones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioId INT,
    Descripcion NVARCHAR(500),
    FechaReporte DATETIME,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE CASCADE
);

-- Respuestas a preguntas frecuentes
CREATE TABLE RespuestasFAQ (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Pregunta NVARCHAR(500),
    Respuesta NVARCHAR(500)
);

-- Inventario de productos
CREATE TABLE Inventarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ProductoId INT,
    Cantidad INT,
    UltimaActualizacion DATETIME,
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id) ON DELETE CASCADE
);

-- Insertar datos de ejemplo en las tablas

-- Insertar categorías
INSERT INTO Categoria (Nombre) VALUES 
('Electronics'),
('Clothing'),
('Home Appliances'),
('Books');

-- Insertar roles
INSERT INTO Roles (Nombre) VALUES 
('Admin'),
('Customer'),
('Seller');

-- Insertar usuarios
INSERT INTO Usuarios (Nombre, Correo, Contraseña, Telefono, Direccion, TipoUsuario, FechaCreacion, RolId) VALUES 
('John Doe', 'john.doe@example.com', 'password123', '1234567890', '123 Main St', 'User', GETDATE(), 2),
('Jane Smith', 'jane.smith@example.com', 'password456', '0987654321', '456 Elm St', 'User', GETDATE(), 3),
('Admin User', 'admin@example.com', 'adminpass', '1122334455', '789 Oak St', 'Admin', GETDATE(), 1);

-- Insertar productos
INSERT INTO Productos (Nombre, Descripcion, Precio, Stock, FechaCreacion, CategoriaId, VendedorId) VALUES 
('Smartphone', 'Latest model smartphone', 699.99, 50, GETDATE(), 1, 2),
('T-shirt', 'Cotton t-shirt', 19.99, 100, GETDATE(), 2, 3),
('Washing Machine', 'High-efficiency washing machine', 499.99, 30, GETDATE(), 3, 3),
('Fiction Book', 'Bestselling novel', 14.99, 200, GETDATE(), 4, 2);

-- Insertar pedidos
INSERT INTO Pedidos (ClienteId, Estado, Total, FechaPedido) VALUES 
(2, 'Pending', 699.99, GETDATE()),
(3, 'Shipped', 19.99, GETDATE());

-- Insertar detalles de pedidos
INSERT INTO DetallesPedidos (PedidoId, ProductoId, Cantidad, PrecioUnitario) VALUES 
(1, 1, 1, 699.99),
(2, 2, 1, 19.99);

-- Insertar imágenes de productos
INSERT INTO ImagenProducto (UrlImagen, ProductoId) VALUES 
('https://example.com/smartphone.jpg', 1),
('https://example.com/tshirt.jpg', 2);

-- Insertar cupones
INSERT INTO Cupones (ProductoId, PromocionId) VALUES 
(1, 1),
(2, 2);

-- Insertar notificaciones
INSERT INTO Notificaciones (Titulo, Mensaje, FechaEnvio) VALUES 
('New Promotion!', 'Get 10% off on Electronics!', GETDATE());

-- Insertar registros de acciones
INSERT INTO ReporteAcciones (UsuarioId, Descripcion, FechaReporte) VALUES 
(2, 'Purchased a Smartphone', GETDATE());
