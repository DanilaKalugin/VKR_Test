using System.Collections.Generic;
using System.Linq;
using VKR.EF.DAO;
using VKR.EF.Entities;

namespace VKR.BLL.NET5
{
    public class PlayerBL
    {
        private readonly PlayerEFDAO _playerEFDAO = new();

        public Player GetPlayerByCode(uint code) => _playerEFDAO.GetPlayerByCode(code);

        public List<Batter> GetCurrentLineupForThisMatch(Team team, Match match) => _playerEFDAO.GetCurrentBattingLineup(team, match).ToList();

        public void UpdateStatsForThisPitcher(Pitcher pitcher, Match match)
        {
            pitcher.PitchingStats = GetPitchingStatsByCode(pitcher.Id, match.MatchDate.Year, match.MatchTypeId);
            pitcher.RemainingStamina = _playerEFDAO.GetPitcherStamina(pitcher.Id, match.MatchDate);
        }

        public Pitcher GetStartingPitcherForThisTeam(Team team, Match match)
        {
            var pitcher = _playerEFDAO.GetStartingPitcherForThisTeam(match, team);
            pitcher.PitchingStats = GetPitchingStatsByCode(pitcher.Id, match.MatchDate.Year, match.MatchTypeId);
            pitcher.RemainingStamina = _playerEFDAO.GetPitcherStamina(pitcher.Id, match.MatchDate);
            return pitcher;
        }

        public int GetPitcherStamina(Pitcher pitcher, Match match) => _playerEFDAO.GetPitcherStamina(pitcher.Id, match.MatchDate);

        public PlayerBattingStats GetBattingStatsByCode(uint id, int year) => _playerEFDAO.GetBattingStatsByCode(id, year);

        public PlayerPitchingStats GetPitchingStatsByCode(uint id, int year, TypeOfMatchEnum matchType = TypeOfMatchEnum.RegularSeason) =>
            _playerEFDAO.GetPitchingStatsByCode(id, year, matchType);
    }
}