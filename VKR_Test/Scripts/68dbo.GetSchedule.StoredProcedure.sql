CREATE PROCEDURE [dbo].[GetSchedule]
AS
SELECT MatchID, AwayTeam, HomeTeam, TeamStadium, MatchDate
FROM NextMatches INNER JOIN Teams ON HomeTeam = TeamAbbreviation
WHERE IsPlayed = 0

