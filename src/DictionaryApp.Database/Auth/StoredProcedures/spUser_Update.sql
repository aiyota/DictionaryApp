-- =============================================
-- Author:		Aaron Y.
-- Create date: 12/4/2022
-- Description:	Will patch a record. @Id is required, everything else 
--				is optional. Will update whatever optional data you pass in.
-- =============================================
CREATE PROCEDURE [Auth].[spUser_Update]
	 @UserName nvarchar(100)
	,@Id nvarchar(36)
	,@FirstName nvarchar(100) = NULL
	,@LastName nvarchar(100) = NULL
	,@Email nvarchar(255) = NULL
	,@PasswordHash nvarchar(MAX) = NULL
	,@EmailConfirmed bit = NULL
AS
BEGIN
	UPDATE [Auth].[User]
	SET
		 [UserName] = ISNULL(@UserName, [UserName])
		,[FirstName] = ISNULL(@FirstName, [FirstName])
		,[LastName] = ISNULL(@LastName, [LastName])
		,[Email] = ISNULL(@Email, [Email])
		,[PasswordHash] = ISNULL(@PasswordHash, [PasswordHash])
		,[EmailConfirmed] = ISNULL(@EmailConfirmed, [EmailConfirmed])
		,[DateModified] = GETDATE()
	WHERE [Id] = @Id

	EXEC [Auth].[spUser_Get] @Id, NULL;
END
