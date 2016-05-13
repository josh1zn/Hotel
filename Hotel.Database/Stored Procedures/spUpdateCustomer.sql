CREATE PROCEDURE [dbo].[spUpdateCustomer]
	@Id int = 0,
	@Name varchar(50),
	@Surname varchar(50)
AS
	UPDATE Customer
	SET Name	= @Name,
		Surname = @Surname
	WHERE Id = @Id
RETURN 0
