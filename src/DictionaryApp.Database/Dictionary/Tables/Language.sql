CREATE TABLE [Dictionary].[Language]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(100) NOT NULL, 
    [SpokenFromDate] INT NULL, 
    [ExtinctDate] INT NULL, 
    [PlaceOfOriginId] INT NULL, 
    CONSTRAINT [FK_Language_PlaceOfOrigin] FOREIGN KEY ([PlaceOfOriginId]) REFERENCES [Dictionary].[PlaceOfOrigin]([Id])
)
