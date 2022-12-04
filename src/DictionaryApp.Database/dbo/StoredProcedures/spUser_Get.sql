-- =============================================
-- Author:		Aaron Y.
-- Create date: 12/4/2022
-- Description:	Gets user(s) by ID or Email. If nothing is passed 
--				into this args, it will return all users.
-- =============================================
CREATE PROCEDURE [dbo].[spUser_Get]
	 @Id nvarchar(36) = NULL
	,@UserName nvarchar(255) = NULL
	,@Email nvarchar(255) = NULL
AS
BEGIN
	SELECT 
		 [Id]
		,[UserName]
		,[FirstName]
		,[LastName]
		,[Email]
		,[PasswordHash]
		,[EmailConfirmed]
		,[DateJoined]
		,[DateModified]
	FROM [dbo].[User]
	WHERE 
		(@Id IS NULL OR [Id] = @Id)
		AND
		(@UserName IS NULL OR [UserName] = @UserName)
		AND
		(@Email IS NULL OR [Email] = @Email)
END
