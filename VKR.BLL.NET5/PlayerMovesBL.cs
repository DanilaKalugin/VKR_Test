using System.Collections.Generic;
using System.Linq;
using VKR.EF.DAO;
using VKR.EF.Entities;

namespace VKR.BLL.NET5
{
    public class PlayerMovesBL
    {
        private readonly PlayerMovesDAO _playerMovesDao = new();

        public void MovePlayerToNewTeam(Player player, Team team) => _playerMovesDao.MovePlayerToNewTeam(player, team);
        
        public void ChangePlayerInTeamStatus(Player player, Team team, InTeamStatusEnum inTeamStatus) =>
            _playerMovesDao.ChangePlayerInTeamStatus(player, team, inTeamStatus);

        public void ReleasePlayer(PlayerInLineupViewModel player) => _playerMovesDao.ReleasePlayer(player);

        public void RemoveFromStartingLineup(Player player, Team team, byte lineupNumber) =>
            _playerMovesDao.RemovePlayerFromStartingLineup(player, team, lineupNumber);

        public void AssignPlayerToStartingLineup(Player player, Team team, byte lineupNumber, PlayerPosition position, byte numberInLineup) =>
            _playerMovesDao.AssignPlayerToStartingLineup(player, team, lineupNumber, position, numberInLineup);
    }
}