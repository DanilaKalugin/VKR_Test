using System.Collections.Generic;
using System.Linq;
using VKR.DAL;
using Entities;

namespace VKR.BLL
{
    public class PlayerBL
    {
        private readonly PlayerDAO playerDAO;

        public PlayerBL()
        {
            playerDAO = new PlayerDAO();
        }

        public List<Batter> GetBattersStats()
        {
            return playerDAO.GetBattersStats().Where(player => (player.PA / (double)player.TGP) >= 3.1).OrderByDescending(batter => batter.AVG).ToList();
        }

        public List<Pitcher> GetPitchersStats()
        {
            return playerDAO.GetPitchersStats().Where(player => (player.IP / player.TGP) >= 1.1).OrderBy(player => player.ERA).ToList();
        }

        public List<List<List<PlayerInLineup>>> GetLineups()
        {
            List<PlayerInLineup> ungroupedPlayers = playerDAO.GetStartingLineups().ToList();
            for (int i = 0; i < ungroupedPlayers.Count; i++)
            {
                ungroupedPlayers[i].PlayerPositions = playerDAO.GetPositionsForThisPlayer(ungroupedPlayers[i].id).ToList();
            }
            List<string> Teams = ungroupedPlayers.Select(player => player.Team).Distinct().ToList();
            List<int> Lineups = ungroupedPlayers.Select(player => player.LineupType).Distinct().ToList();

            List<List<List<PlayerInLineup>>> groupedPlayers = new List<List<List<PlayerInLineup>>>();
            for (int i = 0; i < Teams.Count; i++)
            {
                groupedPlayers.Add(new List<List<PlayerInLineup>>());
                for (int j = 0; j < Lineups.Count; j++)
                {
                    groupedPlayers[i].Add(ungroupedPlayers.Where(player => player.Team == Teams[i] && player.LineupType == Lineups[j]).OrderBy(player => player.NumberInLineup).ToList());
                }
            }
            return groupedPlayers;
        }

        public List<List<List<PlayerInLineup>>> GetBench()
        {
            List<PlayerInLineup> ungroupedPlayers = playerDAO.GetBench().ToList();
            for (int i = 0; i < ungroupedPlayers.Count; i++)
            {
                ungroupedPlayers[i].PlayerPositions = playerDAO.GetPositionsForThisPlayer(ungroupedPlayers[i].id).ToList();
            }
            List<string> Teams = ungroupedPlayers.Select(player => player.Team).Distinct().ToList();
            List<int> Lineups = ungroupedPlayers.Select(player => player.LineupType).OrderBy(number => number).Distinct().ToList();

            List<List<List<PlayerInLineup>>> groupedPlayers = new List<List<List<PlayerInLineup>>>();
            for (int i = 0; i < Teams.Count; i++)
            {
                groupedPlayers.Add(new List<List<PlayerInLineup>>());
                for (int j = 0; j < Lineups.Count; j++)
                {
                    groupedPlayers[i].Add(ungroupedPlayers.Where(player => player.Team == Teams[i] && player.LineupType == Lineups[j]).OrderBy(player => player.NumberInLineup).ToList());
                }
            }
            return groupedPlayers;
        }

        public string GetPlayerNameByID(int code)
        {
            Player PlayerByCode = playerDAO.GetPlayerNameByID(code).First();
            return $"{PlayerByCode.FirstName[0]}. {PlayerByCode.SecondName}";
        }

        public Batter GetBatterByCode(int code)
        {
            return playerDAO.GetBatterByCode(code).First();
        }

        public Pitcher GetPitcherByCode(int code)
        {
            return playerDAO.GetPitcherByCode(code).First();
        }

    }
}