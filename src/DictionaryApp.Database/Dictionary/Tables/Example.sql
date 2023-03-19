CREATE TABLE [Dictionary].[Example]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Text] NVARCHAR(100) NOT NULL, 
    [Year] INT NULL, 
    [IsCirca] BIT NOT NULL DEFAULT 0, 
    [SourceId] INT NULL, 
    [Page] INT NULL, 
    CONSTRAINT [FK_Example_Source] FOREIGN KEY ([SourceId]) REFERENCES [Dictionary].[Source]([Id])
)
