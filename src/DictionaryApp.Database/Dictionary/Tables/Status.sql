/*
    E.g. obsolete, archaic
*/
CREATE TABLE [Dictionary].[Status]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(100) NOT NULL, 
    CONSTRAINT [UQ_Status_Name] UNIQUE ([Name])
)
