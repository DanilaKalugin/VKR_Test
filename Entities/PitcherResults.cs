namespace Entities
{
    public class PitcherResults
    {
        public int Pitcher;
        public string Team;
        public int Match;
        public bool IsQualityStart;
        public bool IsCompleteGame;
        public bool IsShutout;

        public PitcherResults(int Pitcher, string Team, int Match, bool _QS, bool _cg, bool _sho)
        {
            this.Pitcher = Pitcher;
            this.Team = Team;
            this.Match = Match;
            IsQualityStart = _QS;
            IsCompleteGame = _cg;
            IsShutout = _sho;
        }
    }
}