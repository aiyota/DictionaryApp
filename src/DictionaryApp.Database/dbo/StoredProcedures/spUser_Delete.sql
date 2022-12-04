-- =============================================
-- Author:		Aaron Y.
-- Create date: 12/4/2022
-- Description:	Delete a user by ID.
-- =============================================
CREATE PROCEDURE [dbo].[spUser_Delete]
	@Id nvarchar(36)
AS
BEGIN
	DELETE FROM [dbo].[User]
	WHERE [Id] = @Id
END