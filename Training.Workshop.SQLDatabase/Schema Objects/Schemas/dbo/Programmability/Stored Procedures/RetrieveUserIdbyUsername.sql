CREATE PROCEDURE RetrieveUserIdbyUsername  (@username nvarchar(50),
											@userID INT OUTPUT
											)
AS
SELECT @userID=UserID
FROM [User] 
WHERE [User].Username=@username