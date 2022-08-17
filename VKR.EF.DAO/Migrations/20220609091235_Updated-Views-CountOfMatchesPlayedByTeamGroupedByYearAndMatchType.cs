using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class UpdatedViewsCountOfMatchesPlayedByTeamGroupedByYearAndMatchType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"ALTER VIEW CountOfMatchesPlayedByTeam
AS
SELECT        dbo.Teams.TeamAbbreviation, m1.MatchType, m1.Season, COUNT(dbo.Matches.MatchID) AS TGP
FROM            dbo.Teams CROSS JOIN dbo.CombinationsOfYearAndMatchType m1
						  LEFT JOIN dbo.Matches ON (dbo.Teams.TeamAbbreviation = dbo.Matches.HomeTeam OR dbo.Teams.TeamAbbreviation = dbo.Matches.AwayTeam) 
													AND m1.MatchType = Matches.MatchType
													AND m1.Season = Year(MatchDate)
GROUP BY dbo.Teams.TeamAbbreviation, m1.MatchType, m1.Season"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"ALTER VIEW CountOfMatchesPlayedByTeam
AS
SELECT        dbo.Teams.TeamAbbreviation, MatchType, YEAR(MatchDate) As Season, COUNT(dbo.Matches.MatchID) AS TGP
FROM             dbo.Teams INNER JOIN
                        dbo.Matches ON dbo.Teams.TeamAbbreviation = dbo.Matches.HomeTeam OR dbo.Teams.TeamAbbreviation = dbo.Matches.AwayTeam
GROUP BY  dbo.Teams.TeamAbbreviation, MatchType, YEAR(MatchDate)"
            );
        }
    }
}
