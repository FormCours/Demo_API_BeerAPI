CREATE TABLE [dbo].[Member]
(
	[Id_Member] INT IDENTITY,
	[Username] NVARCHAR(50) NOT NULL,
	[Email] NVARCHAR(250) NOT NULL,
	[Password] VARBINARY(64) NOT NULL,
	[Salt] VARCHAR(50) NOT NULL, -- Salt qui sera ajouter au Mdp pour le hash.
	[Role] VARCHAR(50) NOT NULL,
	CONSTRAINT [PK_Member] PRIMARY KEY([Id_Member]),
	CONSTRAINT [UK_Member_Username] UNIQUE([Username]),
	CONSTRAINT [UK_Member_Email] UNIQUE([Email])
)
