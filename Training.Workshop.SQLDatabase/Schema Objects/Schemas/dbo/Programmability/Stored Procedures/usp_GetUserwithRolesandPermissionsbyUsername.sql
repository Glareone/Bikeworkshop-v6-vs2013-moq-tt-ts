CREATE PROCEDURE usp_GetUserwithRolesandPermissionsbyUsername (@username nvarchar(50))
AS
SELECT
U.Username, R.RoleName, P.Permissionname 
FROM [dbo].[User] AS U
JOIN [dbo].[UserRole] AS UR ON UR.UserID=U.UserID
JOIN [dbo].[Role] AS R ON R.RoleID=UR.RoleID
JOIN [dbo].[PermissionRole] AS PR ON PR.RoleID=R.RoleID
JOIN [dbo].[Permission] AS P ON P.PermissionID=PR.PermissionID
WHERE U.Username=@username

