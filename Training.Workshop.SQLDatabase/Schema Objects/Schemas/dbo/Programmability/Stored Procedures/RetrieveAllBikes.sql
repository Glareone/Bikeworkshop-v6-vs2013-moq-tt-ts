CREATE PROCEDURE RetrieveAllBikes 
AS
SELECT
Manufacturer,Mark,OwnerID,BikeYear,ConditionState
FROM
[Bike] 