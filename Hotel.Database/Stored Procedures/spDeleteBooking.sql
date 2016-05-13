CREATE PROCEDURE [dbo].[spDeleteBooking]
	@Id int
AS
	DELETE FROM Booking
	WHERE Id = @Id
RETURN 0
