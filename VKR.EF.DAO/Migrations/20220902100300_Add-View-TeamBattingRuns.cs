using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddViewTeamBattingRuns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE VIEW TeamBattingRunsGroupedBySeasonAndMatchType AS
SELECT        TeamAbbreviation, m1.MatchType, m1.Season, COUNT(CASE WHEN m1.Season = matches.Season AND m1.MatchType = dbo.Matches.MatchType THEN 1 ELSE NULL END) AS R
FROM            dbo.CombinationsOfYearAndMatchType AS m1 CROSS JOIN
                         dbo.Teams LEFT OUTER JOIN
                         dbo.PlayersInTeams ON TeamAbbreviation = TeamId LEFT OUTER JOIN
                         dbo.Runs ON dbo.Runs.Runner = dbo.PlayersInTeams.PlayerInTeamID LEFT OUTER JOIN
                         dbo.Matches ON dbo.Matches.MatchID = dbo.Runs.Match
GROUP BY TeamAbbreviation, m1.MatchType, m1.Season");

            migrationBuilder.Sql(@"DROP VIEW RunsScoredByTeamSeasonAndMatchType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"DROP VIEW TeamBattingRunsGroupedBySeasonAndMatchType");

            migrationBuilder.Sql(@"CREATE VIEW RunsScoredByTeamSeasonAndMatchType AS
SELECT        dbo.Teams.TeamAbbreviation, m1.MatchType, m1.Season, COUNT(CASE WHEN AtBatResult = 13 AND m1.Season = Year(matchDate) THEN 1 ELSE NULL END) AS RS
FROM            dbo.Teams CROSS JOIN
                         dbo.CombinationsOfYearAndMatchType AS m1 LEFT OUTER JOIN
                         dbo.ExpandedAtBats ON dbo.ExpandedAtBats.Offense = dbo.Teams.TeamAbbreviation LEFT OUTER JOIN
                         dbo.Matches ON dbo.Matches.MatchID = dbo.ExpandedAtBats.Match AND m1.MatchType = dbo.Matches.MatchType
GROUP BY dbo.Teams.TeamAbbreviation, m1.MatchType, m1.Season");
        }
    }
}
