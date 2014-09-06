CREATE PROCEDURE usp_RetrievePermissionbyRolename (	@Rolename nvarchar(50)
				  							  )
AS 
SELECT
P.Permissionname
FROM [dbo].[Permission] p
JOIN [PermissionRole] AS PR ON P.PermissionID=PR.PermissionID
JOIN [Role] AS R ON R.RoleID=PR.RoleID
WHERE R.RoleName = @Rolename


/*
SELECT
Permissionname
FROM [Permission]
WHERE Permission.PermissionID IN
(
	SELECT E.PermissionID
	FROM  [PermissionRole] as E
	WHERE E.RoleID IN
	(
		SELECT A.RoleID
		FROM [Role] AS A
		WHERE A.RoleName=@Rolename
	)
)
*/