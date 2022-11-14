CREATE TABLE [dbo].[Budget]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [PeriodByMonth] INT NOT NULL, 
    [Label] NVARCHAR(50) NOT NULL, 
    [UpdatedAt] DATETIME2 NULL, 
    [IsActive] BIT NOT NULL,
    [CreatedAt] DATETIME2 NOT NULL,
    [UserId] INT NOT NUll, 
    CONSTRAINT [FK_Budget_ToUser] FOREIGN KEY ([UserId]) REFERENCES [User]([Id])

	
)
