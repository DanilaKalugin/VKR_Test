using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VKR.EF.DAO;
using VKR.EF.Entities;

namespace VKR.BLL.NET5
{
    public class PlayerBL
    {
        private readonly PlayerEFDAO _playerEFDAO = new();
        private readonly PlayerPositionsEFDAO _positionsDao = new();

        public async Task<Player> GetPlayerByCode(uint code) => await _playerEFDAO.GetPlayerByCode(code)
            .ConfigureAwait(false);

        public async Task<List<Batter>> GetCurrentLineupForThisMatch(Team team, Match match)
        {
            var lineup = await _playerEFDAO.GetCurrentBattingLineup(team, match).ConfigureAwait(false);
            return lineup.ToList();
        }

        public async Task UpdateStatsForThisPitcher(Pitcher pitcher, Match match)
        {
            pitcher.PitchingStats = await GetPitchingStatsByCode(pitcher.Id, match.MatchDate.Year, match.MatchTypeId);
            pitcher.RemainingStamina = await _playerEFDAO.GetPitcherStamina(pitcher.Id, match.MatchDate);
        }

        public async Task<Pitcher> GetStartingPitcherForThisTeam(Team team, Match match)
        {
            var pitcher = await _playerEFDAO.GetStartingPitcherForThisTeam(match, team);
            pitcher.PitchingStats = await GetPitchingStatsByCode(pitcher.Id, match.MatchDate.Year, match.MatchTypeId);
            pitcher.RemainingStamina = await _playerEFDAO.GetPitcherStamina(pitcher.Id, match.MatchDate);
            return pitcher;
        }

        public async Task<int> GetPitcherStamina(Pitcher pitcher, Match match) => await _playerEFDAO.GetPitcherStamina(pitcher.Id, match.MatchDate);

        public async Task<PlayerBattingStats> GetBattingStatsByCode(uint id, int year) => await _playerEFDAO.GetBattingStatsByCode(id, year);

        public async Task<PlayerPitchingStats> GetPitchingStatsByCode(uint id, int year, TypeOfMatchEnum matchType = TypeOfMatchEnum.RegularSeason) =>
            await _playerEFDAO.GetPitchingStatsByCode(id, year, matchType);

        public async Task UpdatePlayer(Player player)
        {
            await _playerEFDAO.UpdatePlayer(player);
            await _positionsDao.DeleteAllPositionsForPlayer(player);
            await _positionsDao.FillPlayerPositionsForPlayer(player);
        }

        public async Task AddPlayer(Player player)
        {
            await _playerEFDAO.AddPlayer(player);
            await _positionsDao.FillPlayerPositionsForPlayer(player);
        }

        public async Task<uint> GetIdForNewPlayer() => await _playerEFDAO.GetIdForNewPlayer().ConfigureAwait(false);
    }
}