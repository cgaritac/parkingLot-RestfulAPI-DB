USE master
GO

-- Crear la base de datos
CREATE DATABASE Proyecto3_206050530;
GO

-- Usar la base de datos
USE Proyecto3_206050530;
GO

-- Crear la tabla Parqueo
CREATE TABLE Parqueo (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100),
    CantidadVehiculosMax INT,
    HoraApertura DATETIME,
    HoraCierre DATETIME,
    TarifaHora NVARCHAR(10),
    TarifaMedia NVARCHAR(10)
);

-- Insertar valores iniciales en la tabla Parqueo
INSERT INTO Parqueo (Nombre, CantidadVehiculosMax, HoraApertura, HoraCierre, TarifaHora, TarifaMedia)
VALUES ('San Rafael', 40, '1900-01-01T05:00:00', '1900-01-01T22:00:00', '1000', '400');

-- Crear la tabla Empleado
CREATE TABLE Empleado (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FechaIngreso DATETIME,
    Nombre NVARCHAR(100),
    PrimerApellido NVARCHAR(100),
    SegundoApellido NVARCHAR(100),
    FechaNacimiento DATETIME,
    NumeroCedula NVARCHAR(20),
    Direccion NVARCHAR(300),
    Email NVARCHAR(100),
    Telefono NVARCHAR(20),
    TipoContacto NVARCHAR(10),
    IdParqueo INT,
    FOREIGN KEY (IdParqueo) REFERENCES Parqueo(Id)
);

-- Insertar valores iniciales en la tabla Empleado
INSERT INTO Empleado (FechaIngreso, Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, NumeroCedula, Direccion, Email, Telefono, TipoContacto, IdParqueo)
VALUES ('2023-11-22 00:00:00', 'Carlos', 'Garita', 'Campos', '1985-03-30 00:00:00', '0206050530', 'Pavas', 'cgaritac@gmail.com', '71098984', 'Esposa', 1);

-- Crear la tabla Reporte
CREATE TABLE Reporte (
    Ingreso DATETIME,
    Salida DATETIME,
    Mes NVARCHAR(20),
    Venta FLOAT,
    Posicion INT,
    IdParqueo INT,
    FOREIGN KEY (IdParqueo) REFERENCES Parqueo(Id)
);

-- Crear la tabla Tiquete
CREATE TABLE Tiquete (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Ingreso DATETIME,
    Salida DATETIME,
    Placa NVARCHAR(10),
    Venta FLOAT,
    Estado NVARCHAR(10),
    IdParqueo INT,
    FOREIGN KEY (IdParqueo) REFERENCES Parqueo(Id)
);

-- Insertar valores iniciales en la tabla Tiquete
INSERT INTO Tiquete (Ingreso, Salida, Placa, Venta, Estado, IdParqueo)
--VALUES ('2023-11-23 06:00:00', '2023-11-23 10:00:00', 'NCC171', 4000.00, 'Cerrado', 1);
VALUES ('11/23/2023 06:00:00', '2023-11-23 10:00:00', 'NCC171', 4000.00, 'Cerrado', 1);