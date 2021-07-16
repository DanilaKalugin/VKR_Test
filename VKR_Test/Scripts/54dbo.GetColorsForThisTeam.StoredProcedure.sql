CREATE PROCEDURE [dbo].[GetColorsForThisTeam]
(
@Team nvarchar(3)
)
AS
SELECT RedComponent, GreenComponent, BlueComponent
FROM TeamColors
WHERE Team = @Team
