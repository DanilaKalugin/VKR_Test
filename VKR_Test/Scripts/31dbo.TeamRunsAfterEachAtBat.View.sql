CREATE VIEW [dbo].[TeamRunsAfterEachAtBat] 
AS
SELECT TOP 100 Percent t1.Match, t1.AtBatID, (SELECT ISNULL(SUM(t2.RBI), 0) 
								FROM ExpandedAtBats AS t2 
								WHERE t2.AtBatID <= t1.AtBatID AND t2.Match = t1.Match AND t2.Offense = AwayTeam) AS AwayTeamRuns,
							(SELECT ISNULL(SUM(t2.RBI), 0) 
								FROM ExpandedAtBats AS t2 
								WHERE t2.AtBatID <= t1.AtBatID AND t2.Match = t1.Match AND t2.Offense = HomeTeam) AS HomeTeamRuns
FROM ExpandedAtBats As T1 Inner JOIN Matches ON t1.Match = MatchID
Group BY t1.AtBatID, t1.Match, AwayTeam, HomeTeam
ORDER BY t1.AtBatID

