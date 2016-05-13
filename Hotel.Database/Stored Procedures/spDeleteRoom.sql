CREATE PROCEDURE [dbo].[spDeleteRoom]
	@Id int
AS
	DELETE FROM Room
	WHERE Id = @Id
RETURN 0
