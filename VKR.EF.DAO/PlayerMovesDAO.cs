using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VKR.EF.DAO.Contexts;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class PlayerMovesDAO
    {
        public async Task MovePlayerToNewTeam(Player player, Team team)
        {
            await using var db = new VKRApplicationContext();

            var pit = await db.PlayersInTeams.FirstOrDefaultAsync(pit => pit.PlayerId == player.Id &&
                                                              pit.TeamId == team.TeamAbbreviation)
                .ConfigureAwait(false);

            var playerInCurrentTeam = await db.PlayersInTeams.Where(p => p.PlayerId == player.Id)
                .ToListAsync()
                .ConfigureAwait(false);

            foreach (var playerInTeam in playerInCurrentTeam)
            {
                playerInTeam.CurrentPlayerInTeamStatus = InTeamStatusEnum.NotInThisTeam;
                db.PlayersInTeams.Update(playerInTeam);
            }

            if (pit == null)
            {
                var maxId = await db.PlayersInTeams.MaxAsync(playerInTeam => playerInTeam.Id)
                    .ConfigureAwait(false);

                var newPiTrecord = new PlayerInTeam
                {
                    CurrentPlayerInTeamStatus = InTeamStatusEnum.Reserve,
                    PlayerId = player.Id,
                    TeamId = team.TeamAbbreviation,
                    Id = maxId + 1
                };
                await db.PlayersInTeams.AddAsync(newPiTrecord)
                    .ConfigureAwait(false);
            }
            else
            {
                pit.CurrentPlayerInTeamStatus = InTeamStatusEnum.Reserve;
                db.PlayersInTeams.Update(pit);
            }

            var playerDB = await db.Players.FirstOrDefaultAsync(p => p.Id == player.Id)
                .ConfigureAwait(false);

            if (playerDB is { CurrentPlayerStatus: PlayerStatusEnum.FreeAgent })
            {
                playerDB.CurrentPlayerStatus = PlayerStatusEnum.Active;
                db.Players.Update(playerDB);
            }

            await db.SaveChangesAsync()
                .ConfigureAwait(false);
        }

        public async Task ChangePlayerInTeamStatus(Player player, Team team, InTeamStatusEnum inTeamStatus)
        {
            await using var db = new VKRApplicationContext();
            var pit = await db.PlayersInTeams.FirstOrDefaultAsync(pit => pit.TeamId == team.TeamAbbreviation && pit.PlayerId == player.Id)
                .ConfigureAwait(false);

            if (pit == null) return;
            pit.CurrentPlayerInTeamStatus = inTeamStatus;
            db.PlayersInTeams.Update(pit);
            await db.SaveChangesAsync().ConfigureAwait(false);
        }

        public async Task ReleasePlayer(Player player)
        {
            await using var db = new VKRApplicationContext();
            var playerDB = await db.Players.FirstOrDefaultAsync(p => p.Id == player.Id)
                .ConfigureAwait(false);

            if (playerDB == null) return;

            playerDB.CurrentPlayerStatus = PlayerStatusEnum.FreeAgent;
            db.Players.Update(playerDB);

            var pitRecords = await db.PlayersInTeams.Where(pit => pit.PlayerId == player.Id)
                .ToListAsync()
                .ConfigureAwait(false);

            foreach (var playerInTeam in pitRecords)
            {
                playerInTeam.CurrentPlayerInTeamStatus = InTeamStatusEnum.NotInThisTeam;
                db.PlayersInTeams.Update(playerInTeam);
            }

            await db.SaveChangesAsync()
                .ConfigureAwait(false);
        }

        public async Task RemovePlayerFromStartingLineup(Player player, Team team, byte lineupNumber)
        {
            await using var db = new VKRApplicationContext();
            var playerInTeam = await db.PlayersInTeams.FirstOrDefaultAsync(pit => pit.PlayerId == player.Id &&
                                                                       pit.TeamId == team.TeamAbbreviation)
                .ConfigureAwait(false);

            if (playerInTeam == null) return;

            var slEntry = await db.StartingLineups.FirstOrDefaultAsync(sl =>
                sl.LineupTypeId == lineupNumber && sl.PlayerInTeamId == playerInTeam.Id)
                .ConfigureAwait(false);

            if (slEntry == null) return;

            db.StartingLineups.Remove(slEntry);
            await db.SaveChangesAsync()
                .ConfigureAwait(false);
        }

        public async Task AssignPlayerToStartingLineup(Player player, Team team, byte lineupNumber, PlayerPosition position, byte numberInLineup)
        {
            await using var db = new VKRApplicationContext();
            var playerInTeam = await db.PlayersInTeams.FirstOrDefaultAsync(pit => pit.PlayerId == player.Id &&
                                                                       pit.TeamId == team.TeamAbbreviation)
                .ConfigureAwait(false);

            if (playerInTeam == null) return;

            var playerPosition = await db.PlayersPositions.FirstOrDefaultAsync(pp => pp.Number == position.Number);

            if (playerPosition == null) return;

            var newEntryInStartingLineup = new StartingLineup
            {
                PlayerInTeamId = playerInTeam.Id,
                LineupTypeId = lineupNumber,
                PlayerPositionId = playerPosition.ShortTitle,
                PlayerNumberInLineup = numberInLineup
            };

            db.StartingLineups.Add(newEntryInStartingLineup);
            await db.SaveChangesAsync()
                .ConfigureAwait(false);
        }
    }
}