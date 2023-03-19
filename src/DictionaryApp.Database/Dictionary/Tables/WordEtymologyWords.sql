CREATE TABLE [Dictionary].[WordEtymologyWords]
(
	[WordId] INT NOT NULL,
    [EtymologyWordId] INT NOT NULL,
	CONSTRAINT [PK_WordEtymologyWords] PRIMARY KEY ([WordId], [EtymologyWordId]), 
    CONSTRAINT [FK_WordEtymologyWords_Word] FOREIGN KEY ([WordId]) REFERENCES [Dictionary].[Word]([Id]),
	CONSTRAINT [FK_WordEtymologyWords_EtymologyWord] FOREIGN KEY ([EtymologyWordId]) REFERENCES [Dictionary].[EtymologyWord]([Id])
)
