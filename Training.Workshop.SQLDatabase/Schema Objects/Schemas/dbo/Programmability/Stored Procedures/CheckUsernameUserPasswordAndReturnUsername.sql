CREATE PROCEDURE CheckPasswordAndReturnUsername (
			@username nvarchar(50),		
			@enteredpassword nvarchar(50),
			@correctusername nvarchar(50) OUTPUT)
AS
SELECT 
@correctusername=Username
FROM [User]
WHERE UserPassword=@enteredpassword
	AND Username=@username