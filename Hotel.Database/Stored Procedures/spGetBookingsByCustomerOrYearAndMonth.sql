CREATE PROCEDURE [dbo].[spGetBookingsByCustomerOrYearAndMonth]
	@CustomerId int,
	@Month int = 0,
	@Year int = 0
AS
	SELECT	b.* ,
			(SELECT Name + ' ' + Surname FROM Customer WHERE Id = CustomerId) AS 'CustomerName',
			(SELECT Number FROM Room WHERE Id = RoomId) AS 'RoomNumber',
			(SELECT [Type] FROM Room WHERE Id = RoomId) AS 'RoomType'
	FROM Booking b
	WHERE
	(
		@Month		= 0				AND
		@Year		= 0				AND
		@CustomerId = CustomerId
	)
	OR
	(
		@Month      > 0								AND
		@Year		> 0								AND
		@CustomerId = CustomerId					AND
		@Month		= DATEPART(month, StartDate)	AND
		@Year		= DATEPART(year, StartDate)
	)
RETURN 0
