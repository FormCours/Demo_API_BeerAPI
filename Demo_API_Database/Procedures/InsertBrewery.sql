CREATE PROCEDURE [dbo].[InsertBrewery]
	@Name VARCHAR(50),
	@Headquarter VARCHAR(200) = NULL,
	@Country VARCHAR(50) = NULL
AS
BEGIN
   SET NOCOUNT ON;

   INSERT INTO [Brewery] (Name, Headquarter, Country)
    OUTPUT inserted.Id_Brewery
    VALUES (@Name, @Headquarter, @Country);
END