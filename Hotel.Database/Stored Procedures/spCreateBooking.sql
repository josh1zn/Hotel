CREATE PROCEDURE [dbo].[spCreateBooking]
	@CustomerId int,
	@RoomId int,
	@StartDate datetime,
	@EndDate datetime,
	@TotalCost decimal(18,2)
AS
	INSERT INTO Booking(CustomerId, RoomId, StartDate, EndDate, TotalCost)
	VALUES(@CustomerId, @RoomId, @StartDate, @EndDate, @TotalCost)
	SELECT SCOPE_IDENTITY() AS Id
