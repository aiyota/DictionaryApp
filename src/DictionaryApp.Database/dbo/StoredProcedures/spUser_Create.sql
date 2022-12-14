-- =============================================
-- Author:		Aaron Y.
-- Create date: 12/4/2022
-- Description:	Creates a new user.
-- =============================================
CREATE PROCEDURE [dbo].[spUser_Create]
	 @UserName nvarchar(100)
	,@FirstName nvarchar(100)
	,@LastName nvarchar(100)
	,@Email nvarchar(255)
	,@PasswordHash nvarchar(MAX)
AS
BEGIN
	DECLARE @Id uniqueidentifier = NEWID()
	INSERT INTO [dbo].[User]
	(
		 [Id]
		,[UserName]
		,[FirstName]
		,[LastName]
		,[Email]
		,[PasswordHash]
	) VALUES (
		 @Id
		,@UserName
		,@FirstName
		,@LastName
		,@Email
		,@PasswordHash
	);
	
	EXEC spUser_Get @Id, NULL;
END