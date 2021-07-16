CREATE PROCEDURE [dbo].[GetManagerForThisTeam]
(
@Team nvarchar(3)
)
AS
SELECT ManagerID, ManagerFirstName, ManagerSecondName, CityName + ', ' + Country AS PlaceOfBirth, ManagerDateOfBirth
FROM (Managers INNER JOIN Teams ON TeamManager = ManagerID)
			   INNER JOIN Cities On ManagerPlaceOfBirth = CityID
WHERE TeamAbbreviation = @Team

