CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL, 
    [Email] NVARCHAR(384) NOT NULL, 
    [Birthdate] DATE NOT NULL, 
    [Passwd] NVARCHAR(250) NOT NULL
	
)
