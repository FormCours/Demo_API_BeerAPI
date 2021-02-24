CREATE PROCEDURE [dbo].[InsertCategory]
	@Name VARCHAR(50)
AS
BEGIN
   SET NOCOUNT ON;

   INSERT INTO [Category] (Name)
    OUTPUT inserted.Id_Category
    VALUES (@Name);
END