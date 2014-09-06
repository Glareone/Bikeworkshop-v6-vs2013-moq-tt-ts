CREATE PROCEDURE DeletefromUserRole (
										@Username nvarchar(50)
									)
AS
DELETE P 
FROM [UserRole] P
INNER JOIN [User] ON [User].UserID = P.UserID
	WHERE [User].Username=@Username 



/*
DELETE FROM [UserRole] 
WHERE UserID=
(
	SELECT 
	A.UserID
	FROM
	[User] AS A
	WHERE
	A.Username=@Username
)
*/