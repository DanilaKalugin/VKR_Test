using System;
using System.Collections.Generic;
using System.Linq;

namespace VKR.EF.Entities
{
    public class Match : MatchBaseClass
    {
        public bool DHRule { get; set; }
        public byte MatchLength { get; set; }
        public bool MatchEnded { get; set; }
        public Stadium Stadium { get; set; }
        public ushort StadiumId { get; set; }
        public virtual List<LineupForMatch> LineupsForMatches { get; set; } = new();
        public virtual List<AtBat> AtBats { get; set; } = new();
        public virtual List<PitcherResults> PitcherResults { get; set; } = new();
        public virtual List<Run> Runs { get; set; } = new();

        public List<GameSituation> GameSituations = new();
        public Match() { }

        public Match(DateTime matchDate, TypeOfMatchEnum typeOfMatch)
        {
            MatchDate = matchDate;
            MatchTypeId = typeOfMatch;
        }

        public bool IsQuickMatch => MatchTypeId == TypeOfMatchEnum.QuickMatch;

        public MatchResult MatchResult { get; set; }

        public bool MatchEndingCondition
        {
            get
            {
                var lastGs = GameSituations.Last();
                return (lastGs.Offense == AwayTeam && lastGs.Outs == 3 && lastGs.AwayTeamRuns < lastGs.HomeTeamRuns && lastGs.InningNumber == MatchLength) ||
                       (lastGs.Offense == HomeTeam && lastGs.Outs == 3 && lastGs.AwayTeamRuns > lastGs.HomeTeamRuns && lastGs.InningNumber >= MatchLength) ||
                       (lastGs.Offense == HomeTeam && lastGs.AwayTeamRuns < lastGs.HomeTeamRuns && lastGs.InningNumber >= MatchLength);
            }
        }


        public List<string> GetMatchLeaderAfterEachPitch()
        {
            var leaderAfterEachAtBat = new List<string>();
            foreach (var gameSituation in GameSituations)
                if (gameSituation.AwayTeamRuns > gameSituation.HomeTeamRuns)
                    leaderAfterEachAtBat.Add(AwayTeam.TeamAbbreviation);
                else if (gameSituation.AwayTeamRuns < gameSituation.HomeTeamRuns)
                    leaderAfterEachAtBat.Add(HomeTeam.TeamAbbreviation);
                else leaderAfterEachAtBat.Add("");
            return leaderAfterEachAtBat;
        }
    }
}