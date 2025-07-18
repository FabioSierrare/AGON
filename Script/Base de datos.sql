-- ============================================
-- 1) CREACIÓN DE BASE DE DATOS Y SELECCIÓN DE CONTEXTO
-- ============================================
CREATE DATABASE Ecommerce;
GO

USE Ecommerce;
GO

-- ============================================
-- 2) TABLAS “PADRE” (sin dependencias hacia otras tablas)
-- ============================================
CREATE TABLE TipoUsuarios (
    Id     INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(50) NOT NULL UNIQUE
);
GO

CREATE TABLE Usuarios (
    Id                 INT PRIMARY KEY IDENTITY(1,1),
    Nombre             NVARCHAR(400) NOT NULL,
    Correo             NVARCHAR(300) NOT NULL UNIQUE,
    Contraseña         NVARCHAR(255) NOT NULL,
    TipoDocumento      NVARCHAR(10),
    Documento          NVARCHAR(50),
    Telefono           NVARCHAR(15),
    Direccion          NVARCHAR(300),
    FechaCreacion      DATETIME DEFAULT GETDATE(),
    TipoUsuarioId      INT NOT NULL,
    CodigoVerificacion NVARCHAR(100),
    CodigoExpira       DATETIME,
    CodigoRecuperacion NVARCHAR(100),
    CONSTRAINT FK_Usuarios_TipoUsuarios 
      FOREIGN KEY (TipoUsuarioId) REFERENCES TipoUsuarios(Id)
);
GO

CREATE TABLE Categorias (
    Id     INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL
);
GO

-- ============================================
-- 3) TABLAS CON DEPENDENCIAS DIRECTAS
-- ============================================
CREATE TABLE Productos (
    Id            INT PRIMARY KEY IDENTITY(1,1),
    Nombre        NVARCHAR(100) NOT NULL,
    Descripcion   NVARCHAR(500),
    Precio        DECIMAL(10,2) NOT NULL,
    Stock         INT NOT NULL,
    FechaCreacion DATETIME DEFAULT GETDATE(),
    CategoriaId   INT,
    VendedorId    INT,
    UrlImagen     NVARCHAR(500) NOT NULL,
    CONSTRAINT FK_Productos_Categoria 
      FOREIGN KEY (CategoriaId) REFERENCES Categorias(Id) ON DELETE CASCADE,
    CONSTRAINT FK_Productos_Vendedor 
      FOREIGN KEY (VendedorId)   REFERENCES Usuarios(Id)     ON DELETE CASCADE
);
GO
CREATE TABLE Pedidos (
    Id INT PRIMARY KEY IDENTITY(1,1),
    ClienteId INT,
    Estado NVARCHAR(50) NOT NULL,
    Total DECIMAL(10,2) NOT NULL,
    FechaPedido DATETIME DEFAULT GETDATE(),
    ProductoId INT FOREIGN KEY REFERENCES Productos(Id) ON DELETE CASCADE,
    VendedorId INT,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    MetodoPago NVARCHAR(50), -- Campo agregado
    FOREIGN KEY (ClienteId) REFERENCES Usuarios(Id) ON DELETE NO ACTION,
    FOREIGN KEY (VendedorId) REFERENCES Usuarios(Id) ON DELETE NO ACTION
);
GO

CREATE TABLE Comentarios (
    Id              INT PRIMARY KEY IDENTITY(1,1),
    UsuarioId       INT NOT NULL,
    ProductoId      INT NOT NULL,
    ComentarioTexto NVARCHAR(1000) NOT NULL,
    FechaComentario DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Comentarios_Usuarios  
      FOREIGN KEY (UsuarioId)   REFERENCES Usuarios(Id)   ON DELETE NO ACTION,
    CONSTRAINT FK_Comentarios_Productos
      FOREIGN KEY (ProductoId) REFERENCES Productos(Id) ON DELETE NO ACTION
);
GO

-- ============================================
-- 4) TABLAS AUXILIARES
-- ============================================
CREATE TABLE ImgPerfil (
    Id        INT PRIMARY KEY IDENTITY(1,1),
    IdUsuario INT NOT NULL UNIQUE,
    URLImg    NVARCHAR(200),
    CONSTRAINT FK_ImgPerfil_Usuarios 
      FOREIGN KEY (IdUsuario) REFERENCES Usuarios(Id) ON DELETE NO ACTION
);
GO

CREATE TABLE Inventarios (
    Id                  INT PRIMARY KEY IDENTITY(1,1),
    ProductoId          INT,
    Cantidad            INT NOT NULL,
    UltimaActualizacion DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Inventarios_Productos 
      FOREIGN KEY (ProductoId) REFERENCES Productos(Id) ON DELETE NO ACTION
);
GO

CREATE TABLE Notificaciones (
    Id         INT PRIMARY KEY IDENTITY(1,1),
    UsuarioId  INT,
    Titulo     NVARCHAR(100) NOT NULL,
    Mensaje    NVARCHAR(1000),
    Leido      BIT DEFAULT 0,
    FechaEnvio DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Notificaciones_Usuarios 
      FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE NO ACTION
);
GO

CREATE TABLE Pagos (
    Id                INT PRIMARY KEY IDENTITY(1,1),
    PedidoId          INT,
    Monto             DECIMAL(10,2) NOT NULL,
    MetodoPago        NVARCHAR(50) NOT NULL,
    CodigoTransaccion NVARCHAR(100) NOT NULL,
    EstadoTransaccion NVARCHAR(50) NOT NULL,
    FechaPago         DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Pagos_Pedidos 
      FOREIGN KEY (PedidoId) REFERENCES Pedidos(Id) ON DELETE CASCADE
);
GO

CREATE TABLE Descuentos (
    Id          INT PRIMARY KEY IDENTITY(1,1),
    Tipo        NVARCHAR(50),
    Nombre      NVARCHAR(100),
    Codigo      NVARCHAR(50) UNIQUE,
    Descuento   DECIMAL(5,2),
    FechaInicio DATETIME DEFAULT GETDATE(),
    FechaFin    DATETIME,
    VendedorId  INT,
    CONSTRAINT FK_Descuentos_Usuarios 
      FOREIGN KEY (VendedorId) REFERENCES Usuarios(Id) ON DELETE NO ACTION
);
GO

CREATE TABLE ProductosDescuento (
    Id          INT PRIMARY KEY IDENTITY(1,1),
    ProductoId  INT,
    DescuentoId INT,
    CONSTRAINT FK_PD_Productos  
      FOREIGN KEY (ProductoId)  REFERENCES Productos(Id)   ON DELETE NO ACTION,
    CONSTRAINT FK_PD_Descuentos 
      FOREIGN KEY (DescuentoId) REFERENCES Descuentos(Id) ON DELETE NO ACTION
);
GO

CREATE TABLE TicketsSoporte (
    Id            INT PRIMARY KEY IDENTITY(1,1),
    UsuarioId     INT,
    Tipo          NVARCHAR(50),
    Titulo        NVARCHAR(100),
    Descripcion   NVARCHAR(1000),
    Estado        NVARCHAR(50),
    FechaCreacion DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Tickets_Usuarios 
      FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE NO ACTION
);
GO

CREATE TABLE Logs (
    Id        INT PRIMARY KEY IDENTITY(1,1),
    UsuarioId INT,
    Tipo      NVARCHAR(50),
    Mensaje   NVARCHAR(1000),
    Fecha     DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_Logs_Usuarios 
      FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE NO ACTION
);
GO

CREATE TABLE Envios (
    Id           INT PRIMARY KEY IDENTITY(1,1),
    PedidoId     INT,
    Empresa      NVARCHAR(100),
    NumeroGuia   NVARCHAR(50),
    EstadoEnvio  NVARCHAR(50),
    FechaEnvio   DATETIME DEFAULT GETDATE(),
    FechaEntrega DATETIME,
    Ubicacion    NVARCHAR(255),
    CONSTRAINT FK_Envios_Pedidos 
      FOREIGN KEY (PedidoId) REFERENCES Pedidos(Id) ON DELETE NO ACTION
);
GO

CREATE TABLE AutenticacionesSociales (
    Id                 INT PRIMARY KEY IDENTITY(1,1),
    UsuarioId          INT,
    Proveedor          NVARCHAR(50),
    IdProveedor        NVARCHAR(100),
    FechaAutenticacion DATETIME DEFAULT GETDATE(),
    CONSTRAINT FK_AuthSocial_Usuarios 
      FOREIGN KEY (UsuarioId) REFERENCES Usuarios(Id) ON DELETE NO ACTION
);
GO

CREATE TABLE RespuestasFAQ (
    Id        INT PRIMARY KEY IDENTITY(1,1),
    Pregunta  NVARCHAR(50),
    Respuesta NVARCHAR(50)
);
GO

USE Ecommerce;
GO

-- 1) Asegúrate de quitar cualquier trigger previo
IF OBJECT_ID('dbo.trg_DeleteUsuario_CascadeAll', 'TR') IS NOT NULL
    DROP TRIGGER dbo.trg_DeleteUsuario_CascadeAll;
GO

-- 2) Creamos el trigger definitivo
-- 1) Eliminar trigger si ya existe
IF OBJECT_ID('dbo.trg_DeleteUsuario_CascadeAll', 'TR') IS NOT NULL
    DROP TRIGGER dbo.trg_DeleteUsuario_CascadeAll;
GO

-- 2) Crear trigger actualizado
CREATE TRIGGER trg_DeleteUsuario_CascadeAll
ON Usuarios
INSTEAD OF DELETE
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @DeletedIds TABLE (Id INT PRIMARY KEY);
    INSERT INTO @DeletedIds(Id)
    SELECT Id FROM deleted;

    -- A) Envios
    DELETE e
      FROM Envios e
      JOIN Pedidos p ON e.PedidoId = p.Id
      WHERE p.ClienteId IN (SELECT Id FROM @DeletedIds)
         OR p.VendedorId IN (SELECT Id FROM @DeletedIds);

    -- B) ProductosDescuento de los Productos del usuario
    DELETE pd
      FROM ProductosDescuento pd
      WHERE pd.ProductoId IN (
          SELECT pr.Id
          FROM Productos pr
          WHERE pr.VendedorId IN (SELECT Id FROM @DeletedIds)
      );

    -- C) ProductosDescuento de los Descuentos del usuario
    DELETE pd
      FROM ProductosDescuento pd
      WHERE pd.DescuentoId IN (
          SELECT d.Id
          FROM Descuentos d
          WHERE d.VendedorId IN (SELECT Id FROM @DeletedIds)
      );

    -- D) Descuentos del usuario
    DELETE d
      FROM Descuentos d
      WHERE d.VendedorId IN (SELECT Id FROM @DeletedIds);

    -- E) Inventarios de los Productos del usuario
    DELETE inv
      FROM Inventarios inv
      WHERE inv.ProductoId IN (
          SELECT pr.Id
          FROM Productos pr
          WHERE pr.VendedorId IN (SELECT Id FROM @DeletedIds)
      );

    -- ⚠️ SECCIÓN F eliminada (DetallePedidos ya no existe)

    -- G) Comentarios hechos por el usuario
    DELETE c
      FROM Comentarios c
      WHERE c.UsuarioId IN (SELECT Id FROM @DeletedIds);

    -- H) Comentarios sobre Productos del usuario
    DELETE c
      FROM Comentarios c
      WHERE c.ProductoId IN (
          SELECT pr.Id
          FROM Productos pr
          WHERE pr.VendedorId IN (SELECT Id FROM @DeletedIds)
      );

    -- I) Productos del usuario
    DELETE pr
      FROM Productos pr
      WHERE pr.VendedorId IN (SELECT Id FROM @DeletedIds);

    -- J) Pedidos del usuario (cascade en Pagos y Envios)
    DELETE p
      FROM Pedidos p
      WHERE p.ClienteId IN (SELECT Id FROM @DeletedIds)
         OR p.VendedorId IN (SELECT Id FROM @DeletedIds);

    -- K) Tablas auxiliares directamente relacionadas al usuario
    DELETE i  FROM ImgPerfil i   JOIN @DeletedIds u ON i.IdUsuario  = u.Id;
    DELETE n  FROM Notificaciones n JOIN @DeletedIds u ON n.UsuarioId = u.Id;
    DELETE ts FROM TicketsSoporte ts JOIN @DeletedIds u ON ts.UsuarioId = u.Id;
    DELETE l  FROM Logs l         JOIN @DeletedIds u ON l.UsuarioId = u.Id;
    DELETE ps FROM AutenticacionesSociales ps JOIN @DeletedIds u ON ps.UsuarioId = u.Id;

    -- L) Finalmente, eliminar el usuario
    DELETE u
      FROM Usuarios u
      JOIN @DeletedIds d ON u.Id = d.Id;
END;
GO



INSERT INTO TipoUsuarios (Nombre) VALUES ('Cliente'), ('Vendedor'), ('Administrador');
GO

-- ============================================
-- Insertar en tabla Usuarios
-- ============================================
INSERT INTO Usuarios (Nombre, Correo, Contraseña, TipoDocumento, Documento, Telefono, Direccion, TipoUsuarioId)
VALUES
('Juan Pérez', 'juan.perez@example.com', 'password1', 'CC', '123456789', '3101234567', 'Calle 1 # 1-1', '1'),
('María López', 'maria.lopez@example.com', 'password2', 'CC', '987654321', '3117654321', 'Calle 2 # 2-2', '2'),
('Pedro Gómez', 'pedro.gomez@example.com', 'password3', 'CC', '456789123', '3123456789', 'Calle 3 # 3-3', '3');

-- ============================================
-- Insertar en tabla Categorias
-- ============================================
INSERT INTO Categorias (Nombre)
VALUES
('Verduras'),
('Frutas'),
('Tuberculos'),
('Cereales'),
('Granja');

-- ============================================
-- Insertar en tabla Productos
-- ============================================

INSERT INTO Productos (Nombre, Descripcion, Precio, Stock, FechaCreacion, CategoriaId, VendedorId, UrlImagen)
VALUES
('Tractocultor Compacto', 'Ideal para pequeñas parcelas y labores de arado ligero', 4500.0, 5, GETDATE(), 5, 2, 'https://agonsenita.blob.core.windows.net/imagenesproductos/Tractor Compacto.PNG'),
('Semillas de Maíz Híbrido', 'Alta productividad y resistencia a plagas', 120.0, 100, GETDATE(), 4, 2, 'https://agonsenita.blob.core.windows.net/imagenesproductos/Semillas Maiz.PNG'),
('Fumigadora de Mochila', 'Para aplicar pesticidas o fertilizantes líquidos', 75.0, 30, GETDATE(), 5, 2, 'https://agonsenita.blob.core.windows.net/imagenesproductos/Fumigadora.PNG'),
('Fertilizante Orgánico 50kg', 'Compost certificado, 100% natural', 35.0, 60, GETDATE(), 5, 2, 'https://agonsenita.blob.core.windows.net/imagenesproductos/Fertilizante.PNG'),
('Arado de Disco', 'Para preparación profunda del suelo', 650.0, 10, GETDATE(), 5, 2, 'https://agonsenita.blob.core.windows.net/imagenesproductos/Arado.PNG'),
('Motocultivador a Gasolina', 'Para labranza de terrenos medianos', 850.0, 6, GETDATE(), 5, 2, 'https://agonsenita.blob.core.windows.net/imagenesproductos/Motocultivador.PNG'),
('Manguera Agrícola 50m', 'Resistente al sol y presión, ideal para riego', 25.0, 40, GETDATE(), 5, 2, 'https://agonsenita.blob.core.windows.net/imagenesproductos/maguera.PNG'),
('Carretilla de Acero', 'Reforzada para transporte de cargas pesadas', 90.0, 20, GETDATE(), 5, 2, 'https://agonsenita.blob.core.windows.net/imagenesproductos/Caretilla.PNG'),
('Pala Punta Cuadrada', 'Herramienta de mano para excavación', 18.0, 35, GETDATE(), 5, 2, 'https://agonsenita.blob.core.windows.net/imagenesproductos/Pala.PNG'),
('Insecticida Biológico', 'Control de plagas sin dañar el ecosistema', 22.0, 50, GETDATE(), 5, 2, 'https://agonsenita.blob.core.windows.net/imagenesproductos/Insecticida.PNG'),
('Rastrillo Metálico', 'Para recolección de hojas y desechos', 15.0, 45, GETDATE(), 5, 2, 'https://agonsenita.blob.core.windows.net/imagenesproductos/rastrillo.PNG'),
('Guantes de Jardinería', 'Antideslizantes y resistentes al agua', 5.0, 80, GETDATE(), 5, 2, 'https://agonsenita.blob.core.windows.net/imagenesproductos/Guantes.PNG'),
('Regadera Metálica 10L', 'Clásica, para riego suave de cultivos', 12.0, 30, GETDATE(), 5, 2, 'https://agonsenita.blob.core.windows.net/imagenesproductos/regadera.PNG'),
('Tanque de Agua 500L', 'Plástico reforzado, ideal para sistemas de riego', 200.0, 10, GETDATE(), 5, 2, 'https://agonsenita.blob.core.windows.net/imagenesproductos/tanque.PNG'),
('Kit de Riego por Goteo', 'Para ahorro de agua en cultivos de hortalizas', 60.0, 25, GETDATE(), 5, 2, 'https://agonsenita.blob.core.windows.net/imagenesproductos/KIT.PNG'),
('Pulverizador a Presión', 'Manual, con boquilla ajustable', 30.0, 40, GETDATE(), 5, 2, 'https://agonsenita.blob.core.windows.net/imagenesproductos/Pulverizador.PNG'),
('Semillas de Tomate Cherry', 'Rinde en climas templados y cálidos', 15.0, 70, GETDATE(), 1, 2, 'https://agonsenita.blob.core.windows.net/imagenesproductos/Semillas Tomate.PNG'),
('Compostera Domiciliaria', 'Para producir abono orgánico casero', 85.0, 15, GETDATE(), 5, 2, 'https://agonsenita.blob.core.windows.net/imagenesproductos/Compostera.PNG'),
('Tijera de Podar Profesional', 'Cuchillas templadas para cortes limpios', 22.0, 50, GETDATE(), 5, 2, 'https://agonsenita.blob.core.windows.net/imagenesproductos/Tijera de Podar.PNG'),
('Estacas de Bambú 1.5m', 'Soporte para cultivos verticales', 0.8, 300, GETDATE(), 5, 2, 'https://agonsenita.blob.core.windows.net/imagenesproductos/Estacas bambu.PNG'),
('Saco de Cal Agrícola 25kg', 'Regula el pH del suelo', 12.0, 40, GETDATE(), 5, 2, 'https://agonsenita.blob.core.windows.net/imagenesproductos/Saco de sal.PNG'),
('Red Anti-pájaros 5x10m', 'Protege cultivos frutales', 18.0, 25, GETDATE(), 2, 2, 'https://agonsenita.blob.core.windows.net/imagenesproductos/Red anti pajaros.PNG'),
('Semillas de Lechuga Romana', 'Alta germinación y frescura', 10.0, 90, GETDATE(), 1, 2, 'https://agonsenita.blob.core.windows.net/imagenesproductos/Semillas Lechuga.PNG'),
('Mulch Plástico para Siembra', 'Conserva la humedad y previene malezas', 28.0, 30, GETDATE(), 5, 2, 'https://agonsenita.blob.core.windows.net/imagenesproductos/Muches plasticos.PNG'),
('Malla Sombra 70%', 'Protección solar para viveros', 45.0, 18, GETDATE(), 5, 2, 'https://agonsenita.blob.core.windows.net/imagenesproductos/Malla sombra.PNG'),
('Termómetro de Suelo Digital', 'Ideal para sembrar en condiciones óptimas', 32.0, 12, GETDATE(), 5, 2, 'https://agonsenita.blob.core.windows.net/imagenesproductos/Termometro de suelo.PNG'),
('Detector de Humedad de Suelo', 'Sensor portátil para riego inteligente', 55.0, 10, GETDATE(), 5, 2, 'https://agonsenita.blob.core.windows.net/imagenesproductos/Detector de humedad.PNG'),
('Sustrato para Germinación 25L', 'Mezcla ligera para bandejas de siembra', 14.0, 50, GETDATE(), 5, 2, 'https://agonsenita.blob.core.windows.net/imagenesproductos/Sustrato para germinacion.PNG'),
('Plástico de Invernadero 6x30m', 'Resistente a rayos UV, protección térmica', 110.0, 7, GETDATE(), 5, 2, 'https://agonsenita.blob.core.windows.net/imagenesproductos/Plastico para invernadero.PNG'),
('Riego Temporizado Digital', 'Automatiza el riego según horarios', 65.0, 8, GETDATE(), 5, 2, 'https://agonsenita.blob.core.windows.net/imagenesproductos/Temporizador de Riego.PNG');
-- ============================================
-- Insertar en tabla Pedidos
-- ============================================
INSERT INTO Pedidos (ClienteId, Estado, Total, ProductoId, VendedorId, Cantidad, PrecioUnitario, MetodoPago)
VALUES
(1, 'En proceso', 1500.00, 1, 2, 1, 1500.00, 'Tarjeta de crédito'),
(1, 'En proceso', 40.00,   2, 2, 2, 20.00,    'PayPal'),
(1, 'En proceso', 100.00,  3, 2, 1, 100.00,   'Débito');



-- ============================================
--  Insertar en tabla Comentarios
-- ============================================
INSERT INTO Comentarios (UsuarioId, ProductoId, ComentarioTexto)
VALUES
(1, 1, 'Este producto superó mis expectativas.'),
(2, 2, 'La calidad es buena, pero el tamaño es más pequeño de lo esperado.'),
(3, 3, 'Entrega rápida y producto en excelente estado.');

-- ============================================
-- Insertar en tabla Inventarios
-- ============================================
INSERT INTO Inventarios (ProductoId, Cantidad)
VALUES
(1, 10),
(2, 50),
(3, 20);

-- ============================================
-- Insertar en tabla Notificaciones
-- ============================================
INSERT INTO Notificaciones (UsuarioId, Titulo, Mensaje)
VALUES
(1, 'Oferta especial', '¡Aprovecha nuestras ofertas!'),
(2, 'Nuevo pedido', 'Tienes un nuevo pedido pendiente'),
(3, 'Actualización', 'Hemos actualizado nuestras políticas');

-- ============================================
-- Insertar en tabla Pagos
-- ============================================
INSERT INTO Pagos (PedidoId, Monto, MetodoPago, CodigoTransaccion, EstadoTransaccion)
VALUES
(1, 1500.00, 'Tarjeta de crédito', 'TXN123', 'Completado'),
(1, 40.00, 'PayPal', 'TXN456', 'Completado'),
(1, 100.00, 'Tarjeta de crédito', 'TXN789', 'Completado');

-- ============================================
-- Insertar en tabla Descuentos
-- ============================================
INSERT INTO Descuentos (Tipo, Nombre, Codigo, Descuento, FechaInicio, FechaFin, VendedorId)
VALUES
('Porcentaje', 'Descuento 10%', 'DESC10', 10.00, '2023-01-01', '2023-12-31', 2),
('Porcentaje', 'Descuento 20%', 'DESC20', 20.00, '2023-01-01', '2023-12-31', 2),
('Porcentaje', 'Descuento 30%', 'DESC30', 30.00, '2023-01-01', '2023-12-31', 2);

-- ============================================
-- Insertar en tabla ProductosDescuento
-- ============================================
INSERT INTO ProductosDescuento (ProductoId, DescuentoId)
VALUES
(1, 1),
(2, 2),
(3, 3);

-- ============================================
-- Insertar en tabla Soporte
-- ============================================
INSERT INTO TicketsSoporte (UsuarioId, Tipo, Titulo, Descripcion, Estado)
VALUES
(1, 'Consulta', 'Problema con pedido', 'No he recibido mi pedido', 'Abierto'),
(2, 'Reclamo', 'Producto defectuoso', 'El producto llegó dañado', 'Abierto'),
(3, 'Sugerencia', 'Mejora en la web', 'Sería bueno mejorar la navegación', 'Abierto');

-- ============================================
-- Insertar en tabla Logs
-- ============================================
INSERT INTO Logs (UsuarioId, Tipo, Mensaje)
VALUES
(1, 'Inicio de sesión', 'El usuario ha iniciado sesión'),
(2, 'Creación de producto', 'Se ha creado un nuevo producto'),
(3, 'Actualización de perfil', 'El usuario ha actualizado su perfil');

-- ============================================
-- Insertar en tabla Envios
-- ============================================
INSERT INTO Envios (PedidoId, Empresa, NumeroGuia, EstadoEnvio, FechaEntrega, Ubicacion)
VALUES
(1, 'DHL', 'GUIDE123', 'En tránsito', '2023-12-01', 'Calle 1 # 1-1');

-- ============================================
-- Insertar en tabla AutenticacionesSociales
-- ============================================
INSERT INTO AutenticacionesSociales (UsuarioId, Proveedor, IdProveedor)
VALUES
(1, 'Google', 'GOOGLE123'),
(2, 'Facebook', 'FACEBOOK456'),
(3, 'Twitter', 'TWITTER789');


Select * From Usuarios

-- Actualiza todas las contraseñas de la tabla Usuarios usando SHA256
UPDATE Usuarios
SET Contraseña = LOWER(CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', Contraseña), 2));

SELECT Correo, Contraseña FROM Usuarios WHERE Correo = 'juan.perez@example.com';

UPDATE Usuarios
SET Contraseña = '0b14d501a594442a01c6859541bcb3e8164d183d32937b851835442f69d5c94e'
WHERE Correo = 'juan.perez@example.com';

USE Ecommerce;
GO

-- IMPORTANTE: Convertimos el resultado de HASHBYTES a formato hexadecimal compatible con NVARCHAR
-- Esto funciona bien ya que tu campo `Contraseña` es NVARCHAR(255)

UPDATE Usuarios
SET Contraseña = CONVERT(NVARCHAR(255), 
    CONVERT(VARCHAR(255), HASHBYTES('SHA2_256', 'password1'), 2))
WHERE Correo = 'juan.perez@example.com';

UPDATE Usuarios
SET Contraseña = CONVERT(NVARCHAR(255), 
    CONVERT(VARCHAR(255), HASHBYTES('SHA2_256', 'password2'), 2))
WHERE Correo = 'maria.lopez@example.com';

UPDATE Usuarios
SET Contraseña = CONVERT(NVARCHAR(255), 
    CONVERT(VARCHAR(255), HASHBYTES('SHA2_256', 'password3'), 2))
WHERE Correo = 'pedro.gomez@example.com';

ALTER TABLE Usuarios add CodigoVerificacion NVARCHAR(100) NULL;
ALTER TABLE Usuarios add CodigoExpira DATETIME NULL;

SELECT * FROM Usuarios

ALTER TABLE Usuarios
ADD CodigoRecuperacion NVARCHAR(100) NULL;
