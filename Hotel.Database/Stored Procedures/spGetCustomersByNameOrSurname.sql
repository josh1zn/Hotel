CREATE PROCEDURE [dbo].[spGetCustomersByNameOrSurname]
	@Name varchar(50) = NULL
AS	
	select * from Customer
	where	Name + ' ' + Surname LIKE ISNULL(@Name, '')	+ '%' 
RETURN 0