CREATE TABLE [dbo].[BeerCategory]
(
	[Id_Beer] INT NOT NULL,
	[Id_Category] INT NOT NULL,
	CONSTRAINT PK_BeerCategory PRIMARY KEY([Id_Beer], [Id_Category]),
	CONSTRAINT FK_BeerCategory_Beer FOREIGN KEY([Id_Beer]) REFERENCES [Beer]([Id_Beer]),
	CONSTRAINT FK_BeerCategory_Cat FOREIGN KEY([Id_Category]) REFERENCES [Category]([Id_Category])
)
