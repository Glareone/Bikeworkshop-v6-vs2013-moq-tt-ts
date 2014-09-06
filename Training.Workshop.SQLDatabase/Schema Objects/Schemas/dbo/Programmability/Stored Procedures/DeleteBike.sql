CREATE PROCEDURE DeleteBike (@ownerID int,
							 @mark nvarchar(50))
AS
BEGIN
DELETE FROM [Bike]
WHERE
 [OwnerID]=@ownerID AND
 [Mark]=mark
END