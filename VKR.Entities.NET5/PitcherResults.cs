namespace Entities.NET5
{
    public class PitcherResults
    {
        public enum MatchResultForPitcher { NoDecision, Win, Loss, Save, Hold }
        public int Pitcher;
        public string Team;
        public int Match;
        public bool IsQualityStart = false;
        public bool IsCompleteGame = false;
        public bool IsShutout = false;
        public MatchResultForPitcher MatchResult = MatchResultForPitcher.NoDecision;

        public PitcherResults(int pitcher, string team, int match)
        {
            Pitcher = pitcher;
            Team = team;
            Match = match;
        }
    }
}