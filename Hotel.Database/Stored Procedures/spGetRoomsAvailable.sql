CREATE PROCEDURE [dbo].[spGetRoomsAvailable]
	@StartDate datetime,
	@EndDate datetime
AS
	SELECT * FROM Room
	WHERE Id NOT IN 
	(
		SELECT	RoomId FROM Booking
		WHERE	(@StartDate	>= StartDate AND @StartDate	<= EndDate	) 
				OR
				(@EndDate	>= StartDate AND @StartDate <= StartDate)
				
	)
RETURN 0
