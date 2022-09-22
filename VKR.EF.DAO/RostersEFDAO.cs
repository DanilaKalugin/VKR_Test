using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class RostersEFDAO
    {
        public async Task<List<PlayerInLineupViewModel>> GetFreeAgents()
        {
            await using var db = new VKRApplicationContext();
            var allPlayers = await db.Players
                .Where(player => player.CurrentPlayerStatus == PlayerStatusEnum.FreeAgent)
                .Include(player => player.BattingHand)
                .Include(player => player.PitchingHand)
                .Include(player => player.City)
                .Include(player => player.Positions)
                .ToListAsync()
                .ConfigureAwait(false);

            return allPlayers.Select(player => new PlayerInLineupViewModel(player, player.Positions[0].ShortTitle)).ToList();
        }

        public async Task<List<PlayerInLineupViewModel>> GetActiveAndReservePlayers()
        {
            await using var db = new VKRApplicationContext();

            var allPlayers = await db.PlayersInTeams
                .Where(pit => pit.CurrentPlayerInTeamStatus != InTeamStatusEnum.NotInThisTeam)
                .Include(pit => pit.Player)
                .ThenInclude(p => p.City)
                .Include(p => p.Player.Positions)
                .Include(pit => pit.Player.BattingHand)
                .Include(pit => pit.Player.PitchingHand)
                .ToListAsync();

            return allPlayers.Select(pit => new PlayerInLineupViewModel(pit.Player, pit.Player.Positions[0].ShortTitle, pit.TeamId)).ToList();
        }

        public async Task<List<PlayerInLineupViewModel>> GetReserves()
        {
            await using var db = new VKRApplicationContext();
            var allPlayers = await db.PlayersInTeams
                .Where(pit => pit.CurrentPlayerInTeamStatus == InTeamStatusEnum.Reserve)
                .Include(pit => pit.Player)
                .ThenInclude(p => p.City)
                .Include(p => p.Player.Positions)
                .Include(pit => pit.Player.BattingHand)
                .Include(pit => pit.Player.PitchingHand)
                .ToListAsync();

            return allPlayers.Select(pit => new PlayerInLineupViewModel(pit.Player, pit.Player.Positions[0].ShortTitle, pit.TeamId)).ToList();
        }

        public async Task<List<PlayerInLineupViewModel>> GetActivePlayers()
        {
            await using var db = new VKRApplicationContext();
            var allPlayers = await db.PlayersInTeams
                .Where(pit => pit.CurrentPlayerInTeamStatus == InTeamStatusEnum.ActiveRoster)
                .Include(pit => pit.Player)
                .ThenInclude(p => p.City)
                .Include(p => p.Player.Positions)
                .Include(pit => pit.Player.BattingHand)
                .Include(pit => pit.Player.PitchingHand)
                .ToListAsync();

            return allPlayers.Select(pit => new PlayerInLineupViewModel(pit.Player, pit.Player.Positions[0].ShortTitle, pit.TeamId)).ToList();
        }

        public async Task<List<PlayerInLineupViewModel>> GetStartingLineups()
        {
            await using var db = new VKRApplicationContext();
            var allPlayers = await db.PlayersInTeams
                .Where(pit => pit.CurrentPlayerInTeamStatus == InTeamStatusEnum.ActiveRoster)
                .Include(pit => pit.Player)
                .ThenInclude(p => p.City)
                .Include(pit => pit.PlayersInStartingLineups)
                .Include(p => p.Player.Positions)
                .Include(pit => pit.Player.BattingHand)
                .Include(pit => pit.Player.PitchingHand)
                .ToListAsync();

            var list = new List<PlayerInLineupViewModel>();
            foreach (var pit in allPlayers)
                list.AddRange(from appearanceAsStarter in pit.PlayersInStartingLineups
                              let playerPosition = appearanceAsStarter.LineupTypeId == 5 ? "P" : appearanceAsStarter.PlayerPositionId
                              select new PlayerInLineupViewModel(pit.Player, appearanceAsStarter.LineupTypeId, appearanceAsStarter.PlayerNumberInLineup, pit.TeamId, playerPosition));

            return list;
        }

        public async Task<List<PlayerInLineupViewModel>> GetBench()
        {
            await using var db = new VKRApplicationContext();

            var f = await db.Players
                .Include(player => player.PlayersInTeam.Where(pit => pit.CurrentPlayerInTeamStatus == InTeamStatusEnum.ActiveRoster))
                .ThenInclude(pit => pit.PlayersInStartingLineups)
                .Include(player => player.Positions)
                .Where(player => player.PlayersInTeam.Any(pit => pit.CurrentPlayerInTeamStatus == InTeamStatusEnum.ActiveRoster))
                .Include(player => player.BattingHand)
                .Include(player => player.PitchingHand)
                .Include(player => player.City)
                .ToListAsync();

            var list = new List<PlayerInLineupViewModel>();
            foreach (var player in f)
                for (byte i = 1; i <= 5; i++)
                {
                    var playerPosition = i == 5 ? "P" : player.Positions[0].ShortTitle;
                    var playerInTeam = player.PlayersInTeam.First();

                    if (playerInTeam.PlayersInStartingLineups.Count(sl => sl.LineupTypeId == i) != 0) continue;
                    switch (i)
                    {
                        case <= 4 when player.CanPlayAsPitcher:
                            continue;
                        case <= 4:
                            list.Add(new PlayerInLineupViewModel(player, i, 0, playerInTeam.TeamId, playerPosition));
                            break;
                        default:
                        {
                            if (player.CanPlayAsPitcher)
                                list.Add(new PlayerInLineupViewModel(player, i, 0, playerInTeam.TeamId,
                                    playerPosition));
                            break;
                        }
                    }
                }

            return list;
        }
    }
}