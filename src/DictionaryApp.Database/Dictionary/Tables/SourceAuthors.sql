CREATE TABLE [Dictionary].[SourceAuthors]
(
	[SourceId] INT NOT NULL, 
    [AuthorId] INT NOT NULL,
	CONSTRAINT [PK_SourceAuthors] PRIMARY KEY ([SourceId], [AuthorId]), 
    CONSTRAINT [FK_SourceAuthors_Source] FOREIGN KEY ([SourceId]) REFERENCES [Dictionary].[Source]([Id]),
	CONSTRAINT [FK_SourceAuthors_Author] FOREIGN KEY ([AuthorId]) REFERENCES [Dictionary].[Author]([Id])
)
