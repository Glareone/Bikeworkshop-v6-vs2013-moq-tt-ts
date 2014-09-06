CREATE PROCEDURE UpdateBikeCondition (
									  @manufacturer nvarchar(30),
									  @mark nvarchar(50),
									  @ownerID int,
									  @condition nvarchar(50),
									  @newcondition nvarchar(50)
									 )
AS
UPDATE TOP (1)
[Bike]
SET ConditionState=@newcondition
WHERE Manufacturer=@manufacturer AND Mark=@mark AND OwnerID=@ownerID AND ConditionState=@condition