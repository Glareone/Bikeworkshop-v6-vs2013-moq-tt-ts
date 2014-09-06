CREATE PROCEDURE usp_GetAllUsers
AS
SELECT
u.UserID,u.Username
FROM [dbo].[User] AS u

SELECT
u.UserID,ur.RoleID,r.RoleName
FROM [dbo].[Role] AS r
JOIN [dbo].[UserRole] AS ur ON ur.RoleID=r.RoleID
JOIN [dbo].[User] AS u ON ur.UserID=u.UserID

SELECT
u.UserID,ur.RoleID,p.Permissionname 
FROM [dbo].[Permission] AS p
JOIN [dbo].[PermissionRole] AS pr ON pr.PermissionID=p.PermissionID
JOIN [dbo].[Role] AS r ON r.RoleID=pr.RoleID
JOIN [dbo].[UserRole] AS ur ON ur.RoleID=r.RoleID
JOIN [dbo].[User] AS u ON u.UserID=ur.UserID