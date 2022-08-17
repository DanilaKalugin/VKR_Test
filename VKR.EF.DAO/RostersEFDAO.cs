using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class RostersEFDAO
    {
        public List<PlayerInLineupViewModel> GetFreeAgents()
        {
            using var db = new VKRApplicationContext();
            var allPlayers = db.Players
                .Where(player => player.CurrentPlayerStatus == PlayerStatusEnum.FreeAgent)
                .Include(player => player.BattingHand)
                .Include(player => player.PitchingHand)
                .Include(player => player.City)
                .Include(player => player.Positions)
                .ToList();

            return allPlayers.Select(player => new PlayerInLineupViewModel(player, 0, 0, string.Empty, player.Positions[0].ShortTitle)).ToList();
        }

        public List<PlayerInLineupViewModel> GetActiveAndReservePlayers()
        {
            using var db = new VKRApplicationContext();

            var allPlayers = db.PlayersInTeams
                .Where(pit => pit.CurrentPlayerInTeamStatus != InTeamStatusEnum.NotInThisTeam)
                .Include(pit => pit.Player)
                .ThenInclude(p => p.City)
                .Include(p => p.Player.Positions)
                .Include(pit => pit.Player.BattingHand)
                .Include(pit => pit.Player.PitchingHand)
                .ToList();

            return allPlayers.Select(pit => new PlayerInLineupViewModel(pit.Player, 0, 0, pit.TeamId, pit.Player.Positions[0].ShortTitle)).ToList();
        }

        public List<PlayerInLineupViewModel> GetReserves()
        {
            using var db = new VKRApplicationContext();
            var allPlayers = db.PlayersInTeams
                .Where(pit => pit.CurrentPlayerInTeamStatus == InTeamStatusEnum.Reserve)
                .Include(pit => pit.Player)
                .ThenInclude(p => p.City)
                .Include(p => p.Player.Positions)
                .Include(pit => pit.Player.BattingHand)
                .Include(pit => pit.Player.PitchingHand)
                .ToList();

            return allPlayers.Select(pit => new PlayerInLineupViewModel(pit.Player, 0, 0, pit.TeamId, pit.Player.Positions[0].ShortTitle)).ToList();
        }

        public List<PlayerInLineupViewModel> GetActivePlayers()
        {
            using var db = new VKRApplicationContext();
            var allPlayers = db.PlayersInTeams
                .Where(pit => pit.CurrentPlayerInTeamStatus == InTeamStatusEnum.ActiveRoster)
                .Include(pit => pit.Player)
                .ThenInclude(p => p.City)
                .Include(p => p.Player.Positions)
                .Include(pit => pit.Player.BattingHand)
                .Include(pit => pit.Player.PitchingHand)
                .ToList();

            return allPlayers.Select(pit => new PlayerInLineupViewModel(pit.Player, 0, 0, pit.TeamId, pit.Player.Positions[0].ShortTitle)).ToList();
        }

        public List<PlayerInLineupViewModel> GetStartingLineups()
        {
            using var db = new VKRApplicationContext();
            var allPlayers = db.PlayersInTeams
                .Where(pit => pit.CurrentPlayerInTeamStatus == InTeamStatusEnum.ActiveRoster)
                .Include(pit => pit.Player)
                .ThenInclude(p => p.City)
                .Include(pit => pit.PlayersInStartingLineups)
                .Include(p => p.Player.Positions)
                .Include(pit => pit.Player.BattingHand)
                .Include(pit => pit.Player.PitchingHand)
                .ToList();

            var list = new List<PlayerInLineupViewModel>();
            foreach (var pit in allPlayers)
                list.AddRange(from appearanceAsStarter in pit.PlayersInStartingLineups
                              let playerPosition = appearanceAsStarter.LineupTypeId == 5 ? "P" : pit.Player.Positions[0].ShortTitle
                              select new PlayerInLineupViewModel(pit.Player, appearanceAsStarter.LineupTypeId, appearanceAsStarter.PlayerNumberInLineup, pit.TeamId, playerPosition));

            return list;
        }

        public List<PlayerInLineupViewModel> GetBench()
        {
            using var db = new VKRApplicationContext();

            var f = db.Players
                .Include(player => player.PlayersInTeam.Where(pit => pit.CurrentPlayerInTeamStatus == InTeamStatusEnum.ActiveRoster))
                .ThenInclude(pit => pit.PlayersInStartingLineups)
                .Include(player => player.Positions)
                .Where(player => player.PlayersInTeam.Any(pit => pit.CurrentPlayerInTeamStatus == InTeamStatusEnum.ActiveRoster))
                .Include(player => player.BattingHand)
                .Include(player => player.PitchingHand)
                .Include(player => player.City)
                .ToList();

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