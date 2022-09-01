using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class StatsEFDAO
    {
        public List<Player> GetPlayerBattingStats(int year)
        {
            using var db = new VKRApplicationContext();

            var players = db.Players.Include(player => player.Positions)
                .Include(player => player.PlayersInTeam.Where(pit => pit.CurrentPlayerInTeamStatus != InTeamStatusEnum.NotInThisTeam))
                .ToList();

            var battingStats = db.PlayersBattingStats
                .Where(battingStats => battingStats.Season == year &&
                                       battingStats.MatchType == TypeOfMatchEnum.RegularSeason &&
                                       battingStats.Games > 0)
                .ToList();

            return players.Join(battingStats, player => player.Id, stats => stats.PlayerID,
                (player, stats) => player.SetBattingStats(stats)).ToList();
        }

        public List<Player> GetPlayerPitchingStats(int year, TypeOfMatchEnum matchType = TypeOfMatchEnum.RegularSeason)
        {
            using var db = new VKRApplicationContext();

            var players = db.Players.Include(player => player.Positions)
                .Include(player => player.PlayersInTeam.Where(pit => pit.CurrentPlayerInTeamStatus != InTeamStatusEnum.NotInThisTeam))
                .ToList();

            var pitchingStats = db.PlayersPitchingStats
                .Where(battingStats => battingStats.Season == year &&
                                       battingStats.MatchType == matchType &&
                                       battingStats.GamesPlayed > 0)
                .ToList();

            return players.Join(pitchingStats, player => player.Id, stats => stats.PlayerID,
                (player, stats) => player.SetPitchingStats(stats)).ToList();
        }

        public List<Team> GetBattingStatsByYearAndMatchType(int year, TypeOfMatchEnum type)
        {
            using var db = new VKRApplicationContext();

            var teams = db.Teams.Include(team => team.TeamColors).ToList();

            var battingStats = db.TeamsBattingStats
                .Where(batting => batting.Season == year && batting.MatchType == type).ToList();

            return teams.Join(battingStats, team => team.TeamAbbreviation, stats => stats.TeamName,
                (team, stats) => team.SetBattingStats(stats)).ToList();
        }

        public List<Team> GetPitchingStatsByYearAndMatchType(int year = 2021, TypeOfMatchEnum type = TypeOfMatchEnum.RegularSeason)
        {
            using var db = new VKRApplicationContext();

            var teams = db.Teams.Include(team => team.TeamColors).ToList();

            var battingStats = db.TeamsPitchingStats
                .Where(batting => batting.Season == year && batting.MatchType == type).ToList();

            return teams.Join(battingStats, team => team.TeamAbbreviation, stats => stats.TeamName,
                (team, stats) => team.SetPitchingStats(stats)).ToList();
        }
    }
}