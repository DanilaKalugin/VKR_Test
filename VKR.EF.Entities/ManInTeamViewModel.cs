using System.Drawing;

namespace VKR.EF.Entities
{
    public class ManInTeamViewModel : ManInTeam
    {
        public Color? TeamColor { get; set; }

        public ManInTeamViewModel(ManInTeam manInTeam, Color teamColor)
        {
            FirstName = manInTeam.FirstName;
            SecondName = manInTeam.SecondName;
            DateOfBirth = manInTeam.DateOfBirth;
            TeamName = manInTeam.TeamName;
            TeamColor = teamColor;
        }
    }
}