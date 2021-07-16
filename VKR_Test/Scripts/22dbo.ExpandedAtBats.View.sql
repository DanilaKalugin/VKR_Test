CREATE VIEW [dbo].[ExpandedAtBats]
AS
SELECT        dbo.AtBats.AtBatID, dbo.AtBats.Match, B.TeamID AS Offense, B.PlayerID AS Batter, dbo.AtBats.AtBatResult, P.TeamID AS Defense, P.PlayerID AS Pitcher, dbo.AtBats.Outs, dbo.AtBats.RBI
FROM            dbo.AtBats INNER JOIN
                         dbo.PlayersInTeams AS B ON B.PlayerInTeamID = dbo.AtBats.Batter INNER JOIN
                         dbo.PlayersInTeams AS P ON P.PlayerInTeamID = dbo.AtBats.Pitcher

