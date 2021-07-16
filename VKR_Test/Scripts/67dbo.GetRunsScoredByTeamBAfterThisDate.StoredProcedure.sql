CREATE PROCEDURE [dbo].[GetRunsScoredByTeamBAfterThisDate]
(
@Date date,
@Team nvarchar(3)
)
AS
SELECT COUNT(CASE WHEN AtBatResult = 13 THEN 1 ELSE NULL END) AS RS
FROM            dbo.PlayersInTeams LEFT OUTER JOIN
                dbo.AtBats ON dbo.PlayersInTeams.PlayerInTeamID = dbo.AtBats.Batter
				INNER JOIN Matches On MatchID = Match

WHERE TeamID = @Team And MatchDate <= @Date
