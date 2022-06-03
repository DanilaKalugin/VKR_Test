using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

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
    }
}