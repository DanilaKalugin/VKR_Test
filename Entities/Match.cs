using System.Collections.Generic;

namespace Entities
{
    public class Match
    {
        public int MatchID;
        public Team HomeTeam;
        public Team AwayTeam;
        public Stadium stadium;
        public bool DHRule;
        public List<GameSituation> gameSituations;
        public List<AtBat> atBats;

        public Match(int _id, Team _homeTeam, Team _awayTeam, Stadium _stadium, bool _dh)
        {
            MatchID = _id;
            HomeTeam = _homeTeam;
            AwayTeam = _awayTeam;
            stadium = _stadium;
            DHRule = _dh;
            gameSituations = new List<GameSituation>
            {
                new GameSituation(AwayTeam)
            };
            atBats = new List<AtBat>();
        }
    }
}