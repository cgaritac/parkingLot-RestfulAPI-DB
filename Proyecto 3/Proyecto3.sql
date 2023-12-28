USE master
GO

-- Crear la base de datos
CREATE DATABASE Proyecto3;
GO

-- Usar la base de datos
USE Proyecto3;
GO

-- Crear la tabla Parqueo
CREATE TABLE Parqueo (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) DEFAULT ('San Rafael'),
    CantidadVehiculosMax INT DEFAULT (40),
    HoraApertura DATETIME DEFAULT ('0001-01-01T05:00:00'),
    HoraCierre DATETIME DEFAULT ('0001-01-01T22:00:00'),
    TarifaHora NVARCHAR(10) DEFAULT ('1000.00'),
    TarifaMedia NVARCHAR(10) DEFAULT ('400.00')
);

-- Insertar valores iniciales en la tabla Parqueo
INSERT INTO Parqueo (Nombre, CantidadVehiculosMax, HoraApertura, HoraCierre, TarifaHora, TarifaMedia)
VALUES ('Parqueo Inicial', 50, '2023-03-03T08:00:00', '2023-03-03T20:00:00', '5.00', '2.50');

-- Crear la tabla Empleado
CREATE TABLE Empleado (
    Id INT PRIMARY KEY IDENTITY(1,1),
    FechaIngreso DATETIME DEFAULT ('2023-11-23T00:00:00'),
    Nombre NVARCHAR(100) DEFAULT ('Carlos'),
    PrimerApellido NVARCHAR(100) DEFAULT ('Garita'),
    SegundoApellido NVARCHAR(100) DEFAULT ('Campos'),
    FechaNacimiento DATETIME DEFAULT ('1985-03-30T00:00:00'),
    NumeroCedula NVARCHAR(20) DEFAULT ('0206050530'),
    Direccion NVARCHAR(300) DEFAULT ('Pavas'),
    Email NVARCHAR(100) DEFAULT ('cgaritac@gmail.com'),
    Telefono NVARCHAR(20) DEFAULT ('71098984'),
    TipoContacto NVARCHAR(10) DEFAULT ('Esposa'),
    IdParqueo INT DEFAULT (1),
    FOREIGN KEY (IdParqueo) REFERENCES Parqueo(Id)
);

-- Insertar valores iniciales en la tabla Empleado
INSERT INTO Empleado (FechaIngreso, Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, NumeroCedula, Direccion, Email, Telefono, TipoContacto, IdParqueo)
VALUES ('2023-03-03T09:00:00', 'Juan', 'Pérez', 'Gómez', '1990-01-15T00:00:00', '123456789', 'Calle Principal 123', 'juan@example.com', '123-456-7890', 'Personal', 1);

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
    Ingreso DATETIME DEFAULT ('2023-11-23T06:00:00'),
    Salida DATETIME DEFAULT ('2023-11-23T10:00:00'),
    Placa NVARCHAR(10) DEFAULT ('NCC171'),
    Venta FLOAT DEFAULT (4000.00),
    Estado NVARCHAR(10) DEFAULT ('Cerrado'),
    IdParqueo INT DEFAULT (1),
    FOREIGN KEY (IdParqueo) REFERENCES Parqueo(Id)
);

-- Insertar valores iniciales en la tabla Tiquete
INSERT INTO Tiquete (Ingreso, Salida, Placa, Venta, Estado, IdParqueo)
VALUES ('2023-03-03T10:00:00', '2023-03-03T18:00:00', 'ABC123', 20.00, 'Pagado', 1);