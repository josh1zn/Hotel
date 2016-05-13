CREATE PROCEDURE [dbo].[spGetCustomerById]
	@Id int
AS
	SELECT * FROM Customer
	WHERE Id = @Id
RETURN 0
