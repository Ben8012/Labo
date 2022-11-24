CREATE TABLE [dbo].[Transaction]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [TotalAmount] FLOAT NOT NULL, 
    [CreatedAt] DATETIME2 NOT NULL, 
    [UpdatedAt] DATETIME2 NULL, 
    [ExecutionDate] DATETIME2 NOT NULL,
    [IsActive] BIT NOT NULL, 
    [Communication] NVARCHAR(MAX) NULL, 
    [BudgetId] INT NOT NULL,
    [AccountDebitId] INT NOT NULL,
    [AccountCreditId] INT NOT NULL,
    CONSTRAINT [FK_Transaction_ToBudget] FOREIGN KEY ([BudgetId]) REFERENCES [Budget]([Id]), 
    CONSTRAINT [FK_Transaction_ToAccountDebit] FOREIGN KEY ([AccountDebitId]) REFERENCES [Account]([Id]), 
    CONSTRAINT [FK_Transaction_ToAccountCredit] FOREIGN KEY ([AccountCreditId]) REFERENCES [Account]([Id])

  
)
