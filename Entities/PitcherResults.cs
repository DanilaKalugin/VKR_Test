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
        public bool IsWin;
        public bool IsLoss;
        public bool IsSave;
        public bool IsHold;
        public bool IsNoDecision;

        public PitcherResults(int Pitcher, string Team, int Match, bool _QS, bool _cg, bool _sho, bool _w, bool _l)
        {
            this.Pitcher = Pitcher;
            this.Team = Team;
            this.Match = Match;
            IsQualityStart = _QS;
            IsCompleteGame = _cg;
            IsShutout = _sho;
            IsWin = _w;
            IsLoss = _l;
        }

        public PitcherResults(int Pitcher, string Team, int Match)
        {
            this.Pitcher = Pitcher;
            this.Team = Team;
            this.Match = Match;
            IsQualityStart = false;
            IsCompleteGame = false;
            IsShutout = false;
            IsWin = false;
            IsLoss = false;

        }
    }
}