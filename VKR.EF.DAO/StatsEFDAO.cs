using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VKR.EF.DAO.Contexts;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class StatsEFDAO
    {
        public async Task<List<Player>> GetPlayerBattingStatsAsync(int year)
        {
            await using var db = new VKRApplicationContext();

            var players = await db.Players.Include(player => player.Positions)
                .Include(player => player.PlayersInTeam.Where(pit => pit.CurrentPlayerInTeamStatus != InTeamStatusEnum.NotInThisTeam))
                .ToListAsync()
                .ConfigureAwait(false);

            var battingStats =await  db.PlayersBattingStats
                .Where(battingStats => battingStats.Season == year &&
                                       battingStats.MatchType == TypeOfMatchEnum.RegularSeason &&
                                       battingStats.Games > 0)
                .ToListAsync()
                .ConfigureAwait(false);

            return players.Join(battingStats, player => player.Id, stats => stats.PlayerID,
                (player, stats) => player.SetBattingStats(stats)).ToList();
        }

        public async Task<List<Player>> GetPlayerPitchingStatsAsync(int year, TypeOfMatchEnum matchType = TypeOfMatchEnum.RegularSeason)
        {
            await using var db = new VKRApplicationContext();

            var players = await db.Players.Include(player => player.Positions)
                .Include(player => player.PlayersInTeam.Where(pit => pit.CurrentPlayerInTeamStatus != InTeamStatusEnum.NotInThisTeam))
                .ToListAsync();

            var pitchingStats = await db.PlayersPitchingStats
                .Where(battingStats => battingStats.Season == year &&
                                       battingStats.MatchType == matchType &&
                                       battingStats.GamesPlayed > 0)
                .ToListAsync()
                .ConfigureAwait(false);

            return players.Join(pitchingStats, player => player.Id, stats => stats.PlayerID,
                (player, stats) => player.SetPitchingStats(stats)).ToList();
        }

        public async Task<List<Team>> GetBattingStatsByYearAndMatchType(int year, TypeOfMatchEnum type)
        {
            await using var db = new VKRApplicationContext();

            var teams = await db.Teams.ToListAsync()
                .ConfigureAwait(false);

            var battingStats = await db.TeamsBattingStats
                .Where(batting => batting.Season == year && 
                                  batting.MatchType == type)
                .ToListAsync()
                .ConfigureAwait(false);

            return teams.Join(battingStats, team => team.TeamAbbreviation, stats => stats.TeamName,
                (team, stats) => team.SetBattingStats(stats)).ToList();
        }

        public async Task<List<Team>> GetPitchingStatsByYearAndMatchTypeAsync(int year = 2021, TypeOfMatchEnum type = TypeOfMatchEnum.RegularSeason)
        {
            await using var db = new VKRApplicationContext();

            var teams = await db.Teams.Include(team => team.TeamColors)
                .ToListAsync()
                .ConfigureAwait(false);

            var battingStats = await db.TeamsPitchingStats
                .Where(batting => batting.Season == year && batting.MatchType == type)
                .ToListAsync()
                .ConfigureAwait(false);

            return teams.Join(battingStats, team => team.TeamAbbreviation, stats => stats.TeamName,
                (team, stats) => team.SetPitchingStats(stats)).ToList();
        }
    }
}