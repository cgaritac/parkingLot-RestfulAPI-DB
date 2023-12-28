USE Proyecto3;
GO


-- Ver valores de la tabla Parqueo
SELECT * FROM Parqueo;

-- Ver valores de la tabla Empleado
SELECT * FROM Empleado;

-- Ver valores de la tabla Reporte
SELECT * FROM Reporte;

-- Ver valores de la tabla Tiquete
SELECT * FROM Tiquete;


-- Contar registros en la tabla Parqueo
SELECT COUNT(*) AS TotalRegistrosParqueo FROM Parqueo;

-- Contar registros en la tabla Empleado
SELECT COUNT(*) AS TotalRegistrosEmpleado FROM Empleado;

-- Contar registros en la tabla Reporte
SELECT COUNT(*) AS TotalRegistrosReporte FROM Reporte;

-- Contar registros en la tabla Tiquete
SELECT COUNT(*) AS TotalRegistrosTiquete FROM Tiquete;