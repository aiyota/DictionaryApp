CREATE TABLE [Dictionary].[PlaceOfOrigin]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(100) NULL,
	CONSTRAINT [UQ_PlaceOfOrigin_Name] UNIQUE ([Name])
)
