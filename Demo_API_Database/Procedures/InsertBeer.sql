CREATE PROCEDURE [dbo].[InsertBeer]
	@Name VARCHAR(50),
	@Id_Brewery INT,
	@Id_Brand INT = NULL,
	@Color VARCHAR(50) = NULL,
	@Degree decimal(18,0) = NULL
AS
BEGIN
   SET NOCOUNT ON;

   INSERT INTO [Beer] (Name, Color, Degree, Id_Brewery, Id_Brand)
    OUTPUT inserted.Id_Beer
	VALUES (@Name, @Color, @Degree, @Id_Brewery, @Id_Brand)
END
