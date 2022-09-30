using System.Threading.Tasks;
using VKR.EF.DAO;
using VKR.EF.Entities;

namespace VKR.BLL.NET5
{
    public class PlayerMovesBL
    {
        private readonly PlayerMovesDAO _playerMovesDao = new();

        public async Task MovePlayerToNewTeam(Player player, Team team) => 
            await _playerMovesDao.MovePlayerToNewTeam(player, team)
                .ConfigureAwait(false);
        
        public async Task ChangePlayerInTeamStatus(Player player, Team team, InTeamStatusEnum inTeamStatus) =>
            await _playerMovesDao.ChangePlayerInTeamStatus(player, team, inTeamStatus)
                .ConfigureAwait(false);

        public async Task ReleasePlayer(PlayerInLineupViewModel player) => 
            await _playerMovesDao.ReleasePlayer(player)
            .ConfigureAwait(false);

        public async Task RemoveFromStartingLineup(Player player, Team team, byte lineupNumber) =>
            await _playerMovesDao.RemovePlayerFromStartingLineup(player, team, lineupNumber)
                .ConfigureAwait(false);

        public async Task AssignPlayerToStartingLineup(Player player, Team team, byte lineupNumber, PlayerPosition position, byte numberInLineup) =>
            await _playerMovesDao.AssignPlayerToStartingLineup(player, team, lineupNumber, position, numberInLineup)
                .ConfigureAwait(false);
    }
}