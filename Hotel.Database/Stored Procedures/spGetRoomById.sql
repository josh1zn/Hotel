CREATE PROCEDURE [dbo].[spGetRoomById]
	@Id int
AS
	SELECT * FROM Room
	WHERE Id = @Id
RETURN 0
