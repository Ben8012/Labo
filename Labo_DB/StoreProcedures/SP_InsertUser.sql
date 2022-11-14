CREATE PROCEDURE [dbo].[SP_InsertUser]
	@LastName NVARCHAR(50),
	@FirstName NVARCHAR(50),
	@Email NVARCHAR(384),
	@Birthdate DATETIME,
	@Password NVARCHAR(250)
AS
	INSERT INTO [User](LastName, FirstName, Email, Birthdate, [Password], CreatedAt ,IsActive) OUTPUT inserted.id VALUES(@LastName, @FirstName, @Email, @Birthdate, @Password, GETDATE(), 1)
RETURN 
