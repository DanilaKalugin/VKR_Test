using VKR.EF.Entities.Tables;
using VKR.EF.Entities.Views;

namespace VKR.EF.Entities.ViewModels
{
    public class TeamStatsViewModel: Team
    {
        public TeamBattingStats BattingStats;
        public TeamPitchingStats PitchingStats;

        private TeamStatsViewModel(Team team)
        {
            TeamAbbreviation = team.TeamAbbreviation;
            TeamCity = team.TeamCity;
            TeamName = team.TeamName;
        }

        public TeamStatsViewModel(Team team, TeamBattingStats stats): this(team) => 
            BattingStats = stats;

        public TeamStatsViewModel(Team team, TeamPitchingStats stats): this(team) => 
            PitchingStats = stats;
    }
}