CREATE PROCEDURE [dbo].[spDeleteCustomer]
	@Id int
AS
	DELETE FROM Customer
	WHERE Id = @Id
RETURN 0
