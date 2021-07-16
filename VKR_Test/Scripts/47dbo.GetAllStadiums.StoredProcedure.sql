CREATE PROCEDURE [dbo].[GetAllStadiums]
AS
SELECT StadiumID, StadiumTitle, CityName + ', ' + Country As Location, StadiumCapacity, StadiumDistanceToCenterField
FROM Stadiums Inner JOIN Cities ON StadiumLocation = CityID

