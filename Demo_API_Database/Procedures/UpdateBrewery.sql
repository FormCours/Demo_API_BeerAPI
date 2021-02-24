CREATE PROCEDURE [dbo].[UpdateBrewery]
    @Id_Brewery INT,
	@Name VARCHAR(50),
	@Headquarter VARCHAR(200) = NULL,
	@Country VARCHAR(50) = NULL
AS
BEGIN
   SET NOCOUNT ON;

   IF NOT EXISTS (SELECT * FROM [Brewery] WHERE Id_Brewery = @Id_Brewery)
	  THROW 50042, 'Brewery not exists', 1;

   IF LTRIM(RTRIM(@Name)) LIKE ''
	  THROW 51042, 'Brewery name is empty', 1;
   
   UPDATE [Brewery] 
    SET [Name] = @Name,
	    [Headquarter] = @Headquarter,
	    [Country] = @Country
   WHERE [Id_Brewery] = @Id_Brewery
END
