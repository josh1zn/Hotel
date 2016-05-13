CREATE PROCEDURE [dbo].[spCreateRoom]
	@Number int,
	@Type varchar(50),
	@Price decimal(18,2)
AS
	INSERT INTO Room(Number, [Type], Price) VALUES(@Number, @Type, @Price)
RETURN 0
