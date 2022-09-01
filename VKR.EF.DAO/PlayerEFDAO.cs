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

        public PlayerBattingStats GetBattingStatsByCode(uint playerCode, int year)
        {
            using var db = new VKRApplicationContext();

            return db.PlayersBattingStats
                .First(player => player.PlayerID == playerCode &&
                                 player.Season == year &&
                                 player.MatchType == TypeOfMatchEnum.RegularSeason);
        }

        public PlayerPitchingStats GetPitchingStatsByCode(uint playerCode, int year, TypeOfMatchEnum typeOfMatch = TypeOfMatchEnum.RegularSeason)
        {
            using var db = new VKRApplicationContext();

            return db.PlayersPitchingStats
                .First(player => player.PlayerID == playerCode &&
                                 player.Season == year &&
                                 player.MatchType == typeOfMatch);
        }

        public void UpdatePlayer(Player player)
        {
            using var db = new VKRApplicationContext();

            var playerDB = db.Players.FirstOrDefault(p => p.Id == player.Id);
            if (playerDB == null) return;

            playerDB.PlayerBattingHand = player.PlayerBattingHand;
            playerDB.PlayerPitchingHand = player.PlayerPitchingHand;
            playerDB.FirstName = player.FirstName;
            playerDB.SecondName = player.SecondName;
            playerDB.PlayerNumber = player.PlayerNumber;
            playerDB.DateOfBirth = player.DateOfBirth;
            playerDB.PlaceOfBirth = player.City.Id;

            db.Players.Update(playerDB);
            db.SaveChanges();
        }

        public void AddPlayer(Player player)
        {
            using var db = new VKRApplicationContext();

            var playerDb = new Player
            {
                Id = player.Id,
                PlayerBattingHand = player.PlayerBattingHand,
                PlayerPitchingHand = player.PlayerPitchingHand,
                FirstName = player.FirstName,
                SecondName = player.SecondName,
                PlayerNumber = player.PlayerNumber,
                DateOfBirth = player.DateOfBirth,
                PlaceOfBirth = player.City.Id,
                CurrentPlayerStatus = PlayerStatusEnum.FreeAgent,

            };

            db.Players.Add(playerDb);
            db.SaveChanges();
        }

        public uint GetIdForNewPlayer()
        {
            using var db = new VKRApplicationContext();

            return db.Players.Max(p => p.Id) + 1;
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