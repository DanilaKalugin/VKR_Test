﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VKR.EF.DAO;
using VKR.EF.Entities.Enums;
using VKR.EF.Entities.Tables;
using VKR.EF.Entities.ViewModels;
using VKR.EF.Entities.Views;

namespace VKR.BLL.NET5
{
    public class PlayerBL
    {
        private readonly PlayerEFDAO _playerDao = new();
        private readonly PlayerPositionsEFDAO _positionsDao = new();

        public async Task<Player> GetPlayerByCode(uint code) => 
            await _playerDao.GetPlayerByCode(code)
                .ConfigureAwait(false);

        public async Task<List<Batter>> GetCurrentLineupForThisMatch(Team team, Match match)
        {
            var lineup = await _playerDao.GetCurrentBattingLineup(team, match)
                .ConfigureAwait(false);
            return lineup.ToList();
        }

        public async Task UpdateStatsForThisPitcher(Pitcher pitcher, Match match)
        {
            pitcher.PitchingStats = await GetPitchingStatsByCode(pitcher.Id, match.MatchDate.Year, match.MatchTypeId)
                .ConfigureAwait(false);

            pitcher.RemainingStamina = await _playerDao.GetPitcherStamina(pitcher.Id, match.MatchDate)
                .ConfigureAwait(false);
        }

        public async Task<Pitcher> GetStartingPitcherForThisTeam(Team team, Match match)
        {
            var pitcher = await _playerDao.GetStartingPitcherForThisTeam(match, team)
                .ConfigureAwait(false);

            pitcher.PitchingStats = await GetPitchingStatsByCode(pitcher.Id, match.MatchDate.Year, match.MatchTypeId)
                .ConfigureAwait(false);

            pitcher.RemainingStamina = await _playerDao.GetPitcherStamina(pitcher.Id, match.MatchDate)
                .ConfigureAwait(false);

            return pitcher;
        }

        public async Task<int> GetPitcherStamina(Pitcher pitcher, Match match) => 
            await _playerDao.GetPitcherStamina(pitcher.Id, match.MatchDate)
                .ConfigureAwait(false);

        public async Task<PlayerBattingStats> GetBattingStatsByCode(uint id, int year) => 
            await _playerDao.GetBattingStatsByCode(id, year)
                .ConfigureAwait(false);

        public async Task<PlayerPitchingStats> GetPitchingStatsByCode(uint id, int year, TypeOfMatchEnum matchType = TypeOfMatchEnum.RegularSeason) =>
            await _playerDao.GetPitchingStatsByCode(id, year, matchType)
                .ConfigureAwait(false);

        public async Task UpdatePlayer(Player player)
        {
            await _playerDao.UpdatePlayer(player)
                .ConfigureAwait(false);

            await _positionsDao.DeleteAllPositionsForPlayer(player)
                .ConfigureAwait(false);

            await _positionsDao.FillPlayerPositionsForPlayer(player)
                .ConfigureAwait(false);
        }

        public async Task AddPlayer(Player player)
        {
            await _playerDao.AddPlayer(player)
                .ConfigureAwait(false);

            await _positionsDao.FillPlayerPositionsForPlayer(player)
                .ConfigureAwait(false);
        }

        public async Task<uint> GetIdForNewPlayer() => 
            await _playerDao.GetIdForNewPlayer()
                .ConfigureAwait(false);

        public async Task SetNewNumberForPlayerAsync(Player player, byte newNumber)
        {
            await _playerDao.SetNewNumberForPlayerAsync(player, newNumber)
                .ConfigureAwait(false);
        }
    }
}