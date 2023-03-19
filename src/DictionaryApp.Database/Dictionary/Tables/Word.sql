CREATE TABLE [Dictionary].[Word]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Text] NVARCHAR(100) NOT NULL, 
    [PartOfSpeechId] INT NOT NULL, 
    [EtymologyNote] NVARCHAR(MAX) NULL, 
    [StatusId] INT NOT NULL DEFAULT 1, 
    [OtherProperties] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_Word_PartOfSpeech] FOREIGN KEY ([PartOfSpeechId]) REFERENCES [Dictionary].[PartOfSpeech]([Id]), 
    CONSTRAINT [FK_Word_Status] FOREIGN KEY ([StatusId]) REFERENCES [Dictionary].[Status]([Id])
)
