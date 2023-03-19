CREATE TABLE [Dictionary].[Author]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(100) NOT NULL, 
    [LastName] NVARCHAR(100) NOT NULL, 
    [Born] DATE NOT NULL, 
    [Died] DATE NOT NULL, 
    [PlaceOfOriginId] INT NULL, 
    CONSTRAINT [FK_Author_PlaceOfOrigin] FOREIGN KEY ([PlaceOfOriginId]) REFERENCES [Dictionary].[PlaceOfOrigin]([Id])
)
