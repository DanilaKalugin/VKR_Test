using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using VKR.EF.Entities.ViewModels;
using VKR.EF.Entities.Views;

namespace VKR.EF.Entities.Tables
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
        public virtual List<RetiredNumber> RetiredNumbers { get; set; } = new();
        public virtual List<TeamHistoricalName> HistoricalNames { get; set; } = new();
        public TeamRating TeamRating { get; set; }

        public int HomeWins;
        public int HomeLosses;
        public int AwayWins;
        public int AwayLosses;

        public int Wins => HomeWins + AwayWins;
        public int Losses => HomeLosses + AwayLosses;

        public Color TeamColorForThisMatch;
        public List<Pitcher> PitchersPlayedInMatch = new();
        public Pitcher CurrentPitcher => PitchersPlayedInMatch.Last();

        public List<Batter> BattingLineup = new();

        public string FullTeamName => $"{TeamCity} {TeamName}";


        public Team SetTeamBalance(TeamBalance balance)
        {
            HomeWins = balance.HomeWins;
            HomeLosses = balance.HomeLosses;
            AwayWins = balance.AwayWins;
            AwayLosses = balance.AwayLosses;
            return this;
        }
    }
}