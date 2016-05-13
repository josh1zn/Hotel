CREATE PROCEDURE [dbo].[spGetBookingsByCustomerOrDate]
	@Date date,
	@CustomerId int = 0
AS
	SELECT	b.* ,
			(SELECT Name + ' ' + Surname FROM Customer WHERE Id = CustomerId) AS 'CustomerName',
			(SELECT Number FROM Room WHERE Id = RoomId) AS 'RoomNumber',
			(SELECT [Type] FROM Room WHERE Id = RoomId) AS 'RoomType'
	FROM Booking b
	WHERE
	(
		@CustomerId = 0							AND
		@Date		= CONVERT(date, StartDate)
	)
	OR
	(
		@CustomerId > 0							AND
		@CustomerId = CustomerId				AND
		@Date		= CONVERT(date, StartDate)
	)
RETURN 0
