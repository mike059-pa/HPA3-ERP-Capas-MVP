/* =====================================================================
   HPA III - Mini ERP en Capas con MVP (Admin, Vendedor, Cliente)
   Base de datos: SQL Server 2022 Express (.\SQLEXPRESS)
   Ejecutar como administrador (Autenticación de Windows) en SSMS o:
       sqlcmd -S .\SQLEXPRESS -E -i BaseDatos\script.sql
   El script es idempotente: se puede ejecutar varias veces.
   ===================================================================== */

-- sqlcmd usa QUOTED_IDENTIFIER OFF por defecto; los índices filtrados (y los SP que
-- modifican esas tablas) requieren ON, así que se fija para toda la sesión.
SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;
GO

-- 1. Base de datos -----------------------------------------------------
IF DB_ID('ERP_HPA3') IS NULL
    CREATE DATABASE ERP_HPA3;
GO
USE ERP_HPA3;
GO

-- 2. Tablas ------------------------------------------------------------
IF OBJECT_ID('dbo.roles', 'U') IS NULL
CREATE TABLE dbo.roles (
    id      TINYINT      PRIMARY KEY,
    nombre  VARCHAR(30)  NOT NULL UNIQUE
);
GO

-- dsPassword: VARBINARY(64) porque SHA-512 produce 512 bits = 64 bytes
IF OBJECT_ID('dbo.usuarios', 'U') IS NULL
CREATE TABLE dbo.usuarios (
    id                 INT IDENTITY(1,1) PRIMARY KEY,
    dsUsuario          VARCHAR(50)    NOT NULL UNIQUE,
    dsPassword         VARBINARY(64)  NOT NULL,
    dsSalt             VARBINARY(16)  NOT NULL,
    dsNombre           VARCHAR(100)   NOT NULL,
    dsCorreo           VARCHAR(100)   NULL,
    dsTelefono         VARCHAR(20)    NULL,
    idRol              TINYINT        NOT NULL REFERENCES dbo.roles(id),
    dsEstado           BIT            NOT NULL DEFAULT 1,
    dsUsuarioCreacion  VARCHAR(50)    NULL,
    dsFechaCreacion    DATETIME       NOT NULL DEFAULT GETDATE()
);
GO

IF OBJECT_ID('dbo.clientes', 'U') IS NULL
CREATE TABLE dbo.clientes (
    id         INT IDENTITY(1,1) PRIMARY KEY,
    nombre     VARCHAR(100)  NOT NULL,
    cedula     VARCHAR(20)   NULL,
    telefono   VARCHAR(20)   NULL,
    correo     VARCHAR(100)  NULL,
    direccion  VARCHAR(200)  NULL,
    idUsuario  INT           NULL REFERENCES dbo.usuarios(id),
    estado     BIT           NOT NULL DEFAULT 1
);
GO
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'UX_clientes_cedula')
    CREATE UNIQUE INDEX UX_clientes_cedula ON dbo.clientes(cedula) WHERE cedula IS NOT NULL;
IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = 'UX_clientes_idUsuario')
    CREATE UNIQUE INDEX UX_clientes_idUsuario ON dbo.clientes(idUsuario) WHERE idUsuario IS NOT NULL;
GO

IF OBJECT_ID('dbo.productos', 'U') IS NULL
CREATE TABLE dbo.productos (
    id           INT IDENTITY(1,1) PRIMARY KEY,
    codigo       VARCHAR(20)    NOT NULL UNIQUE,
    nombre       VARCHAR(100)   NOT NULL,
    descripcion  VARCHAR(250)   NULL,
    precio       DECIMAL(10,2)  NOT NULL CHECK (precio >= 0),
    stock        INT            NOT NULL CHECK (stock >= 0),
    stockMinimo  INT            NOT NULL DEFAULT 5 CHECK (stockMinimo >= 0),
    estado       BIT            NOT NULL DEFAULT 1
);
GO

IF OBJECT_ID('dbo.ventas', 'U') IS NULL
CREATE TABLE dbo.ventas (
    id          INT IDENTITY(1,1) PRIMARY KEY,
    fecha       DATETIME       NOT NULL DEFAULT GETDATE(),
    idCliente   INT            NOT NULL REFERENCES dbo.clientes(id),
    idVendedor  INT            NULL REFERENCES dbo.usuarios(id),  -- NULL = compra en línea del cliente
    subtotal    DECIMAL(12,2)  NOT NULL,
    itbms       DECIMAL(12,2)  NOT NULL,
    total       DECIMAL(12,2)  NOT NULL
);
GO

IF OBJECT_ID('dbo.detalle_venta', 'U') IS NULL
CREATE TABLE dbo.detalle_venta (
    id              INT IDENTITY(1,1) PRIMARY KEY,
    idVenta         INT            NOT NULL REFERENCES dbo.ventas(id),
    idProducto      INT            NOT NULL REFERENCES dbo.productos(id),
    cantidad        INT            NOT NULL CHECK (cantidad > 0),
    precioUnitario  DECIMAL(10,2)  NOT NULL,
    subtotal        DECIMAL(12,2)  NOT NULL
);
GO

-- Tipo tabla para enviar el carrito completo en una sola llamada
IF TYPE_ID('dbo.DetalleVentaTipo') IS NULL
    CREATE TYPE dbo.DetalleVentaTipo AS TABLE (
        idProducto  INT NOT NULL,
        cantidad    INT NOT NULL
    );
GO

-- 3. Procedimientos: USUARIOS -----------------------------------------
CREATE OR ALTER PROCEDURE dbo.sp_ObtenerUsuario
    @dsUsuario VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT u.id, u.dsUsuario, u.dsPassword, u.dsSalt, u.dsNombre, u.dsCorreo, u.dsTelefono,
           u.idRol, u.dsEstado, u.dsUsuarioCreacion, u.dsFechaCreacion, c.id AS idCliente
    FROM dbo.usuarios u
    LEFT JOIN dbo.clientes c ON c.idUsuario = u.id
    WHERE u.dsUsuario = @dsUsuario;
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_ListarUsuarios
    @buscar VARCHAR(100) = ''
AS
BEGIN
    SET NOCOUNT ON;
    -- Nunca devuelve hash ni salt
    SELECT u.id, u.dsUsuario, u.dsNombre, u.dsCorreo, u.dsTelefono, u.idRol, r.nombre AS rol,
           u.dsEstado, u.dsUsuarioCreacion, u.dsFechaCreacion
    FROM dbo.usuarios u
    INNER JOIN dbo.roles r ON r.id = u.idRol
    WHERE @buscar = '' OR u.dsUsuario LIKE '%' + @buscar + '%' OR u.dsNombre LIKE '%' + @buscar + '%'
    ORDER BY u.id;
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_InsertarUsuario
    @dsUsuario          VARCHAR(50),
    @dsPassword         VARBINARY(64),
    @dsSalt             VARBINARY(16),
    @dsNombre           VARCHAR(100),
    @dsCorreo           VARCHAR(100),
    @dsTelefono         VARCHAR(20),
    @idRol              TINYINT,
    @dsEstado           BIT,
    @dsUsuarioCreacion  VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    IF EXISTS (SELECT 1 FROM dbo.usuarios WHERE dsUsuario = @dsUsuario)
        THROW 50001, 'El nombre de usuario ya existe.', 1;

    BEGIN TRAN;
        INSERT INTO dbo.usuarios (dsUsuario, dsPassword, dsSalt, dsNombre, dsCorreo, dsTelefono,
                                  idRol, dsEstado, dsUsuarioCreacion)
        VALUES (@dsUsuario, @dsPassword, @dsSalt, @dsNombre, @dsCorreo, @dsTelefono,
                @idRol, @dsEstado, @dsUsuarioCreacion);
        DECLARE @id INT = SCOPE_IDENTITY();

        -- Un usuario con rol Cliente necesita su ficha de cliente para poder comprar
        IF @idRol = 3
            INSERT INTO dbo.clientes (nombre, telefono, correo, idUsuario)
            VALUES (@dsNombre, @dsTelefono, @dsCorreo, @id);
    COMMIT;

    SELECT @id AS id;
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_ActualizarUsuario
    @id          INT,
    @dsNombre    VARCHAR(100),
    @dsCorreo    VARCHAR(100),
    @dsTelefono  VARCHAR(20),
    @idRol       TINYINT,
    @dsEstado    BIT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    BEGIN TRAN;
        UPDATE dbo.usuarios
        SET dsNombre = @dsNombre, dsCorreo = @dsCorreo, dsTelefono = @dsTelefono,
            idRol = @idRol, dsEstado = @dsEstado
        WHERE id = @id;

        IF @idRol = 3 AND NOT EXISTS (SELECT 1 FROM dbo.clientes WHERE idUsuario = @id)
            INSERT INTO dbo.clientes (nombre, telefono, correo, idUsuario)
            VALUES (@dsNombre, @dsTelefono, @dsCorreo, @id);
    COMMIT;
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_CambiarPassword
    @id          INT,
    @dsPassword  VARBINARY(64),
    @dsSalt      VARBINARY(16)
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.usuarios SET dsPassword = @dsPassword, dsSalt = @dsSalt WHERE id = @id;
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_EliminarUsuario
    @id INT
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;
    IF EXISTS (SELECT 1 FROM dbo.ventas WHERE idVendedor = @id)
       OR EXISTS (SELECT 1 FROM dbo.ventas v INNER JOIN dbo.clientes c ON c.id = v.idCliente WHERE c.idUsuario = @id)
        THROW 50002, 'No se puede eliminar: el usuario tiene ventas registradas. Desactívelo en su lugar.', 1;

    BEGIN TRAN;
        DELETE FROM dbo.clientes WHERE idUsuario = @id;
        DELETE FROM dbo.usuarios WHERE id = @id;
    COMMIT;
END
GO

-- 4. Procedimientos: PRODUCTOS ----------------------------------------
CREATE OR ALTER PROCEDURE dbo.sp_ListarProductos
    @buscar       VARCHAR(100) = '',
    @soloActivos  BIT = 0
AS
BEGIN
    SET NOCOUNT ON;
    SELECT id, codigo, nombre, descripcion, precio, stock, stockMinimo, estado
    FROM dbo.productos
    WHERE (@soloActivos = 0 OR estado = 1)
      AND (@buscar = '' OR codigo LIKE '%' + @buscar + '%' OR nombre LIKE '%' + @buscar + '%')
    ORDER BY nombre;
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_InsertarProducto
    @codigo       VARCHAR(20),
    @nombre       VARCHAR(100),
    @descripcion  VARCHAR(250),
    @precio       DECIMAL(10,2),
    @stock        INT,
    @stockMinimo  INT,
    @estado       BIT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.productos WHERE codigo = @codigo)
        THROW 50003, 'Ya existe un producto con ese código.', 1;

    INSERT INTO dbo.productos (codigo, nombre, descripcion, precio, stock, stockMinimo, estado)
    VALUES (@codigo, @nombre, @descripcion, @precio, @stock, @stockMinimo, @estado);
    SELECT CAST(SCOPE_IDENTITY() AS INT) AS id;
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_ActualizarProducto
    @id           INT,
    @codigo       VARCHAR(20),
    @nombre       VARCHAR(100),
    @descripcion  VARCHAR(250),
    @precio       DECIMAL(10,2),
    @stock        INT,
    @stockMinimo  INT,
    @estado       BIT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.productos WHERE codigo = @codigo AND id <> @id)
        THROW 50003, 'Ya existe un producto con ese código.', 1;

    UPDATE dbo.productos
    SET codigo = @codigo, nombre = @nombre, descripcion = @descripcion, precio = @precio,
        stock = @stock, stockMinimo = @stockMinimo, estado = @estado
    WHERE id = @id;
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_EliminarProducto
    @id INT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.detalle_venta WHERE idProducto = @id)
        THROW 50004, 'No se puede eliminar: el producto tiene ventas registradas. Desactívelo en su lugar.', 1;
    DELETE FROM dbo.productos WHERE id = @id;
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_ProductosBajoStock
AS
BEGIN
    SET NOCOUNT ON;
    SELECT id, codigo, nombre, descripcion, precio, stock, stockMinimo, estado
    FROM dbo.productos
    WHERE estado = 1 AND stock <= stockMinimo
    ORDER BY stock, nombre;
END
GO

-- 5. Procedimientos: CLIENTES -----------------------------------------
CREATE OR ALTER PROCEDURE dbo.sp_ListarClientes
    @buscar       VARCHAR(100) = '',
    @soloActivos  BIT = 0
AS
BEGIN
    SET NOCOUNT ON;
    SELECT c.id, c.nombre, c.cedula, c.telefono, c.correo, c.direccion, c.idUsuario,
           u.dsUsuario AS usuario, c.estado
    FROM dbo.clientes c
    LEFT JOIN dbo.usuarios u ON u.id = c.idUsuario
    WHERE (@soloActivos = 0 OR c.estado = 1)
      AND (@buscar = '' OR c.nombre LIKE '%' + @buscar + '%' OR c.cedula LIKE '%' + @buscar + '%')
    ORDER BY c.nombre;
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_InsertarCliente
    @nombre     VARCHAR(100),
    @cedula     VARCHAR(20),
    @telefono   VARCHAR(20),
    @correo     VARCHAR(100),
    @direccion  VARCHAR(200),
    @estado     BIT
AS
BEGIN
    SET NOCOUNT ON;
    IF @cedula IS NOT NULL AND EXISTS (SELECT 1 FROM dbo.clientes WHERE cedula = @cedula)
        THROW 50005, 'Ya existe un cliente con esa cédula.', 1;

    INSERT INTO dbo.clientes (nombre, cedula, telefono, correo, direccion, estado)
    VALUES (@nombre, @cedula, @telefono, @correo, @direccion, @estado);
    SELECT CAST(SCOPE_IDENTITY() AS INT) AS id;
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_ActualizarCliente
    @id         INT,
    @nombre     VARCHAR(100),
    @cedula     VARCHAR(20),
    @telefono   VARCHAR(20),
    @correo     VARCHAR(100),
    @direccion  VARCHAR(200),
    @estado     BIT
AS
BEGIN
    SET NOCOUNT ON;
    IF @cedula IS NOT NULL AND EXISTS (SELECT 1 FROM dbo.clientes WHERE cedula = @cedula AND id <> @id)
        THROW 50005, 'Ya existe un cliente con esa cédula.', 1;

    UPDATE dbo.clientes
    SET nombre = @nombre, cedula = @cedula, telefono = @telefono, correo = @correo,
        direccion = @direccion, estado = @estado
    WHERE id = @id;
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_EliminarCliente
    @id INT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM dbo.ventas WHERE idCliente = @id)
        THROW 50006, 'No se puede eliminar: el cliente tiene ventas registradas. Desactívelo en su lugar.', 1;
    IF EXISTS (SELECT 1 FROM dbo.clientes WHERE id = @id AND idUsuario IS NOT NULL)
        THROW 50007, 'El cliente tiene una cuenta de usuario. Elimínelo desde el módulo Usuarios.', 1;
    DELETE FROM dbo.clientes WHERE id = @id;
END
GO

-- 6. Procedimientos: VENTAS -------------------------------------------
CREATE OR ALTER PROCEDURE dbo.sp_InsertarVenta
    @idCliente   INT,
    @idVendedor  INT = NULL,
    @detalle     dbo.DetalleVentaTipo READONLY
AS
BEGIN
    SET NOCOUNT ON;
    SET XACT_ABORT ON;

    IF NOT EXISTS (SELECT 1 FROM @detalle)
        THROW 50010, 'La venta no tiene productos.', 1;

    -- Agrupar por producto por si el carrito trae la misma línea dos veces
    DECLARE @lineas TABLE (idProducto INT PRIMARY KEY, cantidad INT);
    INSERT INTO @lineas SELECT idProducto, SUM(cantidad) FROM @detalle GROUP BY idProducto;

    IF EXISTS (SELECT 1 FROM @lineas WHERE cantidad <= 0)
        THROW 50011, 'Las cantidades deben ser mayores que cero.', 1;

    BEGIN TRAN;
        -- Bloquea las filas de producto para que dos ventas simultáneas no dejen stock negativo
        DECLARE @sinStock VARCHAR(100) =
            (SELECT TOP 1 p.nombre
             FROM @lineas l
             INNER JOIN dbo.productos p WITH (UPDLOCK, ROWLOCK) ON p.id = l.idProducto
             WHERE p.estado = 0 OR p.stock < l.cantidad);
        IF @sinStock IS NOT NULL
        BEGIN
            DECLARE @msg NVARCHAR(200) = CONCAT('Stock insuficiente o producto inactivo: ', @sinStock, '.');
            THROW 50012, @msg, 1;
        END

        -- El precio se toma de la base de datos, no del cliente
        DECLARE @subtotal DECIMAL(12,2) =
            (SELECT SUM(l.cantidad * p.precio) FROM @lineas l INNER JOIN dbo.productos p ON p.id = l.idProducto);
        DECLARE @itbms DECIMAL(12,2) = ROUND(@subtotal * 0.07, 2);

        INSERT INTO dbo.ventas (idCliente, idVendedor, subtotal, itbms, total)
        VALUES (@idCliente, @idVendedor, @subtotal, @itbms, @subtotal + @itbms);
        DECLARE @idVenta INT = SCOPE_IDENTITY();

        INSERT INTO dbo.detalle_venta (idVenta, idProducto, cantidad, precioUnitario, subtotal)
        SELECT @idVenta, l.idProducto, l.cantidad, p.precio, l.cantidad * p.precio
        FROM @lineas l INNER JOIN dbo.productos p ON p.id = l.idProducto;

        UPDATE p SET p.stock = p.stock - l.cantidad
        FROM dbo.productos p INNER JOIN @lineas l ON l.idProducto = p.id;
    COMMIT;

    SELECT @idVenta AS id;
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_ListarVentas
    @desde       DATE,
    @hasta       DATE,
    @idCliente   INT = NULL,
    @idVendedor  INT = NULL
AS
BEGIN
    SET NOCOUNT ON;
    SELECT v.id, v.fecha, v.idCliente, c.nombre AS cliente, v.idVendedor,
           ISNULL(u.dsNombre, 'Compra en línea') AS vendedor,
           (SELECT SUM(d.cantidad) FROM dbo.detalle_venta d WHERE d.idVenta = v.id) AS articulos,
           v.subtotal, v.itbms, v.total
    FROM dbo.ventas v
    INNER JOIN dbo.clientes c ON c.id = v.idCliente
    LEFT JOIN dbo.usuarios u ON u.id = v.idVendedor
    WHERE CAST(v.fecha AS DATE) BETWEEN @desde AND @hasta
      AND (@idCliente IS NULL OR v.idCliente = @idCliente)
      AND (@idVendedor IS NULL OR v.idVendedor = @idVendedor)
    ORDER BY v.fecha DESC;
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_DetalleVenta
    @idVenta INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT d.idProducto, p.codigo, p.nombre AS producto, d.cantidad, d.precioUnitario, d.subtotal
    FROM dbo.detalle_venta d
    INNER JOIN dbo.productos p ON p.id = d.idProducto
    WHERE d.idVenta = @idVenta;
END
GO

-- 7. Procedimientos: DASHBOARD y REPORTES ------------------------------
-- Las cifras de ventas se filtran según el rol: Admin = todas, Vendedor = las suyas, Cliente = sus compras
CREATE OR ALTER PROCEDURE dbo.sp_ResumenDashboard
    @idUsuario  INT,
    @idRol      TINYINT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @idCliente INT = (SELECT id FROM dbo.clientes WHERE idUsuario = @idUsuario);
    DECLARE @hoy DATE = CAST(GETDATE() AS DATE);
    DECLARE @inicioMes DATE = DATEFROMPARTS(YEAR(@hoy), MONTH(@hoy), 1);

    WITH ventasVisibles AS (
        SELECT * FROM dbo.ventas
        WHERE @idRol = 1
           OR (@idRol = 2 AND idVendedor = @idUsuario)
           OR (@idRol = 3 AND idCliente = @idCliente)
    )
    SELECT
        (SELECT COUNT(*) FROM dbo.usuarios)                                       AS totalUsuarios,
        (SELECT COUNT(*) FROM dbo.clientes WHERE estado = 1)                      AS totalClientes,
        (SELECT COUNT(*) FROM dbo.productos WHERE estado = 1)                     AS totalProductos,
        (SELECT COUNT(*) FROM dbo.productos WHERE estado = 1 AND stock <= stockMinimo) AS productosBajoStock,
        (SELECT COUNT(*) FROM ventasVisibles)                                     AS numVentas,
        (SELECT ISNULL(SUM(total), 0) FROM ventasVisibles)                        AS montoVentas,
        (SELECT COUNT(*) FROM ventasVisibles WHERE CAST(fecha AS DATE) = @hoy)    AS ventasHoy,
        (SELECT ISNULL(SUM(total), 0) FROM ventasVisibles WHERE CAST(fecha AS DATE) = @hoy) AS montoHoy,
        (SELECT ISNULL(SUM(total), 0) FROM ventasVisibles WHERE fecha >= @inicioMes) AS montoMes;
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_ReporteVentasPorProducto
    @desde DATE,
    @hasta DATE
AS
BEGIN
    SET NOCOUNT ON;
    SELECT p.nombre AS descripcion, SUM(d.cantidad) AS cantidad, SUM(d.subtotal) AS total
    FROM dbo.detalle_venta d
    INNER JOIN dbo.ventas v ON v.id = d.idVenta
    INNER JOIN dbo.productos p ON p.id = d.idProducto
    WHERE CAST(v.fecha AS DATE) BETWEEN @desde AND @hasta
    GROUP BY p.nombre
    ORDER BY total DESC;
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_ReporteVentasPorVendedor
    @desde DATE,
    @hasta DATE
AS
BEGIN
    SET NOCOUNT ON;
    SELECT ISNULL(u.dsNombre, 'Compra en línea') AS descripcion, COUNT(*) AS cantidad, SUM(v.total) AS total
    FROM dbo.ventas v
    LEFT JOIN dbo.usuarios u ON u.id = v.idVendedor
    WHERE CAST(v.fecha AS DATE) BETWEEN @desde AND @hasta
    GROUP BY u.dsNombre
    ORDER BY total DESC;
END
GO

-- 8. Datos semilla -----------------------------------------------------
IF NOT EXISTS (SELECT 1 FROM dbo.roles)
    INSERT INTO dbo.roles (id, nombre) VALUES (1, 'Administrador'), (2, 'Vendedor'), (3, 'Cliente');
GO

-- Hash = SHA2_512(salt + password), igual que Sha512PasswordService en C#
DECLARE @salt VARBINARY(16);

IF NOT EXISTS (SELECT 1 FROM dbo.usuarios WHERE dsUsuario = 'admin')
BEGIN
    SET @salt = CRYPT_GEN_RANDOM(16);
    INSERT INTO dbo.usuarios (dsUsuario, dsPassword, dsSalt, dsNombre, dsCorreo, dsTelefono, idRol, dsEstado, dsUsuarioCreacion)
    VALUES ('admin', HASHBYTES('SHA2_512', @salt + CAST('Admin123' AS VARBINARY(100))), @salt,
            'Administrador', 'admin@erp-hpa3.com', '6000-0001', 1, 1, 'Sistema');
END

IF NOT EXISTS (SELECT 1 FROM dbo.usuarios WHERE dsUsuario = 'vendedor')
BEGIN
    SET @salt = CRYPT_GEN_RANDOM(16);
    INSERT INTO dbo.usuarios (dsUsuario, dsPassword, dsSalt, dsNombre, dsCorreo, dsTelefono, idRol, dsEstado, dsUsuarioCreacion)
    VALUES ('vendedor', HASHBYTES('SHA2_512', @salt + CAST('Vendedor123' AS VARBINARY(100))), @salt,
            'María González', 'maria.gonzalez@erp-hpa3.com', '6000-0002', 2, 1, 'Sistema');
END

IF NOT EXISTS (SELECT 1 FROM dbo.usuarios WHERE dsUsuario = 'cliente')
BEGIN
    SET @salt = CRYPT_GEN_RANDOM(16);
    INSERT INTO dbo.usuarios (dsUsuario, dsPassword, dsSalt, dsNombre, dsCorreo, dsTelefono, idRol, dsEstado, dsUsuarioCreacion)
    VALUES ('cliente', HASHBYTES('SHA2_512', @salt + CAST('Cliente123' AS VARBINARY(100))), @salt,
            'Carlos Rodríguez', 'carlos.rodriguez@correo.com', '6000-0003', 3, 1, 'Sistema');
    INSERT INTO dbo.clientes (nombre, cedula, telefono, correo, direccion, idUsuario)
    VALUES ('Carlos Rodríguez', '8-888-1234', '6000-0003', 'carlos.rodriguez@correo.com', 'Panamá, San Miguelito', SCOPE_IDENTITY());
END

-- Usuario inactivo para probar la validación de estado (contraseña: Inactivo123)
IF NOT EXISTS (SELECT 1 FROM dbo.usuarios WHERE dsUsuario = 'inactivo')
BEGIN
    SET @salt = CRYPT_GEN_RANDOM(16);
    INSERT INTO dbo.usuarios (dsUsuario, dsPassword, dsSalt, dsNombre, dsCorreo, dsTelefono, idRol, dsEstado, dsUsuarioCreacion)
    VALUES ('inactivo', HASHBYTES('SHA2_512', @salt + CAST('Inactivo123' AS VARBINARY(100))), @salt,
            'Usuario Inactivo', NULL, NULL, 2, 0, 'Sistema');
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.clientes WHERE idUsuario IS NULL)
    INSERT INTO dbo.clientes (nombre, cedula, telefono, correo, direccion) VALUES
        ('Ana Martínez',     '8-765-4321', '6111-2233', 'ana.martinez@correo.com', 'Panamá, Bella Vista'),
        ('Luis Herrera',     '4-123-9876', '6222-3344', 'luis.herrera@correo.com', 'Chiriquí, David'),
        ('Ferretería El Sol','PE-12-345',  '390-1122',  'ventas@elsol.com',         'Colón, Centro');
GO

IF NOT EXISTS (SELECT 1 FROM dbo.productos)
    INSERT INTO dbo.productos (codigo, nombre, descripcion, precio, stock, stockMinimo) VALUES
        ('LAP-001', 'Laptop Lenovo IdeaPad 3',     'Core i5, 8 GB RAM, 512 GB SSD',   649.99, 12, 5),
        ('LAP-002', 'Laptop HP Pavilion 15',       'Core i7, 16 GB RAM, 1 TB SSD',    899.00,  3, 5),
        ('LAP-003', 'Laptop Asus Vivobook 14',     'Ryzen 5, 8 GB RAM, 256 GB SSD',   529.50,  2, 4),
        ('MON-001', 'Monitor Samsung 24"',         'Full HD, 75 Hz',                  149.99, 20, 5),
        ('MON-002', 'Monitor LG UltraWide 29"',    '2560x1080, IPS',                  239.00,  4, 5),
        ('TEC-001', 'Teclado mecánico Redragon',   'Switch azul, retroiluminado',      45.90, 30, 10),
        ('MOU-001', 'Mouse Logitech M185',         'Inalámbrico',                      14.99, 50, 10),
        ('MOU-002', 'Mouse gamer Razer DeathAdder','16 000 DPI',                       59.99,  6, 8),
        ('AUD-001', 'Audífonos JBL Tune 510BT',    'Bluetooth',                        49.95, 15, 5),
        ('IMP-001', 'Impresora Epson EcoTank L3250','Multifuncional, Wi-Fi',          219.00,  1, 3),
        ('ALM-001', 'Disco SSD Kingston 480 GB',   'SATA III',                         39.99, 25, 8),
        ('ALM-002', 'Memoria USB SanDisk 64 GB',   'USB 3.0',                          11.50,  9, 10);
GO

-- Ventas de ejemplo (los totales incluyen ITBMS del 7 %)
IF NOT EXISTS (SELECT 1 FROM dbo.ventas)
BEGIN
    DECLARE @vend INT = (SELECT id FROM dbo.usuarios WHERE dsUsuario = 'vendedor');
    DECLARE @adm  INT = (SELECT id FROM dbo.usuarios WHERE dsUsuario = 'admin');
    DECLARE @cCarlos INT = (SELECT id FROM dbo.clientes WHERE cedula = '8-888-1234');
    DECLARE @cAna    INT = (SELECT id FROM dbo.clientes WHERE cedula = '8-765-4321');
    DECLARE @cLuis   INT = (SELECT id FROM dbo.clientes WHERE cedula = '4-123-9876');
    DECLARE @ventasSemilla TABLE (n INT, dias INT, idCliente INT, idVendedor INT, codigo VARCHAR(20), cantidad INT);
    INSERT INTO @ventasSemilla VALUES
        (1, 20, @cAna,    @vend, 'LAP-001', 1), (1, 20, @cAna,    @vend, 'MOU-001', 2),
        (2, 12, @cLuis,   @vend, 'MON-001', 2), (2, 12, @cLuis,   @vend, 'TEC-001', 1),
        (3,  6, @cCarlos, NULL,  'AUD-001', 1), (3,  6, @cCarlos, NULL,  'ALM-001', 1),
        (4,  2, @cAna,    @adm,  'IMP-001', 1),
        (5,  0, @cLuis,   @vend, 'MOU-002', 1), (5,  0, @cLuis,   @vend, 'ALM-002', 3);

    DECLARE @n INT = 1, @idVenta INT;
    WHILE @n <= 5
    BEGIN
        INSERT INTO dbo.ventas (fecha, idCliente, idVendedor, subtotal, itbms, total)
        SELECT TOP 1 DATEADD(DAY, -dias, GETDATE()), idCliente, idVendedor, 0, 0, 0 FROM @ventasSemilla WHERE n = @n;
        SET @idVenta = SCOPE_IDENTITY();

        INSERT INTO dbo.detalle_venta (idVenta, idProducto, cantidad, precioUnitario, subtotal)
        SELECT @idVenta, p.id, s.cantidad, p.precio, s.cantidad * p.precio
        FROM @ventasSemilla s INNER JOIN dbo.productos p ON p.codigo = s.codigo
        WHERE s.n = @n;

        UPDATE dbo.ventas
        SET subtotal = t.sub, itbms = ROUND(t.sub * 0.07, 2), total = t.sub + ROUND(t.sub * 0.07, 2)
        FROM (SELECT SUM(subtotal) AS sub FROM dbo.detalle_venta WHERE idVenta = @idVenta) t
        WHERE id = @idVenta;

        SET @n += 1;
    END
END
GO

-- 9. Conexión específica con PRIVILEGIOS MÍNIMOS -----------------------
-- La aplicación NO usa sa ni la cuenta de Windows del administrador.
-- Requiere que el servidor tenga Autenticación Mixta (SQL Server y Windows).
USE master;
GO
IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'app_login_erp')
    CREATE LOGIN app_login_erp
        WITH PASSWORD = 'ErpHPA3#2026!',
             DEFAULT_DATABASE = ERP_HPA3,
             CHECK_POLICY = ON;
GO
USE ERP_HPA3;
GO
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'app_user')
    CREATE USER app_user FOR LOGIN app_login_erp;
GO

-- Solo puede EJECUTAR los procedimientos de la aplicación (uno por uno, sin permisos de esquema)
GRANT EXECUTE ON dbo.sp_ObtenerUsuario           TO app_user;
GRANT EXECUTE ON dbo.sp_ListarUsuarios           TO app_user;
GRANT EXECUTE ON dbo.sp_InsertarUsuario          TO app_user;
GRANT EXECUTE ON dbo.sp_ActualizarUsuario        TO app_user;
GRANT EXECUTE ON dbo.sp_CambiarPassword          TO app_user;
GRANT EXECUTE ON dbo.sp_EliminarUsuario          TO app_user;
GRANT EXECUTE ON dbo.sp_ListarProductos          TO app_user;
GRANT EXECUTE ON dbo.sp_InsertarProducto         TO app_user;
GRANT EXECUTE ON dbo.sp_ActualizarProducto       TO app_user;
GRANT EXECUTE ON dbo.sp_EliminarProducto         TO app_user;
GRANT EXECUTE ON dbo.sp_ProductosBajoStock       TO app_user;
GRANT EXECUTE ON dbo.sp_ListarClientes           TO app_user;
GRANT EXECUTE ON dbo.sp_InsertarCliente          TO app_user;
GRANT EXECUTE ON dbo.sp_ActualizarCliente        TO app_user;
GRANT EXECUTE ON dbo.sp_EliminarCliente          TO app_user;
GRANT EXECUTE ON dbo.sp_InsertarVenta            TO app_user;
GRANT EXECUTE ON dbo.sp_ListarVentas             TO app_user;
GRANT EXECUTE ON dbo.sp_DetalleVenta             TO app_user;
GRANT EXECUTE ON dbo.sp_ResumenDashboard         TO app_user;
GRANT EXECUTE ON dbo.sp_ReporteVentasPorProducto TO app_user;
GRANT EXECUTE ON dbo.sp_ReporteVentasPorVendedor TO app_user;
GRANT EXECUTE ON TYPE::dbo.DetalleVentaTipo      TO app_user;

-- Sin acceso directo a ninguna tabla
DENY SELECT, INSERT, UPDATE, DELETE ON dbo.roles         TO app_user;
DENY SELECT, INSERT, UPDATE, DELETE ON dbo.usuarios      TO app_user;
DENY SELECT, INSERT, UPDATE, DELETE ON dbo.clientes      TO app_user;
DENY SELECT, INSERT, UPDATE, DELETE ON dbo.productos     TO app_user;
DENY SELECT, INSERT, UPDATE, DELETE ON dbo.ventas        TO app_user;
DENY SELECT, INSERT, UPDATE, DELETE ON dbo.detalle_venta TO app_user;
GO
