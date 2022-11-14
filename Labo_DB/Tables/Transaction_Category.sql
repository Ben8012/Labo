CREATE TABLE [dbo].[Transaction_Category]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [AmoutDetail] REAL NOT NULL, 
    [CategoryId] INT NOT NULL, 
    [TransactionId] INT NOT NULL, 
    CONSTRAINT [FK_Transaction_Category_ToTransaction] FOREIGN KEY ( [TransactionId]) REFERENCES [Transaction]([Id]), 
    CONSTRAINT [FK_Transaction_Category_ToCategory] FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id])
)
