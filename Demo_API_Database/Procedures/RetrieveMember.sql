CREATE PROCEDURE [dbo].[RetrieveMember]
	@Email NVARCHAR(250),
	@Password NVARCHAR(50)
AS
BEGIN
   SET NOCOUNT ON;

   -- Recuperation le salt lier à la row qui correspond à l'email.
   DECLARE @Salt UNIQUEIDENTIFIER;
   SELECT @Salt = Salt
    FROM [dbo].[Member]
	WHERE Email LIKE @Email;

   -- Si un Salt est trouvé, on continue
   IF @Salt IS NOT NULL 
    BEGIN
	  -- Hashage du pwd combiné au salt
	  DECLARE @Password_Hash VARBINARY(64);
	  SET @Password_Hash = HASHBYTES('SHA2_512', CONCAT(@Salt, @Password));


	  -- Recuperation du member sur base de l'email et du password hashé
	  SELECT [Id_Member], [Username], [Email], [Role]
	   FROM [dbo].[Member]
	   WHERE (Email LIKE @Email) AND (Password = @Password_Hash);

	END
END