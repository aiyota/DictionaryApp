/*
    e.g. 'General', 'Usage'
*/
CREATE TABLE [Dictionary].[WordNoteCategory]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(100) NOT NULL, 
    CONSTRAINT [UQ_NoteCategory_Name] UNIQUE ([Name])
)
