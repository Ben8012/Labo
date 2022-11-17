CREATE TABLE [dbo].[Account]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Number] NVARCHAR(50) NOT NULL, 
    [AccountType] NVARCHAR(50) NOT NULL, 
    [ReceiverName] NVARCHAR(50) NOT NULL, 
    [Communication] NVARCHAR(MAX) NULL, 
    [IsOwner] BIT NOT NULL, 
    [UserId] INT NOT NULL
    CONSTRAINT [FK_Account_ToUser] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]), 
    [IsActive] BIT NOT NULL
)
