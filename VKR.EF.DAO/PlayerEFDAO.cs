using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VKR.EF.DAO.Contexts;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class PlayerEFDAO
    {
        public async Task<Player> GetPlayerByCode(uint code)
        {
            await using var db = new VKRApplicationContext();
            var player = await db.PlayersInTeams.Include(pit => pit.Player)
                .FirstAsync(player => player.Id == code)
                .ConfigureAwait(false);
            return player.Player;
        }

        public async Task<PlayerBattingStats> GetBattingStatsByCode(uint playerCode, int year, TypeOfMatchEnum typeOfMatch = TypeOfMatchEnum.RegularSeason)
        {
            await using var db = new VKRApplicationContext();

            return await db.PlayersBattingStats
                .FirstOrDefaultAsync(player => player.PlayerID == playerCode &&
                                               player.Season == year &&
                                               player.MatchType == typeOfMatch)
                .ConfigureAwait(false);
        }

        public async Task<PlayerPitchingStats> GetPitchingStatsByCode(uint playerCode, int year, TypeOfMatchEnum typeOfMatch = TypeOfMatchEnum.RegularSeason)
        {
            await using var db = new VKRApplicationContext();

            return await db.PlayersPitchingStats
                .FirstOrDefaultAsync(player => player.PlayerID == playerCode &&
                                 player.Season == year &&
                                 player.MatchType == typeOfMatch)
                .ConfigureAwait(false);
        }

        public async Task UpdatePlayer(Player player)
        {
            await using var db = new VKRApplicationContext();

            var playerDb = await db.Players.FindAsync(player.Id)
                .ConfigureAwait(false);

            if (playerDb == null) return;

            playerDb.PlayerBattingHand = player.PlayerBattingHand;
            playerDb.PlayerPitchingHand = player.PlayerPitchingHand;
            playerDb.FirstName = player.FirstName;
            playerDb.SecondName = player.SecondName;
            playerDb.PlayerNumber = player.PlayerNumber;
            playerDb.DateOfBirth = player.DateOfBirth;
            playerDb.PlaceOfBirth = player.City.Id;

            db.Players.Update(playerDb);
            await db.SaveChangesAsync()
                .ConfigureAwait(false);
        }

        public async Task AddPlayer(Player player)
        {
            await using var db = new VKRApplicationContext();

            await db.Players.AddAsync(player)
                .ConfigureAwait(false);

            await db.SaveChangesAsync()
                .ConfigureAwait(false);
        }

        public async ValueTask<uint> GetIdForNewPlayer()
        {
            await using var db = new VKRApplicationContext();
            var maxId = await db.Players.MaxAsync(p => p.Id)
                .ConfigureAwait(false);
            return maxId + 1;
        }

        public async Task<Pitcher> GetStartingPitcherForThisTeam(Match match, Team team)
        {
            await using var db = new VKRApplicationContext();

            var starterId = await db.LineupsForMatches.Include(lfm => lfm.PlayerInTeam)
                .Where(lfm => lfm.PlayerInTeam.TeamId == team.TeamAbbreviation && lfm.MatchId == match.Id && lfm.PlayerNumberInLineup == 10)
                .Select(lfm => lfm.PlayerInTeam)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            var numberInRotation = await db.StartingLineups.Where(sl => sl.LineupTypeId == 5 && sl.PlayerInTeamId == starterId.Id)
                .Select(sl => sl.PlayerNumberInLineup)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            var player = await db.Players.Include(p => p.Positions)
                .FirstOrDefaultAsync(p => p.Id == starterId.PlayerId)
                .ConfigureAwait(false);

            return new Pitcher(player, numberInRotation, starterId.Id);
        }

        public async Task<int> GetPitcherStamina(uint pitcherId, DateTime matchDate)
        {
            await using var db = new VKRApplicationContext();
            return await db.Players.Where(p => p.Id == pitcherId)
                .Select(p => db.GetStaminaForThisPitcher(pitcherId, matchDate))
                .FirstAsync()
                .ConfigureAwait(false);
        }

        public async Task<List<Batter>> GetCurrentBattingLineup(Team team, Match match)
        {
            await using var db = new VKRApplicationContext();

            var playersPlayedInMatch = await db.LineupsForMatches.Include(lfm => lfm.PlayerInTeam)
                .Where(lfm =>
                    lfm.MatchId == match.Id && lfm.PlayerNumberInLineup < 10 &&
                    lfm.PlayerInTeam.TeamId == team.TeamAbbreviation)
                .ToListAsync()
                .ConfigureAwait(false);

                var currentLineupNumbers = playersPlayedInMatch.GroupBy(lfm => lfm.PlayerNumberInLineup, lfm => lfm.Id, (numberInLineup, ids) => new
                {
                    Key = numberInLineup,
                    Value = ids.Max()
                })
                .Select(kv => kv.Value)
                .ToList();

            var currentLineup = await db.LineupsForMatches.Where(lfm => currentLineupNumbers.Contains(lfm.Id))
                .Include(lfm => lfm.PlayerInTeam)
                .ThenInclude(pit => pit.Player)
                .ThenInclude(p => p.Positions)
                .OrderBy(lfm => lfm.PlayerNumberInLineup)
                .ToListAsync()
                .ConfigureAwait(false);

            var batters = currentLineup.Select(lfm =>
                new Batter(lfm.PlayerInTeam.Player, lfm.PlayerPositionId, lfm.PlayerNumberInLineup, lfm.PlayerInTeamId)).ToList();

            var battersIds = batters.Select(b => b.Id);

            var battingStats = await db.PlayersBattingStats.Where(player => battersIds.Contains(player.PlayerID) &&
                                                                             player.Season == match.MatchDate.Year &&
                                                                             player.MatchType == match.MatchTypeId)
                .ToListAsync()
                .ConfigureAwait(false);

            return batters.Join(battingStats,
                batter => batter.Id,
                stats => stats.PlayerID,
                (batter, stats) => batter.SetBattingStats(stats))
                .ToList();
        }

        public async Task SetNewNumberForPlayerAsync(Player player, byte newNumber)
        {
            await using var db = new VKRApplicationContext();

            var playerDb = await db.Players.FindAsync(player.Id);

            if (playerDb is null) return;

            playerDb.PlayerNumber = newNumber;

            db.Players.Update(playerDb);
            await db.SaveChangesAsync()
                .ConfigureAwait(false);
        }
    }
}