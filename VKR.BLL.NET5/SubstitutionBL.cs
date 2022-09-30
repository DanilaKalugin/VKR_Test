using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VKR.EF.DAO;
using VKR.EF.Entities;

namespace VKR.BLL.NET5
{
    public class SubstitutionBL
    {
        private readonly SubstitutionEFDAO _substitutionDao = new();
        private readonly PlayerEFDAO _playerEFDAO = new();

        public async Task<List<Pitcher>> GetAvailablePitchers(Match match, Team team)
        {
            var pitchersList = await _substitutionDao.GetAvailablePitchers(match, team)
                .ConfigureAwait(false);

            var pitchers = pitchersList.ToList();
            foreach (var pitcher in pitchers)
                pitcher.RemainingStamina = await _playerEFDAO.GetPitcherStamina(pitcher.Id, match.MatchDate);
            return pitchers;
        }

        public async Task<List<Batter>> GetAvailableBatters(Match match, Team team, Batter batter) => await _substitutionDao.GetAvailableBatters(match, team, batter)
            .ConfigureAwait(false);

        public async Task SubstitutePitcher(Match match, Pitcher pitcher) =>
            await _substitutionDao.SubstitutePitcher(match, pitcher)
                .ConfigureAwait(false);

        public async Task SubstituteBatter(Match match, Batter batter) =>
            await _substitutionDao.SubstituteBatter(match, batter)
                .ConfigureAwait(false);
    }
}