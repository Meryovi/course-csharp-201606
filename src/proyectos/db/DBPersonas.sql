CREATE DATABASE [cursocsharp]
GO

USE [cursocsharp]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Personas] (
    [Identificacion]  VARCHAR (50)    NOT NULL,
    [Nombre]          VARCHAR (50)    NOT NULL,
    [Sexo]            VARCHAR (50)    NOT NULL,
    [FechaNacimiento] DATETIME        NOT NULL,
    [EsEmpleado]      BIT             NOT NULL,
    [Sueldo]          NUMERIC (18, 2) NULL
);
GO

create procedure PersonasCrear (
	@Identificacion		varchar(50),
	@Nombre				varchar(50),
	@Sexo				varchar(50),
	@FechaNacimiento	datetime,
	@EsEmpleado			bit,
	@Sueldo				numeric(18, 2) = null
)
as
begin

	insert into Personas(Identificacion, Nombre, Sexo, FechaNacimiento, EsEmpleado, Sueldo)
		values (@Identificacion, @Nombre, @Sexo, @FechaNacimiento, @EsEmpleado, @Sueldo)

end
GO

create procedure PersonasBuscarTodas
as
begin

	select * from Personas

end
GO