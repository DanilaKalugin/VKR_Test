CREATE PROCEDURE [dbo].[GetResultsForAllMatches]
AS
SELECT MatchID, AwayTeam, AwayRuns, HomeRuns, HomeTeam, Stadium, Winner, InningNumber, MatchDate
FROM MatchResults
