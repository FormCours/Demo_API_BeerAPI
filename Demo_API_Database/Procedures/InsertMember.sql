CREATE PROCEDURE [dbo].[InsertMember]
	@Username NVARCHAR(50),
	@Email NVARCHAR(250),
	@Password NVARCHAR(50)
AS
BEGIN
   SET NOCOUNT ON;

   -- Génération du Salt
   DECLARE @Salt UNIQUEIDENTIFIER;
   SET @Salt = NEWID();

   -- Hashage du pwd combiné au salt
   DECLARE @Password_Hash VARBINARY(64);
   SET @Password_Hash = HASHBYTES('SHA2_512', CONCAT(@Salt, @Password));

   -- Insert des données 
   INSERT INTO [dbo].[Member] ([Username], [Email], [Password], [Salt], [Role])
    OUTPUT inserted.Id_Member
    VALUES (@Username, @Email, @Password_Hash, @Salt, 'Member');
END