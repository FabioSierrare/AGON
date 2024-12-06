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
    RolId INT,  -- Se ha agregado esta columna
    FOREIGN KEY (RolId) REFERENCES Roles(Id)  -- Clave foránea que hace referencia a Roles
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
    FOREIGN KEY (CategoriaId) REFERENCES Categoria(Id),
    FOREIGN KEY (VendedorId) REFERENCES Usuarios(Id)
);

CREATE TABLE Pedidos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    ClienteId INT,
    Estado NVARCHAR(50),
    Total DECIMAL(18,2),
    FechaPedido DATETIME,
    FOREIGN KEY (ClienteId) REFERENCES Usuarios(Id)
);

CREATE TABLE DetallesPedidos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PedidoId INT,
    ProductoId INT,
    Cantidad INT,
    PrecioUnitario DECIMAL(18,2),
    FOREIGN KEY (PedidoId) REFERENCES Pedidos(Id),
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id)
);

CREATE TABLE ImagenProducto (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UrlImagen NVARCHAR(255),
    ProductoId INT,
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id)
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
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id),
    FOREIGN KEY (PromocionId) REFERENCES Promociones(Id)
);

CREATE TABLE Comentarios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioId INT,
    ProductoId INT,
    ComentarioTexto NVARCHAR(500),
    FechaComentario DATETIME,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id),
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id)
);

CREATE TABLE Valoraciones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioId INT,
    ProductoId INT,
    Valor INT,
    FechaValoracion DATETIME,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id),
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id)
);

CREATE TABLE Envios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    PedidoId INT,
    EmpresaEnvio NVARCHAR(100),
    NumeroGuia NVARCHAR(100),
    EstadoEnvio NVARCHAR(50),
    FechaEnvio DATETIME,
    FechaEntrega DATETIME,
    FOREIGN KEY (PedidoId) REFERENCES Pedidos(Id)
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
    FOREIGN KEY (EnvioId) REFERENCES Envios(Id)
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
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id),
    FOREIGN KEY (NotificacionId) REFERENCES Notificaciones(Id)
);

CREATE TABLE Permisos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100)
);

CREATE TABLE RolesPermisos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    RolId INT,
    PermisoId INT,
    FOREIGN KEY (RolId) REFERENCES Roles(Id),
    FOREIGN KEY (PermisoId) REFERENCES Permisos(Id)
);

CREATE TABLE TicketsSoporte (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioId INT,
    Titulo NVARCHAR(100),
    Descripcion NVARCHAR(500),
    Estado NVARCHAR(50),
    FechaCreacion DATETIME,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
);

CREATE TABLE Tokens (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioId INT,
    TokenValue NVARCHAR(255),
    Expira DATETIME,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
);

CREATE TABLE ReporteAcciones (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UsuarioId INT,
    Descripcion NVARCHAR(500),
    FechaReporte DATETIME,
    FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id)
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
    FOREIGN KEY (ProductoId) REFERENCES Productos(Id)
);

INSERT INTO Roles (Nombre) VALUES 
('Administrador'),
('Cliente'),
('Vendedor');

-- Insertar datos en Usuarios
INSERT INTO Usuarios (Nombre, Correo, Contraseña, Telefono, Direccion, TipoUsuario, FechaCreacion, RolId) VALUES 
('Juan Pérez', 'juan@example.com', '1234', '1234567890', 'Calle 1', 'Cliente', GETDATE(), 2),
('Carlos Gómez', 'carlos@example.com', 'abcd', '0987654321', 'Calle 2', 'Vendedor', GETDATE(), 3),
('Ana Martínez', 'ana@example.com', 'abcd1234', '1122334455', 'Calle 3', 'Administrador', GETDATE(), 1);

-- Insertar datos en Categoria
INSERT INTO Categoria (Nombre) VALUES 
('Electrónica'),
('Ropa'),
('Hogar');

-- Insertar datos en Productos
INSERT INTO Productos (Nombre, Descripcion, Precio, Stock, FechaCreacion, CategoriaId, VendedorId) VALUES 
('Televisor', 'Televisor de 42 pulgadas', 500.00, 10, GETDATE(), 1, 2),
('Camisa', 'Camisa de algodón', 25.00, 50, GETDATE(), 2, 3),
('Sofá', 'Sofá de tres plazas', 300.00, 5, GETDATE(), 3, 2);

-- Insertar datos en Pedidos
INSERT INTO Pedidos (ClienteId, Estado, Total, FechaPedido) VALUES 
(1, 'Pendiente', 525.00, GETDATE()),
(2, 'Enviado', 350.00, GETDATE()),
(3, 'Entregado', 100.00, GETDATE());

-- Insertar datos en DetallesPedidos
INSERT INTO DetallesPedidos (PedidoId, ProductoId, Cantidad, PrecioUnitario) VALUES 
(1, 1, 1, 500.00),
(2, 2, 2, 25.00),
(3, 3, 1, 100.00);

-- Insertar datos en Promociones
INSERT INTO Promociones (Nombre, Descuento, FechaInicio, FechaFin) VALUES 
('Descuento Verano', 10.00, GETDATE(), GETDATE() + 30),
('Oferta Black Friday', 20.00, GETDATE(), GETDATE() + 15),
('Cyber Monday', 15.00, GETDATE(), GETDATE() + 7);

-- Insertar datos en Comentarios
INSERT INTO Comentarios (UsuarioId, ProductoId, ComentarioTexto, FechaComentario) VALUES 
(1, 1, 'Excelente calidad de imagen.', GETDATE()),
(2, 2, 'Muy cómoda y a buen precio.', GETDATE()),
(3, 3, 'Muy buen sofá, excelente para mi sala.', GETDATE());

-- Insertar datos en Valoraciones
INSERT INTO Valoraciones (UsuarioId, ProductoId, Valor, FechaValoracion) VALUES 
(1, 1, 5, GETDATE()),
(2, 2, 4, GETDATE()),
(3, 3, 5, GETDATE());