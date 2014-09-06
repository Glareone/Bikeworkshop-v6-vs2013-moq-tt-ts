CREATE PROCEDURE RetrieveRolesbyUsername	( @Username nvarchar(50),
											  @RoleName nvarchar(50) OUTPUT
											)
AS
SELECT
RoleName
FROM
[Role]
WHERE RoleID IN
(
	SELECT
	RoleID
	FROM [UserRole]
	WHERE UserID=
	(
		SELECT
		A.UserID
		FROM [User] as A
		WHERE A.Username=@Username
	)
)