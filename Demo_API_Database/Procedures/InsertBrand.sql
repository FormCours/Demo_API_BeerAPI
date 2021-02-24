CREATE PROCEDURE [dbo].[InsertBrand]
	@Name VARCHAR(50),
	@Country VARCHAR(50) = NULL,
	@Creation_Year INT = NULL
AS
BEGIN
   SET NOCOUNT ON;

   INSERT INTO [Brand] (Name, Country, Creation_Year)
    OUTPUT inserted.Id_Brand
    VALUES (@Name, @Country, @Creation_Year);
END