using System.Linq;

namespace VKR.EF.Entities.Tables
{
    public class Run
    {
        public long Id { get; set; }
        public Match Match { get; set; }
        public int MatchId { get; set; }
        public PlayerInTeam Runner { get; set; }
        public uint RunnerId { get; set; }
        public bool IsEarned { get; set; }
        public PlayerInTeam Pitcher { get; set; }
        public uint PitcherId { get; set; }
        public byte Inning { get; set; }

        public string Offense;
        public string Defense;

        public Run()
        {
            
        }

        public Run(Runner runner, Match currentMatch)
        {
            MatchId = currentMatch.Id;
            Offense = currentMatch.GameSituations.Last().Offense.TeamAbbreviation;
            Defense = currentMatch.GameSituations.Last().Offense == currentMatch.AwayTeam ? currentMatch.HomeTeam.TeamAbbreviation : currentMatch.AwayTeam.TeamAbbreviation;
            RunnerId = runner.RunnerId;
            PitcherId = runner.PitcherId;
            Inning = currentMatch.GameSituations.Last().InningNumber;
            IsEarned = runner.IsEarnedRun;
        }
    }
}