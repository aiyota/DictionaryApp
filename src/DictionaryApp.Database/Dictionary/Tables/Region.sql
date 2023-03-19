/*
	e.g. U.K., US Midwest, Scotland etc.
*/
CREATE TABLE [Dictionary].[Region]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(100) NOT NULL,
	CONSTRAINT [UQ_Region_Name] UNIQUE ([Name])
)
