CREATE TABLE [dbo].[Transaction]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [UserId] INT NOT NULL, 
    [AccountId] INT NOT NULL, 
    [CategorieId] INT NOT NULL, 
    [Amout] FLOAT NOT NULL, 
    CONSTRAINT [FK_Transaction_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]), 
    CONSTRAINT [FK_Transaction_Account] FOREIGN KEY ([AccountId]) REFERENCES [Account]([Id]), 
    CONSTRAINT [FK_Transaction_Categorie] FOREIGN KEY ([CategorieId]) REFERENCES [Categorie]([Id]),
)
