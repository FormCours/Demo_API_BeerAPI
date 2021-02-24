CREATE TABLE [dbo].[Brewery]
(
	[Id_Brewery] INT NOT NULL IDENTITY,
	[Name] VARCHAR(50) NOT NULL, 
	[Headquarter] VARCHAR(200),
	[Country] VARCHAR(50),
	CONSTRAINT PK_Brewery PRIMARY KEY([Id_Brewery])
)
