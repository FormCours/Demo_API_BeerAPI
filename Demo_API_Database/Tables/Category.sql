CREATE TABLE [dbo].[Category]
(
	[Id_Category] INT NOT NULL IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	CONSTRAINT PK_Category PRIMARY KEY([Id_Category]),
	CONSTRAINT UK_Category UNIQUE([Name])
)
