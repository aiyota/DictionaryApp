CREATE TABLE [Dictionary].[WordNote]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [WordId] INT NOT NULL, 
    [Title] NVARCHAR(100) NOT NULL, 
    [Text] NVARCHAR(MAX) NOT NULL, 
    [CategoryId] INT NOT NULL DEFAULT 1, 
    CONSTRAINT [FK_WordNote_Word] FOREIGN KEY ([WordId]) REFERENCES [Dictionary].[Word]([Id]), 
    CONSTRAINT [FK_WordNote_WordNoteCategory] FOREIGN KEY ([CategoryId]) REFERENCES [Dictionary].[WordNoteCategory]([Id])
)
