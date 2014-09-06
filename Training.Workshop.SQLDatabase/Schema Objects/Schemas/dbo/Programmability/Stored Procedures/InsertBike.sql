CREATE PROCEDURE InsertBike (@Manufacturer nvarchar(30),@Mark nvarchar(50),@BikeYear date,@OwnerID int,@ConditionState nvarchar(50))
AS
BEGIN
INSERT INTO [Bike]
(
 [Manufacturer] ,
 [Mark] ,
 [BikeYear]  ,
 [OwnerID] ,
 [ConditionState]  
)
VALUES
(
 @Manufacturer,
 @Mark,
 @BikeYear,
 @OwnerID,
 @ConditionState
)
END