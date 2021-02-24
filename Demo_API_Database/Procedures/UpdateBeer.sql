CREATE PROCEDURE [dbo].[UpdateBeer]
    @Id_Beer INT,
	@Name VARCHAR(50),
	@Id_Brewery INT,
	@Id_Brand INT = NULL,
	@Color VARCHAR(50) = NULL,
	@Degree decimal(18,0) = NULL
AS
BEGIN  
   UPDATE [Beer] 
    SET [Name] = @Name,
	    [Id_Brewery] = @Id_Brewery,
	    [Id_Brand] = @Id_Brand,
	    [Color] = @Color,
	    [Degree] = @Degree
   WHERE [Id_Beer] = @Id_Beer
END