CREATE TABLE [Dictionary].[Antonyms]
(
	[Word1Id] INT NOT NULL, 
    [Word2Id] INT NOT NULL,
	CONSTRAINT PK_Antonyms PRIMARY KEY ([Word1Id], [Word2Id]), 
    CONSTRAINT [FK_Antonyms_Word1] FOREIGN KEY ([Word1Id]) REFERENCES [Dictionary].[Word]([Id]),
	CONSTRAINT [FK_Antonyms_Word2] FOREIGN KEY ([Word2Id]) REFERENCES [Dictionary].[Word]([Id]), 
    CONSTRAINT [CK_Antonyms_Word1Id] CHECK ([Word1Id] != [Word2Id]),
	CONSTRAINT [CK_Antonyms_Word2Id] CHECK ([Word2Id] != [Word1Id])
)
