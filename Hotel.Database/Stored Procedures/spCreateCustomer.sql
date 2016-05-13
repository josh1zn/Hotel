CREATE PROCEDURE [dbo].[spCreateCustomer]
	@Name varchar(50),
	@Surname varchar(50)
AS
	INSERT INTO Customer(Name, Surname) VALUES(@Name, @Surname)
	SELECT SCOPE_IDENTITY() AS "Id"
RETURN 0
