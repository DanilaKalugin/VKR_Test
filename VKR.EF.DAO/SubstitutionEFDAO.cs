using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class SubstitutionEFDAO
    {
        public async Task SubstitutePitcher(Match match, Pitcher pitcher)
        {
            await using var db = new VKRApplicationContext();

            var pitcherDb = new LineupForMatch
            {
                MatchId = match.Id,
                PlayerInTeamId = pitcher.PitcherId,
                PlayerPositionId = "P",
                PlayerNumberInLineup = 10
            };

            await db.LineupsForMatches.AddAsync(pitcherDb);

            if (!match.DHRule)
            {
                var pitcherInBattingLineup = new LineupForMatch
                {
                    MatchId = match.Id,
                    PlayerInTeamId = pitcher.PitcherId,
                    PlayerPositionId = "P",
                    PlayerNumberInLineup = 9
                };
                await db.LineupsForMatches.AddAsync(pitcherInBattingLineup);
            }
            await db.SaveChangesAsync();
        }

        public async Task SubstituteBatter(Match match, Batter batter)
        {
            await using var db = new VKRApplicationContext();

            var pitcherDb = new LineupForMatch
            {
                MatchId = match.Id,
                PlayerInTeamId = batter.BatterId,
                PlayerPositionId = batter.PositionForThisMatch,
                PlayerNumberInLineup = batter.NumberInLineup
            };

            await db.LineupsForMatches.AddAsync(pitcherDb);

            if (!match.DHRule && batter.NumberInLineup == 9 && batter.PositionForThisMatch == "P")
            {
                var pitcherInBattingLineup = new LineupForMatch
                {
                    MatchId = match.Id,
                    PlayerInTeamId = batter.BatterId,
                    PlayerPositionId = "P",
                    PlayerNumberInLineup = 10
                };
                await db.LineupsForMatches.AddAsync(pitcherInBattingLineup);
            }
            await db.SaveChangesAsync();
        }

        public async Task<List<Pitcher>> GetAvailablePitchers(Match match, Team team)
        {
            await using var db = new VKRApplicationContext();

            var notAvailablePitchers = db.StartingLineups.Where(sl => sl.LineupTypeId == 5)
                .Select(sl => sl.PlayerInTeamId)
                .Union(db.LineupsForMatches.Where(lfm => lfm.MatchId == match.Id)
                    .Select(sl => sl.PlayerInTeamId));

            var pitchersDb = await db.PlayersInTeams.Include(pit => pit.Player)
                .ThenInclude(player => player.Positions)
                .Where(pit => pit.CurrentPlayerInTeamStatus == InTeamStatusEnum.ActiveRoster &&
                              pit.TeamId == team.TeamAbbreviation &&
                              pit.Player.Positions.Any(pp => pp.ShortTitle == "P") &&
                              !notAvailablePitchers.Contains(pit.Id))
                .ToListAsync()
                .ConfigureAwait(false);

            var pitchers = pitchersDb.Select(p => new Pitcher(p.Player, 0, p.Id)).ToList();
            var pitcherIds = pitchers.Select(pitcher => pitcher.Id);

            var pitchingStats = await db.PlayersPitchingStats.Where(pitchingStats =>
                pitchingStats.Season == match.MatchDate.Year &&
                pitchingStats.MatchType == match.MatchTypeId &&
                pitcherIds.Contains(pitchingStats.PlayerID))
                .ToListAsync()
                .ConfigureAwait(false);

            return pitchers.Join(pitchingStats,
                pitcher => pitcher.Id,
                ps => ps.PlayerID,
                (pitcher, stats) => pitcher.SetPitchingStats(stats)).ToList();
        }

        public async Task<List<Batter>> GetAvailableBatters(Match match, Team team, Batter batter)
        {
            await using var db = new VKRApplicationContext();

            var notAvailableBatters = db.LineupsForMatches.Where(lfm => lfm.MatchId == match.Id)
                    .Select(sl => sl.PlayerInTeamId);

            var battersDB = batter.PositionForThisMatch switch
            {
                "P" => await db.PlayersInTeams.Include(pit => pit.Player)
                    .ThenInclude(player => player.Positions)
                    .Where(pit => pit.CurrentPlayerInTeamStatus == InTeamStatusEnum.ActiveRoster &&
                                  pit.TeamId == team.TeamAbbreviation && !pit.Player.CanPlayAsPitcher &&
                                  !notAvailableBatters.Contains(pit.Id))
                    .ToListAsync(),
                "DH" => await db.PlayersInTeams.Include(pit => pit.Player)
                    .ThenInclude(player => player.Positions)
                    .Where(pit => pit.CurrentPlayerInTeamStatus == InTeamStatusEnum.ActiveRoster &&
                                  pit.TeamId == team.TeamAbbreviation && !pit.Player.CanPlayAsPitcher &&
                                  !notAvailableBatters.Contains(pit.Id))
                    .ToListAsync(),
                _ => await db.PlayersInTeams.Include(pit => pit.Player)
                    .ThenInclude(player => player.Positions)
                    .Where(pit => pit.CurrentPlayerInTeamStatus == InTeamStatusEnum.ActiveRoster &&
                                  pit.TeamId == team.TeamAbbreviation &&
                                  pit.Player.Positions.Any(pp => pp.ShortTitle == batter.PositionForThisMatch) &&
                                  !notAvailableBatters.Contains(pit.Id))
                    .ToListAsync()
            };

            var batters = battersDB.Select(pit => new Batter(pit.Player, batter.PositionForThisMatch, batter.NumberInLineup, pit.Id))
                .ToList();

            var battersIds = batters.Select(batter => batter.Id).ToList();

            var battingStats = await db.PlayersBattingStats.Where(stats =>
                stats.Season == match.MatchDate.Year &&
                stats.MatchType == match.MatchTypeId &&
                battersIds.Contains(stats.PlayerID)).ToListAsync();

            return batters.Join(battingStats,
                batter => batter.Id,
                stats => stats.PlayerID,
                (batter, stats) => batter.SetBattingStats(stats)).ToList();
        }
    }
}