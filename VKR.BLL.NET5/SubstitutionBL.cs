using System.Collections.Generic;
using System.Linq;
using VKR.EF.DAO;
using VKR.EF.Entities;

namespace VKR.BLL.NET5
{
    public class SubstitutionBL
    {
        private readonly SubstitutionEFDAO _substitutionDao = new();
        private readonly PlayerEFDAO _playerEFDAO = new();

        public List<Pitcher> GetAvailablePitchers(Match match, Team team)
        {
            var pitchers = _substitutionDao.GetAvailablePitchers(match, team).ToList();
            foreach (var pitcher in pitchers)
                pitcher.RemainingStamina = _playerEFDAO.GetPitcherStamina(pitcher.Id, match.MatchDate);
            return pitchers;
        }

        public List<Batter> GetAvailableBatters(Match match, Team team, Batter batter) => _substitutionDao.GetAvailableBatters(match, team, batter).ToList();

        public void SubstitutePitcher(Match match, Pitcher pitcher) => _substitutionDao.SubstitutePitcher(match, pitcher);

        public void SubstituteBatter(Match match, Batter batter) => _substitutionDao.SubstituteBatter(match, batter);
    }
}