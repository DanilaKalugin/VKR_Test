using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class AddedViewExpandedAtBats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE VIEW ExpandedAtBats
AS
SELECT        dbo.AtBats.AtBatID, dbo.AtBats.Match, B.TeamID AS Offense, B.PlayerID AS Batter, dbo.AtBats.AtBatResult, P.TeamID AS Defense, P.PlayerID AS Pitcher, dbo.AtBats.Outs, dbo.AtBats.RBI, dbo.AtBats.Inning
FROM            dbo.AtBats INNER JOIN
                         dbo.PlayersInTeams AS B ON B.PlayerInTeamID = dbo.AtBats.Batter INNER JOIN
                         dbo.PlayersInTeams AS P ON P.PlayerInTeamID = dbo.AtBats.Pitcher"
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop view ExpandedAtBats");
        }
    }
}
