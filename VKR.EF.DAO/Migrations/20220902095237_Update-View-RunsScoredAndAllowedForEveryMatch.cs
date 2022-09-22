using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class UpdateViewRunsScoredAndAllowedForEveryMatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER VIEW RunsScoredAndAllowedForEveryMatch AS
SELECT        AwayTeam AS Team, MatchDate, MatchType, Season, AwayTeamRuns AS RunsScored, HomeTeamRuns AS RunsAllowed
FROM            ResultsOfMatches INNER JOIN
                         Matches ON Matches.MatchID = ResultsOfMatches.MatchId
UNION
SELECT        HomeTeam, MatchDate, MatchType, Season, HomeTeamRuns, AwayTeamRuns
FROM            ResultsOfMatches INNER JOIN
                         Matches ON Matches.MatchID = ResultsOfMatches.MatchId
UNION
SELECT        MatchResults.AwayTeam AS Team, MatchResults.MatchDate, MatchResults.MatchType, matches.Season, AwayRuns AS RunsScored, HomeRuns AS RunsAllowed
FROM            MatchResults INNER JOIN
                         Matches ON Matches.MatchID = MatchResults.MatchId
WHERE        MatchEnded = 0
UNION
SELECT        MatchResults.HomeTeam AS Team, MatchResults.MatchDate, MatchResults.MatchType, matches.Season, HomeRuns AS RunsScored, AwayRuns AS RunsAllowed
FROM            MatchResults INNER JOIN
                         Matches ON Matches.MatchID = MatchResults.MatchId
WHERE        MatchEnded = 0
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"ALTER VIEW RunsScoredAndAllowedForEveryMatch AS
SELECT        AwayTeam AS Team, MatchDate, MatchType, AwayTeamRuns AS RunsScored, HomeTeamRuns AS RunsAllowed
FROM            ResultsOfMatches INNER JOIN
                         Matches ON Matches.MatchID = ResultsOfMatches.MatchId
UNION
SELECT        HomeTeam, MatchDate, MatchType, HomeTeamRuns, AwayTeamRuns
FROM            ResultsOfMatches INNER JOIN
                         Matches ON Matches.MatchID = ResultsOfMatches.MatchId
UNION
SELECT        MatchResults.AwayTeam AS Team, MatchResults.MatchDate, MatchResults.MatchType, AwayRuns AS RunsScored, HomeRuns AS RunsAllowed
FROM            MatchResults INNER JOIN
                         Matches ON Matches.MatchID = MatchResults.MatchId
WHERE        MatchEnded = 0
UNION
SELECT        MatchResults.HomeTeam AS Team, MatchResults.MatchDate, MatchResults.MatchType, HomeRuns AS RunsScored, AwayRuns AS RunsAllowed
FROM            MatchResults INNER JOIN
                         Matches ON Matches.MatchID = MatchResults.MatchId
WHERE        MatchEnded = 0
");
        }
    }
}
