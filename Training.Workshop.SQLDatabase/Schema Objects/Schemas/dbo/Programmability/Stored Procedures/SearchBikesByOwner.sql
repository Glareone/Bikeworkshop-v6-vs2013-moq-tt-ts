CREATE PROCEDURE SearchBikesByOwner (@Username nvarchar(50)					
									 
									)
AS
SELECT
Manufacturer,Mark,OwnerID,BikeYear,ConditionState
FROM [Bike]
WHERE OwnerID=
(
 SELECT I.UserID
 FROM [User] AS I
 WHERE I.Username=@Username
)