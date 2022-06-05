using Microsoft.EntityFrameworkCore.Migrations;

namespace VKR.EF.DAO.Migrations
{
    public partial class CreatedFirstView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE VIEW PeopleWithBirthdayToday 
AS
select  Players.PlayerID, PlayerFirstName, PlayerSecondName, PlayerNumber, CityName + ', ' + Region As PlaceOfBirth, PlayerDateOfBirth, PlayersInTeams.TeamID
from Players Inner Join PlayersInTeams On Players.PlayerID = PlayersInTeams.PlayerID
		     INNER JOIN Cities On PlaceOfBirth = CityID
	WHERE DAY(PlayerDateOfBirth) = DAY(GETDATE()) AND MONTH(PlayerDateOfBirth) = MONTH(GETDATE()) AND InTeamStatus != 0
UNION
SELECT Players.PlayerID, PlayerFirstName, PlayerSecondName, PlayerNumber, CityName + ', ' + Region As PlaceOfBirth, PlayerDateOfBirth, ''
    FROM Players INNER JOIN Cities On PlaceOfBirth = CityID
	WHERE DAY(PlayerDateOfBirth) = DAY(GETDATE()) AND MONTH(PlayerDateOfBirth) = MONTH(GETDATE()) AND CurrentPlayerStatus = 2
UNION
SELECT ManagerID, ManagerFirstName, ManagerSecondName, 0, CityName + ', ' + Region As PlaceOfBirth, ManagerDateOfBirth, TeamAbbreviation
    FROM Managers INNER JOIN Teams On TeamManager = ManagerID
				  INNER JOIN Cities On ManagerPlaceOfBirth = CityID
	WHERE DAY(ManagerDateOfBirth) = DAY(GETDATE()) AND MONTH(ManagerDateOfBirth) = MONTH(GETDATE())"
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("drop view PeopleWithBirthdayToday");
        }
    }
}
