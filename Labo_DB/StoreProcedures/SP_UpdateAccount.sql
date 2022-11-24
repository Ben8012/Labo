CREATE PROCEDURE [dbo].[SP_UpdateAccount]
	@Number NVARCHAR(50), 
	@AccountType NVARCHAR(50), 
	@ReceiverName NVARCHAR(50), 
	@IsOwner BIT,
	@UserId INT, 
	@Id INT

AS
	UPDATE [Account] SET Number = @Number, AccountType = @AccountType, ReceiverName=@ReceiverName, IsOwner = @IsOwner OUTPUT inserted.id WHERE Id=@Id;
RETURN 0
