CREATE TABLE [dbo].[Budget_Category]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [MaxAmount] REAL NOT NULL, 
    [CategoryId] INT NOT NULL, 
    [BudgetId] INT NOT NULL, 
    CONSTRAINT [FK_Budget_Category_ToCategory] FOREIGN KEY ([CategoryId]) REFERENCES [Category]([Id]), 
    CONSTRAINT [FK_Budget_Category_ToBudget] FOREIGN KEY ([BudgetId]) REFERENCES [Budget]([Id]), 
)
