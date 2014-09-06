CREATE TABLE [PermissionRole]
(
	PermissionRolesID int NOT NULL PRIMARY KEY IDENTITY(1,1), 
	RoleID int NOT NULL,
	PermissionID int NOT NULL
)
