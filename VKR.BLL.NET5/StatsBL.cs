using System.Collections.Generic;
using System.Linq;
using VKR.EF.DAO;
using VKR.EF.Entities;

namespace VKR.BLL.NET5
{
    public class StatsBL
    {
        private readonly StatsEFDAO _statsDao = new();
        private readonly TeamsEFDAO _teamsDao = new();

        public List<Team> GetTeamBattingStats()
        {
            return _statsDao.GetBattingStatsByYearAndMatchType(2021, TypeOfMatchEnum.RegularSeason)
                .OrderByDescending(team => team.BattingStats.AVG).ToList();
        }

        public List<Team> GetTeamPitchingStats()
        {
            return _statsDao.GetPitchingStatsByYearAndMatchType(2021, TypeOfMatchEnum.RegularSeason)
                .OrderBy(team => team.PitchingStats.ERA).ToList();
        }
        public List<Player> GetBattersStats(string TeamFilter = "MLB", string qualifying = "Qualified Players", string positions = "")
        {
            var players = _statsDao.GetPlayerBattingStats(2021).ToList();
            var abbreviations = GetTeamsForFilter(TeamFilter);
            players = players.Where(player => player.PlayersInTeam.Count > 0 && abbreviations.Contains(player.PlayersInTeam.First().TeamId)).ToList();

            if (positions != "")
                if (positions == "OF")
                {
                    var lf = players.Where(batter => batter.Positions.Any(pp => pp.ShortTitle == "LF")).ToList();
                    var cf = players.Where(batter => batter.Positions.Any(pp => pp.ShortTitle == "CF")).ToList();
                    var rf = players.Where(batter => batter.Positions.Any(pp => pp.ShortTitle == "RF")).ToList();
                    players = lf.Union(cf).Union(rf).Distinct().ToList();
                }
                else
                    players = players.Where(player => player.Positions.Any(pp => pp.ShortTitle == positions)).ToList();

            players = qualifying switch
            {
                "Qualified Players" => players.Where(player => (double)player.BattingStats.PA / player.BattingStats.TGP >= 3.1 && player.PlayersInTeam is not null).ToList(),
                "Active Players" => players.Where(player => player.PlayersInTeam.First().CurrentPlayerInTeamStatus == InTeamStatusEnum.ActiveRoster).ToList(),
                _ => players
            };

            return players;
        }

        public List<Player> GetPitchersStats(string qualifying = "Qualified Players", string teamFilter = "MLB")
        {
            var players = _statsDao.GetPlayerPitchingStats(2021).ToList();
            var abbreviations = GetTeamsForFilter(teamFilter);
            var fplayers = players.Where(player => player.PlayersInTeam.Count > 0 && abbreviations.Contains(player.PlayersInTeam.First().TeamId)).ToList();

            fplayers = qualifying switch
            {
                "Qualified Players" => fplayers.Where(player => player.PitchingStats.IP / player.PitchingStats.TGP >= 1.1 && player.PlayersInTeam is not null).ToList(),
                "Active Players" => fplayers.Where(player => player.PlayersInTeam.First().CurrentPlayerInTeamStatus == InTeamStatusEnum.ActiveRoster && player.CanPlayAsPitcher).ToList(),
                _ => fplayers
            };

            return fplayers;
        }

        private List<string> GetTeamsForFilter(string TeamFilter)
        {
            var teams = _teamsDao.GetList().ToList();

            return TeamFilter switch
            {
                "MLB" => teams.Select(team => team.TeamAbbreviation).ToList(),
                "AL" or "NL" => teams.Where(team => team.Division.LeagueId == TeamFilter)
                    .Select(team => team.TeamAbbreviation).ToList(),
                _ => teams.Where(team => team.TeamName == TeamFilter)
                    .Select(team => team.TeamAbbreviation).ToList()
            };
        }

        public List<PlayerPosition> GetPlayerPositions() => _statsDao.GetPlayerPositions().ToList();
    }
}