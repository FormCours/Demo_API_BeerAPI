CREATE PROCEDURE [dbo].[UpdateBrand]
    @Id_Brand INT,
	@Name VARCHAR(50),
	@Country VARCHAR(50) = NULL,
	@Creation_Year INT = NULL
AS
BEGIN
   IF NOT EXISTS (SELECT * FROM [Brand] WHERE Id_Brand = @Id_Brand)
	  THROW 50042, 'Brand not exists', 1;

   IF LTRIM(RTRIM(@Name)) LIKE ''
	  THROW 51042, 'Brand name is empty', 1;
   
   UPDATE [Brand] 
    SET [Name] = @Name,
		[Country] = @Country,
		[Creation_Year] = @Country
   WHERE [Id_Brand] = @Id_Brand
END
