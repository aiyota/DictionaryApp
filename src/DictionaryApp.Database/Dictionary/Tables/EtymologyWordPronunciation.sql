CREATE TABLE [Dictionary].[EtymologyWordPronunciation]
(
	[Id] INT NOT NULL PRIMARY KEY,
    [EtymologyWordId] INT NOT NULL,
    [Year] INT NULL, 
    [IsCirca] BIT NOT NULL DEFAULT 0, 
    [RegionId] INT NULL, 
    [Ipa] NVARCHAR(100) NOT NULL, 
    [AudioFileName] NVARCHAR(400) NULL, 
    CONSTRAINT [FK_EtymologyWordPronunciation_Region] FOREIGN KEY ([RegionId]) REFERENCES [Dictionary].[Region]([Id]), 
    CONSTRAINT [FK_EtymologyWordPronunciation_EtymologyWord] FOREIGN KEY ([EtymologyWordId]) REFERENCES [Dictionary].[EtymologyWord]([Id])
)
