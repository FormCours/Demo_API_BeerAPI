CREATE TABLE [dbo].[Brand]
(
	[Id_Brand] INT NOT NULL IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Country] VARCHAR(50) NULL,
	[Creation_Year] INT NULL,
	CONSTRAINT PK_Brand PRIMARY KEY([Id_Brand])
)
