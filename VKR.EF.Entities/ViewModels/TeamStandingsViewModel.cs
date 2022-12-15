using System;

namespace VKR.EF.Entities
{
    public class TeamStandingsViewModel: Team
    {
        public double Pct => Wins + Losses == 0 ? 0 : Math.Round(Wins / (double)(Wins + Losses), 3);
        public string HomeBalance => $"{HomeWins}-{HomeLosses}";
        public string AwayBalance => $"{AwayWins}-{AwayLosses}";

        private int _streak;
        public string StreakString => _streak > 0 ? $"Won {_streak}" : $"Lost {Math.Abs(_streak)}";

        public double GamesBehind;

        public int RunsScored;
        public int RunsAllowed;

        public int RunDifferential => RunsScored - RunsAllowed;
        public TeamStandingsViewModel SetTeamStreak(int streak)
        {
            _streak = streak;
            return this;
        }

        public TeamStandingsViewModel(Team team, RunsByTeam run)
        {
            TeamAbbreviation = team.TeamAbbreviation;
            TeamCity = team.TeamCity;
            TeamName = team.TeamName;

            Division = team.Division;

            HomeWins = team.HomeWins;
            HomeLosses = team.HomeLosses;
            AwayWins = team.AwayWins;
            AwayLosses = team.AwayLosses;

            RunsScored = run.RunsScored;
            RunsAllowed = run.RunsAllowed;
        }
    }
}