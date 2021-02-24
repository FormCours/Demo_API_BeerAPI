CREATE PROCEDURE [dbo].[UpdateCategory]
    @Id_Category INT,
	@Name VARCHAR(50)

AS
BEGIN
   IF NOT EXISTS (SELECT * FROM [Category] WHERE Id_Category = @Id_Category)
	  THROW 50042, 'Category not exists', 1;

   IF LTRIM(RTRIM(@Name)) LIKE ''
	  THROW 51042, 'Category name is empty', 1;
   
   UPDATE [Category] 
    SET [Name] = @Name
   WHERE [Id_Category] = @Id_Category
END
