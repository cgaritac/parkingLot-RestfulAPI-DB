USE [master]
GO

DROP DATABASE [Proyecto 3]
GO

CREATE DATABASE [Proyecto 3]

USE [Proyecto 3]

CREATE TABLE [dbo].[Persona](
	[IdPersona][int]IDENTITY(1,1) NOT NULL,
	[Nombre][varchar](50) NULL
	)
GO

INSERT INTO [dbo].[Persona]
		(Nombre)
	VALUES
		('Alexis')
GO

SELECT *
FROM Persona
