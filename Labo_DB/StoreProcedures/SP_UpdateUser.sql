CREATE PROCEDURE [dbo].[SP_UpdateUser]
	@LastName NVARCHAR(50),
	@FirstName NVARCHAR(50),
	@Email NVARCHAR(384),
	@Birthdate DATETIME,
	@Id INT
	
AS
	UPDATE [User] SET LastName = @LastName, FirstName = @FirstName, Email = @Email, Birthdate = @Birthdate, UpdatedAt = GETDATE()  OUTPUT inserted.id WHERE Id = @Id
RETURN 0
