using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class PlayerEFDAO
    {
        public List<PlayerInLineupViewModel> GetFreeAgents()
        {
            using var db = new VKRApplicationContext();
            var allPlayers = db.Players.Where(player => player.CurrentPlayerStatus == PlayerStatusEnum.FreeAgent)
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
            var allPlayers = db.Players.Where(player => player.CurrentPlayerStatus != PlayerStatusEnum.FreeAgent)
                .Include(player => player.PlayersInTeam.Where(pit => pit.CurrentPlayerInTeamStatus != InTeamStatusEnum.NotInThisTeam))
                .Where(player => player.PlayersInTeam.Any(pit => pit.CurrentPlayerInTeamStatus != InTeamStatusEnum.NotInThisTeam))
                .Include(player => player.BattingHand)
                .Include(player => player.PitchingHand)
                .Include(player => player.City)
                .Include(player => player.Positions)
                .ToList();

            return allPlayers.Select(player => new PlayerInLineupViewModel(player, 0, 0, player.PlayersInTeam.First().TeamId, player.Positions[0].ShortTitle)).ToList();
        }

        public List<PlayerInLineupViewModel> GetReserves()
        {
            using var db = new VKRApplicationContext();
            var allPlayers = db.Players
                .Include(player => player.PlayersInTeam.Where(pit => pit.CurrentPlayerInTeamStatus == InTeamStatusEnum.Reserve))
                .Where(player => player.PlayersInTeam.Any(pit => pit.CurrentPlayerInTeamStatus == InTeamStatusEnum.Reserve))
                .Include(player => player.BattingHand)
                .Include(player => player.PitchingHand)
                .Include(player => player.City)
                .Include(player => player.Positions)
                .ToList();

            return allPlayers.Select(player => new PlayerInLineupViewModel(player, 0, 0, player.PlayersInTeam.First().TeamId, player.Positions[0].ShortTitle)).ToList();
        }

        public List<PlayerInLineupViewModel> GetActivePlayers()
        {
            using var db = new VKRApplicationContext();
            var allPlayers = db.Players
                .Include(player => player.PlayersInTeam.Where(pit => pit.CurrentPlayerInTeamStatus == InTeamStatusEnum.ActiveRoster))
                .Where(player => player.PlayersInTeam.Any(pit => pit.CurrentPlayerInTeamStatus == InTeamStatusEnum.ActiveRoster))
                .Include(player => player.BattingHand)
                .Include(player => player.PitchingHand)
                .Include(player => player.City)
                .Include(player => player.Positions)
                .ToList();

            return allPlayers.Select(player => new PlayerInLineupViewModel(player, 0, 0, player.PlayersInTeam.First().TeamId, player.Positions[0].ShortTitle)).ToList();
        }

        public List<PlayerInLineupViewModel> GetStartingLineups()
        {
            using var db = new VKRApplicationContext();
            var allPlayers = db.Players
                .Include(player => player.PlayersInTeam.Where(pit => pit.CurrentPlayerInTeamStatus == InTeamStatusEnum.ActiveRoster))
                .ThenInclude(pit => pit.PlayersInStartingLineups)
                .Where(player => player.PlayersInTeam.Any(pit => pit.CurrentPlayerInTeamStatus == InTeamStatusEnum.ActiveRoster))
                .Include(player => player.BattingHand)
                .Include(player => player.PitchingHand)
                .Include(player => player.City)
                .Include(player => player.Positions)
                .ToList();

            var list = new List<PlayerInLineupViewModel>();
            foreach (var player in allPlayers)
                for (var index = 0; index < player.PlayersInTeam.First().PlayersInStartingLineups.Count; index++)
                {
                    var playerInTeam = player.PlayersInTeam.First();
                    var appearanceAsStarter = playerInTeam.PlayersInStartingLineups[index];
                    var playerPosition = appearanceAsStarter.LineupTypeId == 5 ? "P" : player.Positions[0].ShortTitle;
                    list.Add(new PlayerInLineupViewModel(player, appearanceAsStarter.LineupTypeId,
                        appearanceAsStarter.PlayerNumberInLineup, player.PlayersInTeam.First().TeamId,
                        playerPosition));
                }

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
                .Include(player => player.Positions)
                .ToList();

            var list = new List<PlayerInLineupViewModel>();
            foreach (var player in f)
            {
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
            }

            return list;
        }

        public PlayerBattingStats GetBattingStatsByCode(uint playerCode, int year)
        {
            using var db = new VKRApplicationContext();

            return db.PlayersBattingStats.First(player => player.PlayerID == playerCode && player.Season == year && player.MatchType == TypeOfMatchEnum.RegularSeason);
        }

        public PlayerPitchingStats GetPitchingStatsByCode(uint playerCode, int year)
        {
            using var db = new VKRApplicationContext();

            return db.PlayersPitchingStats.First(player => player.PlayerID == playerCode && player.Season == year && player.MatchType == TypeOfMatchEnum.RegularSeason);
        }

    }
}