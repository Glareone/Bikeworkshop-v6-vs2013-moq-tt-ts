CREATE PROCEDURE InputintoUserRole  (
									 @Username nvarchar(50),
									 @Rolename nvarchar(50)
									)
AS
INSERT INTO [UserRole]
 SELECT u.UserID, r.RoleID
 FROM [User] AS u,  [Role] AS r
 WHERE u.Username=@Username
 AND r.RoleName=@Rolename


 
 
