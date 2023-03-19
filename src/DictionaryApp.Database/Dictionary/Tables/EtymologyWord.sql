CREATE TABLE [Dictionary].[EtymologyWord]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [PartOfSpeechId] INT NOT NULL, 
    [Text] NVARCHAR(100) NOT NULL, 
    [LanguageId] INT NOT NULL, 
    [AncestorId] INT NULL, 
    [OtherProperties] NVARCHAR(MAX) NULL, -- JSON Record
    CONSTRAINT [FK_EtymologyWord_EtymologyWord] FOREIGN KEY ([AncestorId]) REFERENCES [Dictionary].[EtymologyWord]([Id]), 
    CONSTRAINT [FK_EtymologyWord_PartOfSpeech] FOREIGN KEY ([PartOfSpeechId]) REFERENCES [Dictionary].[PartOfSpeech]([Id])
)
