IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Empleados] (
    [Id] int NOT NULL IDENTITY,
    [Nombre] nvarchar(80) NOT NULL,
    [Apellidos] nvarchar(100) NOT NULL,
    [Departamento] nvarchar(max) NOT NULL,
    [Salario] decimal(18,2) NOT NULL,
    [FechaIngreso] datetime2 NOT NULL,
    [Activo] bit NOT NULL,
    CONSTRAINT [PK_Empleados] PRIMARY KEY ([Id])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260501230658_InitialCreate', N'10.0.7');

COMMIT;
GO