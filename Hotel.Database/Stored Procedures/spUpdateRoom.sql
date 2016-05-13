CREATE PROCEDURE [dbo].[spUpdateRoom]
	@Id int,
	@Number int,
	@Type varchar(50),
	@Price decimal(18, 2)
AS
	UPDATE Room
	SET Number = @Number,
		Type = @Type,
		Price = @Price
	WHERE Id = @Id
RETURN 0
