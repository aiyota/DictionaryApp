CREATE TABLE [Dictionary].[Definition]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [WordId] INT NOT NULL, 
    [SourceId] INT NULL, 
    [CategoryId] INT NULL, 
    [Text] NVARCHAR(MAX) NOT NULL, 
    [Year] INT NULL, 
    [IsCirca] BIT NOT NULL DEFAULT 0, 
    [StatusId] INT NOT NULL DEFAULT 1 , 
    CONSTRAINT [FK_Definition_Word] FOREIGN KEY ([WordId]) REFERENCES [Dictionary].[Word]([Id]), 
    CONSTRAINT [FK_Definition_Source] FOREIGN KEY ([SourceId]) REFERENCES [Dictionary].[Source]([Id]), 
    CONSTRAINT [FK_Definition_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Dictionary].[DefinitionCategory]([Id]), 
    CONSTRAINT [FK_Definition_Status] FOREIGN KEY ([StatusId]) REFERENCES [Dictionary].[Status]([Id])
)
