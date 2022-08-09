using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class PlayerEFDAO
    {
        public Player GetPlayerByCode(uint code)
        {
            using var db = new VKRApplicationContext();
            return db.PlayersInTeams.Include(pit => pit.Player).First(player => player.Id == code).Player;
        }

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
                list.AddRange(from appearanceAsStarter in player.PlayersInTeam.First().PlayersInStartingLineups.Select(t => player.PlayersInTeam.First()).Select((playerInTeam, index) => playerInTeam.PlayersInStartingLineups[index])
                              let playerPosition = appearanceAsStarter.LineupTypeId == 5 ? "P" : player.Positions[0].ShortTitle
                              select new PlayerInLineupViewModel(player, appearanceAsStarter.LineupTypeId, appearanceAsStarter.PlayerNumberInLineup, player.PlayersInTeam.First().TeamId, playerPosition));

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

        public List<Player> GetPlayerBattingStats(int year)
        {
            using var db = new VKRApplicationContext();

            var players = db.Players.Include(player => player.Positions)
                .Include(player => player.PlayersInTeam.Where(pit => pit.CurrentPlayerInTeamStatus != InTeamStatusEnum.NotInThisTeam))
                .AsNoTracking()
                .ToList();

            var battingStats = db.PlayersBattingStats.AsNoTracking().Where(battingStats => battingStats.Season == year && battingStats.MatchType == TypeOfMatchEnum.RegularSeason).ToList();

            return players.Join(battingStats, player => player.Id, stats => stats.PlayerID,
                (player, stats) => player.SetBattingStats(stats)).ToList();
        }

        public List<Player> GetPlayerPitchingStats(int year)
        {
            using var db = new VKRApplicationContext();

            var players = db.Players.Include(player => player.Positions)
                .Include(player => player.PlayersInTeam.Where(pit => pit.CurrentPlayerInTeamStatus != InTeamStatusEnum.NotInThisTeam))
                .AsNoTracking()
                .ToList();

            var pitchingStats = db.PlayersPitchingStats.Where(battingStats => battingStats.Season == year && battingStats.MatchType == TypeOfMatchEnum.RegularSeason).AsNoTracking().ToList();

            return players.Join(pitchingStats, player => player.Id, stats => stats.PlayerID,
                (player, stats) => player.SetPitchingStats(stats)).ToList();
        }

        public List<PlayerPosition> GetPlayerPositions()
        {
            using var db = new VKRApplicationContext();
            return db.PlayersPositions.OrderBy(pp => pp.Number).ToList();
        }

        public Pitcher GetStartingPitcherForThisTeam(Match match, Team team)
        {
            using var db = new VKRApplicationContext();

            var starterId = db.LineupsForMatches.Include(lfm => lfm.PlayerInTeam)
                .Where(lfm => lfm.PlayerInTeam.TeamId == team.TeamAbbreviation && lfm.MatchId == match.Id && lfm.PlayerNumberInLineup == 10)
                .Select(lfm => lfm.PlayerInTeam)
                .FirstOrDefault();

            var numberInRotation = db.StartingLineups.Where(sl => sl.LineupTypeId == 5 && sl.PlayerInTeamId == starterId.Id)
                .Select(sl => sl.PlayerNumberInLineup)
                .FirstOrDefault();

            var player = db.Players.Include(p => p.Positions)
                .FirstOrDefault(p => p.Id == starterId.PlayerId);

            return new Pitcher(player, numberInRotation, starterId.Id);
        }

        public int GetPitcherStamina(uint pitcherId, DateTime matchDate)
        {
            using var db = new VKRApplicationContext();
            return db.Players.Where(p => p.Id == pitcherId)
                .Select(p => db.GetStaminaForThisPitcher(pitcherId, matchDate)).First();
        }

        public List<Batter> GetCurrentBattingLineup(Team team, Match match)
        {
            using var db = new VKRApplicationContext();
            var currentLineupNumbers = db.LineupsForMatches.Include(lfm => lfm.PlayerInTeam)
                .Where(lfm =>
                    lfm.MatchId == match.Id && lfm.PlayerNumberInLineup < 10 &&
                    lfm.PlayerInTeam.TeamId == team.TeamAbbreviation)
                .AsEnumerable()
                .GroupBy(lfm => lfm.PlayerNumberInLineup, lfm => lfm.Id, (numberInLineup, ids) => new
                {
                    Key = numberInLineup,
                    Value = ids.Max()
                })
                .Select(kv => kv.Value)
                .ToList();

            var currentLineup = db.LineupsForMatches.Where(lfm => currentLineupNumbers.Contains(lfm.Id))
                .Include(lfm => lfm.PlayerInTeam)
                .ThenInclude(pit => pit.Player)
                .ThenInclude(p => p.Positions)
                .OrderBy(lfm => lfm.PlayerNumberInLineup).ToList();

            var batters = currentLineup.Select(lfm =>
                new Batter(lfm.PlayerInTeam.Player, lfm.PlayerPositionId, lfm.PlayerNumberInLineup, lfm.PlayerInTeamId)).ToList();

            var battersIds = batters.Select(b => b.Id);

            var battingStats = db.PlayersBattingStats.Where(player => battersIds.Contains(player.PlayerID) &&
                                                                             player.Season == match.MatchDate.Year &&
                                                                             player.MatchType == match.MatchTypeId).ToList();
            
            return batters.Join(battingStats, 
                batter => batter.Id, 
                stats => stats.PlayerID, 
                (batter, stats) => batter.SetBattingStats(stats))
                .ToList();
        }
    }
}