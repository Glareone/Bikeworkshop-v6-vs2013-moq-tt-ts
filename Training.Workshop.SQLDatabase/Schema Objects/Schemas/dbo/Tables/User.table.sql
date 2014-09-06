CREATE TABLE [User]
(
	UserID			int NOT NULL PRIMARY KEY IDENTITY(1,1), 
	Username		nvarchar(50) NOT NULL,
	UserPassword	nvarchar(250)  NOT NULL,
	Salt			nvarchar(15) NOT NULL,
)
