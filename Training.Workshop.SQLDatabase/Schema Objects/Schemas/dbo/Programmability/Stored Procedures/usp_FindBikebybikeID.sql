CREATE PROCEDURE usp_FindBikebybikeID	(@bikeID INT,
										@manufacturer nvarchar(30)	OUTPUT,
										@mark nvarchar(50)			OUTPUT,
										@bikeyear datetime			OUTPUT,
										@ownerid INT				OUTPUT,
										@conditionstate nvarchar(50)OUTPUT
										)
AS
SELECT 
@manufacturer=b.Manufacturer,
@mark=b.Mark,
@bikeyear=b.BikeYear,
@ownerid=b.OwnerID,
@conditionstate=b.ConditionState
FROM [dbo].[Bike] AS b
WHERE b.BikeID=@bikeID
