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

        public List<Team> GetTeamBattingStats(Season season, TypeOfMatchEnum typeOfMatch = TypeOfMatchEnum.RegularSeason)
        {
            return _statsDao.GetBattingStatsByYearAndMatchType(season.Year, typeOfMatch)
                .OrderByDescending(team => team.BattingStats.AVG).ToList();
        }

        public List<Team> GetTeamPitchingStats(Season season, TypeOfMatchEnum typeOfMatch = TypeOfMatchEnum.RegularSeason)
        {
            return _statsDao.GetPitchingStatsByYearAndMatchType(season.Year, typeOfMatch)
                .OrderBy(team => team.PitchingStats.ERA).ToList();
        }

        public List<Player> GetBattersStats(Season season, string TeamFilter = "MLB", string qualifying = "Qualified Players", string positions = "")
        {
            var players = _statsDao.GetPlayerBattingStats(season.Year).ToList();
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

        public List<Player> GetPitchersStats(Season season, string qualifying = "Qualified Players", string teamFilter = "MLB")
        {
            var players = _statsDao.GetPlayerPitchingStats(season.Year).ToList();
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

        private List<string> GetTeamsForFilter(string teamFilter)
        {
            var teams = _teamsDao.GetList().ToList();

            return teamFilter switch
            {
                "MLB" => teams.Select(team => team.TeamAbbreviation).ToList(),
                "AL" or "NL" => teams.Where(team => team.Division.LeagueId == teamFilter)
                    .Select(team => team.TeamAbbreviation).ToList(),
                _ => teams.Where(team => team.TeamName == teamFilter)
                    .Select(team => team.TeamAbbreviation).ToList()
            };
        }
    }
}