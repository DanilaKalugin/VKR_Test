using System.Collections.Generic;
using System.Linq;
using VKR.EF.DAO;
using VKR.EF.Entities;

namespace VKR.BLL.NET5
{
    public class PlayerMovesBL
    {
        private readonly PlayerMovesDAO playerMovesDAO = new();

        public void MovePlayerToNewTeam(Player player, Team team) => playerMovesDAO.MovePlayerToNewTeam(player, team);

        public List<PlayerInLineupViewModel> GetAllPlayers()
        {
            var players = playerMovesDAO.GetAllPlayers();
            return players.OrderBy(pit => pit.SecondName).ThenBy(pit => pit.FirstName).ToList();
        }
    }
}