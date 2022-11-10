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

INSERT INTO [User](FirstName, LastName,Email,Birthdate,Passwd)
VALUES
('Benjamin','Sterckx','ben@mail.com','1980-12-10','Test1234='),
('Tom','Tom','tom@mail.com','1980-12-10','Test1234=');

INSERT INTO [Categorie]([Name])
VALUES
('Loyer'),
('Nourriture'),
('Electricité');


INSERT INTO [Account]([Name])
VALUES
('BNP'),
('Fortis'),
('Dexia');


INSERT INTO [Transaction](UserId,AccountId,CategorieId,Amout)
VALUES
(1,1,1,100),
(1,2,2,50),
(1,3,3,75.5),
(2,1,1,55.23),
(2,2,2,65.2),
(2,3,3,75.5);