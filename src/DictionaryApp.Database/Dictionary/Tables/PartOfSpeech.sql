CREATE TABLE [Dictionary].[PartOfSpeech]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(100) NOT NULL, 
    CONSTRAINT [UQ_PartOfSpeech_Name] UNIQUE ([Name])
)
