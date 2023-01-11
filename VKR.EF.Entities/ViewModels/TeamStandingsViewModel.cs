using System;
using VKR.EF.Entities.Tables;
using VKR.EF.Entities.Views;

namespace VKR.EF.Entities.ViewModels
{
    public class TeamStandingsViewModel
    {
        public string TeamAbbreviation { get; set; }
        public string TeamName { get; set; }
        public string TeamCity { get; set; }
        public string DivisionName { get; set; }
        public string LeagueName { get; set; }

        public int HomeWins;
        public int HomeLosses;
        public int AwayWins;
        public int AwayLosses;

        public int Wins => HomeWins + AwayWins;
        public int Losses => HomeLosses + AwayLosses;

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

        public TeamStandingsViewModel(TeamHistoricalName teamName, Team team)
        {
            TeamAbbreviation = teamName.TeamAbbreviation;
            TeamCity = teamName.TeamRegion;
            TeamName = teamName.TeamName;

            DivisionName = team.Division.DivisionTitle;
            LeagueName = team.Division.LeagueId;
        }

        public TeamStandingsViewModel SetTeamBalance(TeamBalance balance)
        {
            HomeWins = balance.HomeWins;
            HomeLosses = balance.HomeLosses;
            AwayWins = balance.AwayWins;
            AwayLosses = balance.AwayLosses;
            return this;
        }

        public TeamStandingsViewModel SetTeamRuns(RunsByTeam run)
        {
            RunsScored = run.RunsScored;
            RunsAllowed = run.RunsAllowed;
            return this;
        }
    }
}