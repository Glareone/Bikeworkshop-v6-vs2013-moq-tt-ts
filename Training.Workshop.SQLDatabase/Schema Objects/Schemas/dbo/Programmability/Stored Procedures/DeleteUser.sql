CREATE PROCEDURE DeleteUser (@Username nvarchar(50))
AS
BEGIN
DELETE FROM [User]
WHERE
 [Username]=@Username
END