using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace VKR.EF.Entities
{
    public class Team
    {
        public string TeamAbbreviation { get; set; }
        public string TeamCity { get; set; }
        public string TeamName { get; set; }
        public Division Division { get; set; }
        public int DivisionId { get; set; }
        public Manager Manager { get; set; }
        public uint? TeamManager { get; set; }
        public ushort FoundationYear { get; set; }
        public virtual List<TeamColor> TeamColors { get; set; } = new();
        public virtual List<PlayerInTeam> PlayersInTeam { get; set; } = new();
        public virtual List<Match> AwayMatches { get; set; } = new();
        public virtual List<Match> HomeMatches { get; set; } = new();
        public virtual List<TeamStadiumForTypeOfMatch> StadiumsForMatchTypes { get; set; } = new();
        public virtual List<MatchFromSchedule> NextAwayMatches { get; set; } = new();
        public virtual List<MatchFromSchedule> NextHomeMatches { get; set; } = new();
        public virtual List<MatchResult> MatchWinners { get; set; } = new();
        public virtual List<MatchResult> MatchLosers { get; set; } = new();
        public TeamRating TeamRating { get; set; }

        public int HomeWins;
        public int HomeLosses;
        public int AwayWins;
        public int AwayLosses;

        public int Wins => HomeWins + AwayWins;
        public int Losses => HomeLosses + AwayLosses;
        public double Pct => Wins + Losses == 0 ? 0 : Math.Round(Wins / (double)(Wins + Losses), 3);

        public string HomeBalance => $"{HomeWins}-{HomeLosses}";
        public string AwayBalance => $"{AwayWins}-{AwayLosses}";

        public double GamesBehind;
        private int Streak;
        public string StreakString => Streak > 0 ? $"Won {Streak}" : $"Lost {Math.Abs(Streak)}";

        public int RunsScored;
        public int RunsAllowed;
        public int RunDifferential => RunsScored - RunsAllowed;

        public Color TeamColorForThisMatch;
        public List<Pitcher> PitchersPlayedInMatch = new();
        public Pitcher CurrentPitcher => PitchersPlayedInMatch.Last();


        public List<Batter> BattingLineup = new();

        public TeamBattingStats BattingStats;
        public TeamPitchingStats PitchingStats;

        public Team SetTeamBalance(TeamBalance balance)
        {
            HomeWins = balance.HomeWins;
            HomeLosses = balance.HomeLosses;
            AwayWins = balance.AwayWins;
            AwayLosses = balance.AwayLosses;
            return this;
        }

        public Team SetTeamStreak(int streak)
        {
            Streak = streak;
            return this;
        }

        public Team SetRunsByTeam(RunsByTeam run)
        {
            RunsScored = run.RunsScored;
            RunsAllowed = run.RunsAllowed;
            return this;
        }

        public Team SetBattingStats(TeamBattingStats stats)
        {
            BattingStats = stats;
            return this;
        }

        public Team SetPitchingStats(TeamPitchingStats stats)
        {
            PitchingStats = stats;
            return this;
        }
    }
}