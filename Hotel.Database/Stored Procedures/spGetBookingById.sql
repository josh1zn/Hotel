CREATE PROCEDURE [dbo].[spGetBookingById]
	@Id int
AS
	SELECT	b.* ,
			(SELECT Name + ' ' + Surname FROM Customer WHERE Id = CustomerId) AS 'CustomerName',
			(SELECT Number FROM Room WHERE Id = RoomId) AS 'RoomNumber',
			(SELECT [Type] FROM Room WHERE Id = RoomId) AS 'RoomType'
	FROM Booking b
	WHERE Id = @Id
RETURN 0
