/* =====================================================================
   Parcial Práctico HPA III - Login en Capas (MVP)
   Base de datos: SQL Server 2022 Express (.\SQLEXPRESS)
   Ejecutar como administrador (Autenticación de Windows) en SSMS o:
       sqlcmd -S .\SQLEXPRESS -E -i script.sql
   ===================================================================== */

-- 1. Base de datos -----------------------------------------------------
IF DB_ID('ParcialHPA3_Login') IS NULL
    CREATE DATABASE ParcialHPA3_Login;
GO
USE ParcialHPA3_Login;
GO

-- 2. Tabla de usuarios -------------------------------------------------
-- dsPassword: VARBINARY(64) porque SHA-512 produce 512 bits = 64 bytes
IF OBJECT_ID('dbo.usuarios', 'U') IS NULL
CREATE TABLE dbo.usuarios (
    id                 INT IDENTITY(1,1) PRIMARY KEY,
    dsUsuario          VARCHAR(50)    NOT NULL UNIQUE,
    dsPassword         VARBINARY(64)  NOT NULL,
    dsSalt             VARBINARY(16)  NOT NULL,
    dsNombre           VARCHAR(100)   NOT NULL,
    dsEstado           BIT            NOT NULL DEFAULT 1,
    dsUsuarioCreacion  VARCHAR(50)    NULL,
    dsFechaCreacion    DATETIME       NOT NULL DEFAULT GETDATE()
);
GO

-- 3. Procedimientos almacenados ---------------------------------------
CREATE OR ALTER PROCEDURE dbo.sp_ObtenerUsuario
    @dsUsuario VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT id, dsUsuario, dsPassword, dsSalt, dsNombre, dsEstado,
           dsUsuarioCreacion, dsFechaCreacion
    FROM dbo.usuarios
    WHERE dsUsuario = @dsUsuario;
END
GO

CREATE OR ALTER PROCEDURE dbo.sp_InsertarUsuario
    @dsUsuario          VARCHAR(50),
    @dsPassword         VARBINARY(64),
    @dsSalt             VARBINARY(16),
    @dsNombre           VARCHAR(100),
    @dsEstado           BIT,
    @dsUsuarioCreacion  VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.usuarios (dsUsuario, dsPassword, dsSalt, dsNombre, dsEstado, dsUsuarioCreacion)
    VALUES (@dsUsuario, @dsPassword, @dsSalt, @dsNombre, @dsEstado, @dsUsuarioCreacion);

    SELECT CAST(SCOPE_IDENTITY() AS INT) AS id;
END
GO

-- 4. Usuarios semilla --------------------------------------------------
-- Hash = SHA2_512(salt + password), igual que Sha512PasswordService en C#
DECLARE @salt VARBINARY(16);

IF NOT EXISTS (SELECT 1 FROM dbo.usuarios WHERE dsUsuario = 'admin')
BEGIN
    SET @salt = CRYPT_GEN_RANDOM(16);
    INSERT INTO dbo.usuarios (dsUsuario, dsPassword, dsSalt, dsNombre, dsEstado, dsUsuarioCreacion)
    VALUES ('admin', HASHBYTES('SHA2_512', @salt + CAST('123456' AS VARBINARY(100))), @salt,
            'Administrador', 1, 'Sistema');
END

-- Usuario inactivo para probar la validación de estado
IF NOT EXISTS (SELECT 1 FROM dbo.usuarios WHERE dsUsuario = 'inactivo')
BEGIN
    SET @salt = CRYPT_GEN_RANDOM(16);
    INSERT INTO dbo.usuarios (dsUsuario, dsPassword, dsSalt, dsNombre, dsEstado, dsUsuarioCreacion)
    VALUES ('inactivo', HASHBYTES('SHA2_512', @salt + CAST('123456' AS VARBINARY(100))), @salt,
            'Usuario Inactivo', 0, 'Sistema');
END
GO

-- 5. Conexión específica con PRIVILEGIOS MÍNIMOS -----------------------
-- La aplicación NO usa sa ni la cuenta de Windows del administrador.
-- Requiere que el servidor tenga Autenticación Mixta (SQL Server y Windows).
USE master;
GO
IF NOT EXISTS (SELECT 1 FROM sys.server_principals WHERE name = 'app_login_parcial')
    CREATE LOGIN app_login_parcial
        WITH PASSWORD = 'Parcial#HPA3_2026',
             DEFAULT_DATABASE = ParcialHPA3_Login,
             CHECK_POLICY = ON;
GO
USE ParcialHPA3_Login;
GO
IF NOT EXISTS (SELECT 1 FROM sys.database_principals WHERE name = 'app_user')
    CREATE USER app_user FOR LOGIN app_login_parcial;
GO
-- Solo puede EJECUTAR los dos procedimientos; no puede leer ni modificar tablas directamente
GRANT EXECUTE ON dbo.sp_ObtenerUsuario  TO app_user;
GRANT EXECUTE ON dbo.sp_InsertarUsuario TO app_user;
DENY SELECT, INSERT, UPDATE, DELETE ON dbo.usuarios TO app_user;
GO
