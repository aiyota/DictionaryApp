CREATE TABLE [Dictionary].[EtymologyWordDefinition]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [EtymologyWordId] INT NOT NULL, 
    [SourceId] INT NULL, 
    [CategoryId] INT NULL, 
    [Text] NVARCHAR(MAX) NOT NULL, 
    [Year] INT NULL, 
    [IsCirca] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_EtymologyDefinition_Word] FOREIGN KEY ([EtymologyWordId]) REFERENCES [Dictionary].[EtymologyWord]([Id]), 
    CONSTRAINT [FK_EtymologyDefinition_Source] FOREIGN KEY ([SourceId]) REFERENCES [Dictionary].[Source]([Id]), 
    CONSTRAINT [FK_EtymologyDefinition_Category] FOREIGN KEY ([CategoryId]) REFERENCES [Dictionary].[Category]([Id])
)
