-- =============================================
-- Author:		Aaron Y.
-- Create date: 12/4/2022
-- Description:	Delete a user by ID.
-- =============================================
CREATE PROCEDURE [Auth].[spUser_Delete]
	@Id nvarchar(36)
AS
BEGIN
	DELETE FROM [Auth].[User]
	WHERE [Id] = @Id
END