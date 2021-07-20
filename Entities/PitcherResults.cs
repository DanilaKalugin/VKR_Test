namespace Entities
{
    public class PitcherResults
    {
        public enum MatchResultForPitcher { NoDecision, Win, Loss, Save, Hold }
        public int Pitcher;
        public string Team;
        public int Match;
        public bool IsQualityStart;
        public bool IsCompleteGame;
        public bool IsShutout;
        public MatchResultForPitcher matchResult;

        public PitcherResults(int Pitcher, string Team, int Match)
        {
            this.Pitcher = Pitcher;
            this.Team = Team;
            this.Match = Match;
            IsQualityStart = false;
            IsCompleteGame = false;
            IsShutout = false; 
            matchResult = MatchResultForPitcher.NoDecision;
        }
    }
}