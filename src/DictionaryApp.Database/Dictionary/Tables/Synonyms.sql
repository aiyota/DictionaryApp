CREATE TABLE [Dictionary].[Synonyms]
(
	[Word1Id] INT NOT NULL, 
    [Word2Id] INT NOT NULL,
	CONSTRAINT PK_Synonyms PRIMARY KEY ([Word1Id], [Word2Id]), 
    CONSTRAINT [FK_Synonyms_Word1] FOREIGN KEY ([Word1Id]) REFERENCES [Dictionary].[Word]([Id]),
	CONSTRAINT [FK_Synonyms_Word2] FOREIGN KEY ([Word2Id]) REFERENCES [Dictionary].[Word]([Id]), 
    CONSTRAINT [CK_Synonyms_Word1Id] CHECK ([Word1Id] != [Word2Id]),
	CONSTRAINT [CK_Synonyms_Word2Id] CHECK ([Word2Id] != [Word1Id])
)
