-- Insertar valores iniciales en la tabla Parqueo
INSERT INTO Parqueo (Nombre, CantidadVehiculosMax, HoraApertura, HoraCierre, TarifaHora, TarifaMedia)
VALUES ('San Rafael', 40, '1900-01-01T05:00:00', '1900-01-01T22:00:00', '1000.00', '400.00');

-- Insertar valores iniciales en la tabla Empleado
INSERT INTO Empleado (FechaIngreso, Nombre, PrimerApellido, SegundoApellido, FechaNacimiento, NumeroCedula, Direccion, Email, Telefono, TipoContacto, IdParqueo)
VALUES ('2023-11-22 00:00:00', 'Carlos', 'Garita', 'Campos', '1985-03-30 00:00:00', '0206050530', 'Pavas', 'cgaritac@gmail.com', '71098984', 'Esposa', 1);

-- Insertar valores iniciales en la tabla Tiquete
INSERT INTO Tiquete (Ingreso, Salida, Placa, Venta, Estado, IdParqueo)
VALUES ('2023-11-23 06:00:00', '2023-11-23 10:00:00', 'NCC171', 4000.00, 'Cerrado', 1);