CREATE TABLE [Dictionary].[Pronunciation]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [WordId] INT NOT NULL,
    [Year] INT NULL,
    [IsCirca] BIT NOT NULL DEFAULT 0, 
    [RegionId] INT NOT NULL, 
    [Ipa] NVARCHAR(100) NOT NULL, 
    [AudioFileName] NVARCHAR(400) NULL, 
    CONSTRAINT [FK_Pronunciation_Region] FOREIGN KEY ([RegionId]) REFERENCES [Dictionary].[Region]([Id]), 
    CONSTRAINT [FK_Pronunciation_Word] FOREIGN KEY ([WordId]) REFERENCES [Dictionary].[Word]([Id])
)
