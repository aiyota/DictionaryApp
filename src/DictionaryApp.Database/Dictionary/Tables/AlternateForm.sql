/*
    Alernate spellings
*/
CREATE TABLE [Dictionary].[AlternateForm]
(
	[Id] INT NOT NULL PRIMARY KEY, 
	[WordId] INT NOT NULL, 
    [Text] NVARCHAR(100) NOT NULL, 
    CONSTRAINT [FK_AlternateForm_Word] FOREIGN KEY ([WordId]) REFERENCES [Dictionary].[Word]([Id]), 
    CONSTRAINT [UQ_AlternateForm_TextWordId] UNIQUE ([Text], [WordId])
)
