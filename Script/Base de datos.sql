-- Crear la base de datos
CREATE DATABASE Ecommerce;
GO

-- Usar la base de datos recién creada
USE Ecommerce;
GO

-- Crear las tablas
-- ============================================
-- MICROSERVICIO DE USUARIOS
-- ============================================
CREATE TABLE Usuarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(400) NOT NULL,
    Correo NVARCHAR(300) NOT NULL UNIQUE,
    Contraseña NVARCHAR(255) NOT NULL,
    TipoDocumento NVARCHAR(10),
    Documento NVARCHAR(50),
    Telefono NVARCHAR(15),
    Direccion NVARCHAR(300),
    FechaCreacion DATETIME DEFAULT GETDATE(),
    TipoUsuario NVARCHAR(50) NOT NULL
);

-- ============================================
-- MICROSERVICIO DE PRODUCTOS
-- ============================================
CREATE TABLE Categorias (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL
);

CREATE TABLE Productos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Descripcion NVARCHAR(500),
    Precio DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    CategoriaId INT FOREIGN KEY REFERENCES Categorias(Id) ON DELETE CASCADE,
    VendedorId INT FOREIGN KEY REFERENCES Usuarios(Id),
    UrlImagen NVARCHAR(500) NOT NULL
);

-- ============================================
-- MICROSERVICIO DE PEDIDOS
-- ============================================
CREATE TABLE Pedidos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ClienteId INT FOREIGN KEY REFERENCES Usuarios(Id) ON DELETE CASCADE,
    Estado NVARCHAR(50) NOT NULL,
    Total DECIMAL(10,2) NOT NULL,
    FechaPedido DATETIME DEFAULT GETDATE(),
    ProductoId INT FOREIGN KEY REFERENCES Productos(Id),
    VendedorId INT FOREIGN KEY REFERENCES Usuarios(Id),
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL
);

-- ============================================
-- MICROSERVICIO DE INVENTARIOS
-- ============================================
CREATE TABLE Inventarios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ProductoId INT FOREIGN KEY REFERENCES Productos(Id) ON DELETE CASCADE,
    Cantidad INT NOT NULL,
    UltimaActualizacion DATETIME DEFAULT GETDATE()
);

-- ============================================
-- MICROSERVICIO DE RESEÑAS
-- ============================================
CREATE TABLE Reseñas (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UsuarioId INT FOREIGN KEY REFERENCES Usuarios(Id),
    ProductoId INT FOREIGN KEY REFERENCES Productos(Id) ON DELETE CASCADE,
    Comentario NVARCHAR(1000),
    Valoracion INT CHECK (Valoracion BETWEEN 1 AND 5),
    Fecha DATETIME DEFAULT GETDATE()
);

-- ============================================
-- MICROSERVICIO DE NOTIFICACIONES
-- ============================================
CREATE TABLE Notificaciones (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UsuarioId INT FOREIGN KEY REFERENCES Usuarios(Id) ON DELETE CASCADE,
    Titulo NVARCHAR(100) NOT NULL,
    Mensaje NVARCHAR(1000),
    Leido BIT DEFAULT 0,
    FechaEnvio DATETIME DEFAULT GETDATE()
);

-- ============================================
-- MICROSERVICIO DE PAGOS
-- ============================================
CREATE TABLE Pagos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    PedidoId INT FOREIGN KEY REFERENCES Pedidos(Id) ON DELETE CASCADE,
    Monto DECIMAL(10,2) NOT NULL,
    MetodoPago NVARCHAR(50) NOT NULL,
    CodigoTransaccion NVARCHAR(100) NOT NULL,
    EstadoTransaccion NVARCHAR(50) NOT NULL,
    FechaPago DATETIME DEFAULT GETDATE()
);

-- ============================================
-- MICROSERVICIO DE DESCUENTOS
-- ============================================
CREATE TABLE Descuentos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Tipo NVARCHAR(50),
    Nombre NVARCHAR(100),
    Codigo NVARCHAR(50) UNIQUE,
    Descuento DECIMAL(5,2),
    FechaInicio DATETIME DEFAULT GETDATE(),
    FechaFin DATETIME
);

CREATE TABLE ProductosDescuento (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ProductoId INT FOREIGN KEY REFERENCES Productos(Id),
    DescuentoId INT FOREIGN KEY REFERENCES Descuentos(Id) ON DELETE CASCADE
);

-- ============================================
-- MICROSERVICIO DE SOPORTE
-- ============================================
CREATE TABLE Soporte (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UsuarioId INT FOREIGN KEY REFERENCES Usuarios(Id) ON DELETE CASCADE,
    Tipo NVARCHAR(50),
    Titulo NVARCHAR(100),
    Descripcion NVARCHAR(1000),
    Estado NVARCHAR(50),
    FechaCreacion DATETIME DEFAULT GETDATE()
);

-- ============================================
-- MICROSERVICIO DE AUDITORÍA Y LOGS
-- ============================================
CREATE TABLE Logs (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UsuarioId INT FOREIGN KEY REFERENCES Usuarios(Id) ON DELETE CASCADE,
    Tipo NVARCHAR(50),
    Mensaje NVARCHAR(1000),
    Fecha DATETIME DEFAULT GETDATE()
);

-- ============================================
-- MICROSERVICIO DE ENVÍOS
-- ============================================
CREATE TABLE Envios (
    Id INT PRIMARY KEY IDENTITY(1,1),
    PedidoId INT FOREIGN KEY REFERENCES Pedidos(Id) ON DELETE CASCADE,
    Empresa NVARCHAR(100),
    NumeroGuia NVARCHAR(50),
    EstadoEnvio NVARCHAR(50),
    FechaEnvio DATETIME DEFAULT GETDATE(),
    FechaEntrega DATETIME,
    Ubicacion NVARCHAR(255)
);

-- ============================================
-- MICROSERVICIO DE INTEGRACIÓN CON REDES SOCIALES
-- ============================================
CREATE TABLE AutenticacionesSociales (
    Id INT PRIMARY KEY IDENTITY(1,1),
    UsuarioId INT FOREIGN KEY REFERENCES Usuarios(Id) ON DELETE CASCADE,
    Proveedor NVARCHAR(50),
    IdProveedor NVARCHAR(100),
    FechaAutenticacion DATETIME DEFAULT GETDATE()
);


-- Insertar datos en la tabla Usuarios
INSERT INTO Usuarios (Nombre, Correo, Contraseña, TipoDocumento, Documento, Telefono, Direccion, TipoUsuario)
VALUES
('Juan Pérez', 'juan.perez@example.com', 'password1', 'CC', '123456789', '3101234567', 'Calle 1 # 1-1', 'Cliente'),
('María López', 'maria.lopez@example.com', 'password2', 'CC', '987654321', '3117654321', 'Calle 2 # 2-2', 'Vendedor'),
('Pedro Gómez', 'pedro.gomez@example.com', 'password3', 'CC', '456789123', '3123456789', 'Calle 3 # 3-3', 'Administrador');

-- Insertar datos en la tabla Categorias
INSERT INTO Categorias (Nombre)
VALUES
('Electrónica'),
('Ropa'),
('Hogar');

-- Insertar datos en la tabla Productos
INSERT INTO Productos (Nombre, Descripcion, Precio, Stock, CategoriaId, VendedorId, UrlImagen)
VALUES
('Laptop', 'Laptop de alta gama', 1500.00, 10, 1, 2, 'http://example.com/laptop.jpg'),
('Camiseta', 'Camiseta de algodón', 20.00, 50, 2, 2, 'http://example.com/camiseta.jpg'),
('Silla', 'Silla ergonómica', 100.00, 20, 3, 2, 'http://example.com/silla.jpg');

-- Insertar datos en la tabla Pedidos
INSERT INTO Pedidos (ClienteId, Estado, Total, ProductoId, VendedorId, Cantidad, PrecioUnitario)
VALUES
(1, 'En proceso', 1500.00, 1, 2, 1, 1500.00),
(1, 'En proceso', 40.00, 2, 2, 2, 20.00),
(1, 'En proceso', 100.00, 3, 2, 1, 100.00);

-- Insertar datos en la tabla Inventarios
INSERT INTO Inventarios (ProductoId, Cantidad)
VALUES
(1, 10),
(2, 50),
(3, 20);

-- Insertar datos en la tabla Reseñas
INSERT INTO Reseñas (UsuarioId, ProductoId, Comentario, Valoracion)
VALUES
(1, 1, 'Excelente producto', 5),
(1, 2, 'Buena calidad', 4),
(1, 3, 'Muy cómoda', 5);

-- Insertar datos en la tabla Notificaciones
INSERT INTO Notificaciones (UsuarioId, Titulo, Mensaje)
VALUES
(1, 'Oferta especial', '¡Aprovecha nuestras ofertas!'),
(2, 'Nuevo pedido', 'Tienes un nuevo pedido pendiente'),
(3, 'Actualización', 'Hemos actualizado nuestras políticas');

-- Insertar datos en la tabla Pagos
INSERT INTO Pagos (PedidoId, Monto, MetodoPago, CodigoTransaccion, EstadoTransaccion)
VALUES
(1, 1500.00, 'Tarjeta de crédito', 'TXN123', 'Completado'),
(2, 40.00, 'PayPal', 'TXN456', 'Completado'),
(3, 100.00, 'Tarjeta de crédito', 'TXN789', 'Completado');

-- Insertar datos en la tabla Descuentos
INSERT INTO Descuentos (Tipo, Nombre, Codigo, Descuento, FechaInicio, FechaFin)
VALUES
('Porcentaje', 'Descuento 10%', 'DESC10', 10.00, '2023-01-01', '2023-12-31'),
('Porcentaje', 'Descuento 20%', 'DESC20', 20.00, '2023-01-01', '2023-12-31'),
('Porcentaje', 'Descuento 30%', 'DESC30', 30.00, '2023-01-01', '2023-12-31');

-- Insertar datos en la tabla ProductosDescuento
INSERT INTO ProductosDescuento (ProductoId, DescuentoId)
VALUES
(1, 1),
(2, 2),
(3, 3);

-- Insertar datos en la tabla Soporte
INSERT INTO Soporte (UsuarioId, Tipo, Titulo, Descripcion, Estado)
VALUES
(1, 'Consulta', 'Problema con pedido', 'No he recibido mi pedido', 'Abierto'),
(2, 'Reclamo', 'Producto defectuoso', 'El producto llegó dañado', 'Abierto'),
(3, 'Sugerencia', 'Mejora en la web', 'Sería bueno mejorar la navegación', 'Abierto');

-- Insertar datos en la tabla Logs
INSERT INTO Logs (UsuarioId, Tipo, Mensaje)
VALUES
(1, 'Inicio de sesión', 'El usuario ha iniciado sesión'),
(2, 'Creación de producto', 'Se ha creado un nuevo producto'),
(3, 'Actualización de perfil', 'El usuario ha actualizado su perfil');

-- Insertar datos en la tabla Envios
INSERT INTO Envios (PedidoId, Empresa, NumeroGuia, EstadoEnvio, FechaEntrega, Ubicacion)
VALUES
(1, 'DHL', 'GUIDE123', 'En tránsito', '2023-12-01', 'Calle 1 # 1-1'),
(2, 'FedEx', 'GUIDE456', 'En tránsito', '2023-12-02', 'Calle 2 # 2-2'),
(3, 'UPS', 'GUIDE789', 'En tránsito', '2023-12-03', 'Calle 3 # 3-3');

-- Insertar datos en la tabla AutenticacionesSociales
INSERT INTO AutenticacionesSociales (UsuarioId, Proveedor, IdProveedor)
VALUES
(1, 'Google', 'GOOGLE123'),
(2, 'Facebook', 'FACEBOOK456'),
(3, 'Twitter', 'TWITTER789');

SELECT * FROM Descuentos

ALTER TABLE Descuentos 
ADD VendedorId INT FOREIGN KEY REFERENCES Usuarios(Id) ON DELETE CASCADE;

UPDATE Descuentos 
SET VendedorId = 2 
WHERE VendedorId IS NULL;
