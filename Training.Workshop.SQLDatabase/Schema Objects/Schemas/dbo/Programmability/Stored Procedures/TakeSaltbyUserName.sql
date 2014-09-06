CREATE PROCEDURE TakeSaltbyUserName (
			@username nvarchar(50),		
			@salt nvarchar(15)			OUTPUT)
AS
SELECT 
@salt=Salt
FROM [User]
WHERE Username=@username