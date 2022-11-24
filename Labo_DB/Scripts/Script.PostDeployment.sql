/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

INSERT INTO [dbo].[User](FirstName, LastName, Email, Birthdate, [Password], CreatedAt, UpdatedAt, IsActive) VALUES
('Benjamin','Sterckx','ben@mail.com','1980-12-10','Test1234=',GETDATE(),NULL,1),
('Tom','Tom','tom@mail.com','1980-12-10','Test1234=',GETDATE(),NULL,1);

INSERT INTO [dbo].[Account](Number, ReceiverName, AccountType, IsOwner, UserId, IsActive)
--INSERT INTO [Account](Number,ReceiverName,Communication,AccountType,IsOwner,UserId)
VALUES
('BE10 1010 1010 1010','Tom','Courant',1,1,1),
('BE10 1010 1010 1011','Tom','Epargne',1,1,1),
('BE10 1010 1010 1012','Benjamin','Courant',1,2,1),
('BE10 1010 1010 1013','Benjamin','Epargne',1,2,1);

INSERT INTO [Budget] (Label,PeriodByMonth,CreatedAt,UpdatedAt,IsActive,UserId)
VALUES 
('Bouffe',6,GETDATE(),NULL,1,1),
('Loisir',12,GETDATE(),NULL,1,2),
('Loisir',8,GETDATE(),NULL,1,1);

INSERT INTO [Transaction](TotalAmount, CreatedAt, UpdatedAt, IsActive, AccountCreditId, AccountDebitId, BudgetId, ExecutionDate)
--INSERT INTO [Transaction](TotalAmout,CreatedAt,UpdatedAt,IsActive,AccountCreditId,AccountDebitId,BudgetId,ExecutionDate)
VALUES
(100,GETDATE(),NULL,1,1,2,1,GETDATE()),
(50,GETDATE(),NULL,1,2,1,1,GETDATE()),
(60,GETDATE(),NULL,1,1,2,1,GETDATE()),
(20,GETDATE(),NULL,1,2,1,1,GETDATE());


INSERT INTO [Category]([Label],CreatedAt,UpdatedAt,IsActive) VALUES 
('Eléctricité',GETDATE(),NULL,1),
('Loyé',GETDATE(),NULL,1),
('Nourriture',GETDATE(),NULL,1),
('Jeux',GETDATE(),NULL,1);


INSERT INTO [Transaction_Category](AmoutDetail,CategoryId,TransactionId)
VALUES
(25,1,1),
(55,2,1),
(20,3,1);

INSERT INTO [Budget_Category](BudgetId,CategoryId, MaxAmount)
VALUES
(1,3, 200),
(2,4, 100),
(3,4, 300);