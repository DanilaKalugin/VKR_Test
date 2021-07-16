CREATE PROCEDURE [dbo].[GetRunsAllowedByTeamBAfterThisDate]
(
@Date date,
@Team nvarchar(3)
)
AS
SELECT COUNT(CASE WHEN AtBatResult = 13 THEN 1 ELSE NULL END) AS RS
FROM            dbo.PlayersInTeams LEFT OUTER JOIN
                dbo.AtBats ON dbo.PlayersInTeams.PlayerInTeamID = dbo.AtBats.Pitcher
				INNER JOIN Matches On MatchID = Match
WHERE TeamID = @Team And MatchDate <= @Date
