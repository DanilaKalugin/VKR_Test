using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddViewRunsScoredAndAllowedForEveryMatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW RunsScoredAndAllowedForEveryMatch AS
select AwayTeam As Team, MatchDate, MatchType, AwayTeamRuns As RunsScored, HomeTeamRuns As RunsAllowed
            from ResultsOfMatches INNER JOIN Matches On Matches.MatchID = ResultsOfMatches.MatchId
            UNION
            SELECT HomeTeam, MatchDate, MatchType, HomeTeamRuns, AwayTeamRuns
            From ResultsOfMatches INNER JOIN Matches On Matches.MatchID = ResultsOfMatches.MatchId
            UNION
                SELECT MatchResults.AwayTeam As Team, MatchResults.MatchDate, MatchResults.MatchType, AwayRuns As RunsScored, HomeRuns As RunsAllowed
            from MatchResults INNER JOIN Matches On Matches.MatchID = MatchResults.MatchId
            Where MatchEnded = 0
            UNION
                SELECT MatchResults.HomeTeam As Team, MatchResults.MatchDate, MatchResults.MatchType, HomeRuns As RunsScored, AwayRuns As RunsAllowed
            from MatchResults INNER JOIN Matches On Matches.MatchID = MatchResults.MatchId
            Where MatchEnded = 0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW RunsScoredAndAllowedForEveryMatch");
        }
    }
}
