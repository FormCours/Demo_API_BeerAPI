CREATE TABLE [dbo].[Beer]
(
	[Id_Beer] INT NOT NULL IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	[Color] VARCHAR(50),
	[Degree] DECIMAL,
	[Id_Brewery] INT NOT NULL,
	[Id_Brand] INT
	CONSTRAINT PK_Beer PRIMARY KEY([Id_Beer]),
	CONSTRAINT FK_Beer_Brewery FOREIGN KEY([Id_Brewery]) REFERENCES [Brewery]([Id_Brewery]),
	CONSTRAINT FK_Beer_Brand FOREIGN KEY([Id_Brand]) REFERENCES [Brand]([Id_Brand])
)
