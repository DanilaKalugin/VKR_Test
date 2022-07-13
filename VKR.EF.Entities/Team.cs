using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public ushort StrikeZoneProbability { get; set; }
        public ushort HitByPitchProbability { get; set; }
        public byte SwingInStrikeZoneProbability { get; set; }
        public byte SwingOutsideStrikeZoneProbability { get; set; }
        public ushort HittingProbability { get; set; }
        public ushort FoulProbability { get; set; }
        public ushort SingleProbability { get; set; }
        public ushort DoubleProbability { get; set; }
        public ushort HomeRunProbability { get; set; }
        public ushort TripleProbability { get; set; }
        public ushort PopoutOnFoulProbability { get; set; }
        public ushort FlyoutOnHomeRunProbability { get; set; }
        public ushort GroundoutProbability { get; set; }
        public ushort FlyoutProbability { get; set; }
        public byte DoublePlayProbability { get; set; }
        public byte SacrificeFlyProbability { get; set; }
        public ushort StealingBaseProbability { get; set; }
        public byte SuccessfulStealingBaseAttemptProbability { get; set; }
        public ushort SuccessfulBuntAttemptProbability { get; set; }
        public Manager Manager { get; set; }
        public uint TeamManager { get; set; }
        public virtual List<TeamColor> TeamColors { get; set; } = new();
        public virtual List<PlayerInTeam> PlayersInTeam { get; set; } = new();
        public virtual List<Match> AwayMatches { get; set; } = new();
        public virtual List<Match> HomeMatches { get; set; } = new();
        public virtual List<TeamStadiumForTypeOfMatch> StadiumsForMatchTypes { get; set; } = new();
        public virtual List<MatchFromSchedule> NextAwayMatches { get; set; } = new();
        public virtual List<MatchFromSchedule> NextHomeMatches { get; set; } = new();
        public virtual List<MatchResult> MatchWinners { get; set; } = new();
        public virtual List<MatchResult> MatchLosers { get; set; } = new();
        
        public int NormalizedOffensiveRating;
        public int NormalizedDefensiveRating;

        public int OverallRating => (NormalizedDefensiveRating + NormalizedOffensiveRating) / 2;

        public double DefensiveRating()
        {
            var pitchingComponent = (double)(1600 - StrikeZoneProbability - (3000 - HitByPitchProbability)) / 36;
            var groundoutComponent = GroundoutProbability * 1.1 / 20;
            var outfieldComponent = (double)(FlyoutProbability - GroundoutProbability) / 20;
            var doublePlayComponent = (double)DoublePlayProbability / 3;
            var pitcherNumber = (Wins + Losses) % 4 == 0 ? 1 : 6 - (Wins + Losses + 1) % 5;
            var pitcherNumberComponent = (double)pitcherNumber / 2;
            return Math.Round(pitchingComponent + groundoutComponent + outfieldComponent + doublePlayComponent + pitcherNumberComponent, 2);
        }

        public double OffensiveRating()
        {
            var fullHittingProbability = (double)(2000 - HittingProbability) / 2000;
            var fullSingleProbability = (double)SingleProbability / 2000;
            var fullDoubleProbability = (double)DoubleProbability / 2000;
            var fullHrProbability = (double)HomeRunProbability / 2000;
            var fullTripleProbability = (double)TripleProbability / 2000;

            var doubleComponent = fullHittingProbability * fullDoubleProbability * 75;
            var homeRunComponent = fullHittingProbability * fullHrProbability * 225;
            var tripleComponent = fullHittingProbability * fullTripleProbability * 150;
            var singleComponent = fullHittingProbability * fullSingleProbability * 50;

            var baseStealingComponent = (double)(StealingBaseProbability * SuccessfulStealingBaseAttemptProbability) / 8000;
            return Math.Round(singleComponent + doubleComponent + homeRunComponent + tripleComponent + baseStealingComponent, 2);
        }

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
        public int Streak;
        public string StreakString => Streak > 0 ? $"Won {Streak}" : $"Lost {Math.Abs(Streak)}";

        public int RunsScored;
        public int RunsAllowed;
        public int RunDifferential => RunsScored - RunsAllowed;

        public Team(Team team, TeamBalance balance)
        {
            TeamAbbreviation = team.TeamAbbreviation;
            TeamCity = team.TeamCity;
            TeamName = team.TeamName;
            StrikeZoneProbability = team.StrikeZoneProbability;
            SwingInStrikeZoneProbability = team.SwingInStrikeZoneProbability;
            SwingOutsideStrikeZoneProbability = team.SwingOutsideStrikeZoneProbability;
            HittingProbability = team.HittingProbability;
            FoulProbability = team.FoulProbability;
            SingleProbability = team.SingleProbability;
            DoubleProbability = team.DoubleProbability;
            HomeRunProbability = team.HomeRunProbability;
            PopoutOnFoulProbability = team.PopoutOnFoulProbability;
            FlyoutOnHomeRunProbability = team.FlyoutOnHomeRunProbability;
            GroundoutProbability = team.GroundoutProbability;
            FlyoutProbability = team.FlyoutProbability;
            DoublePlayProbability = team.DoublePlayProbability;
            SacrificeFlyProbability = team.SacrificeFlyProbability;
            SuccessfulStealingBaseAttemptProbability = team.SuccessfulStealingBaseAttemptProbability;
            SuccessfulBuntAttemptProbability = team.SuccessfulBuntAttemptProbability;
            HitByPitchProbability = team.HitByPitchProbability;
            StealingBaseProbability = team.StealingBaseProbability;
            TripleProbability = team.TripleProbability;
            HomeWins = balance.HomeWins;
            HomeLosses = balance.HomeLosses;
            AwayWins = balance.AwayWins;
            AwayLosses = balance.AwayLosses;
            Manager = team.Manager;
            Division = team.Division;
            TeamColors = team.TeamColors.ToList();
        }

        public Team(Team team, TeamBalance balance, int streak) : this(team, balance)
        {
            Streak = streak;
        }

        public Team()
        {
            
        }
    }
}