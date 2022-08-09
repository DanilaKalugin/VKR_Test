using System;
using System.Collections.Generic;
using System.Linq;
using VKR.DAL.NET5;
using VKR.EF.DAO;
using VKR.EF.Entities;
using Batter = VKR.Entities.NET5.Batter;
using Match = VKR.Entities.NET5.Match;
using Pitcher = VKR.Entities.NET5.Pitcher;
using Team = VKR.Entities.NET5.Team;

namespace VKR.BLL.NET5
{
    public class PlayerBL
    {
        public enum TypeOfRoster {Starters, Bench, ActivePlayers, Reserve, ActiveAndReserve}

        private readonly PlayerDao _playerDAO = new();
        private readonly TeamsDao _teamsDAO = new();
        private readonly PlayerEFDAO _playerEFDAO = new();
        private readonly TeamsEFDAO _teamsEFDAO = new();

        public List<EF.Entities.Player> GetBattersStats(string TeamFilter = "MLB", string qualifying = "Qualified Players", string positions = "")
        {
            var players = _playerEFDAO.GetPlayerBattingStats(2021).ToList();
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
                "Active Players" => players.Where(player => player.PlayersInTeam.First().CurrentPlayerInTeamStatus == EF.Entities.InTeamStatusEnum.ActiveRoster).ToList(),
                _ => players
            };

            return players;
        }

        public List<EF.Entities.Player> GetPitchersStats(string qualifying = "Qualified Players", string teamFilter = "MLB")
        {
            var players = _playerEFDAO.GetPlayerPitchingStats(2021).ToList();
            var abbreviations = GetTeamsForFilter(teamFilter);
            var fplayers = players.Where(player => player.PlayersInTeam.Count > 0 && abbreviations.Contains(player.PlayersInTeam.First().TeamId)).ToList();

            fplayers = qualifying switch
            {
                "Qualified Players" => fplayers.Where(player => player.PitchingStats.IP / player.PitchingStats.TGP >= 1.1 && player.PlayersInTeam is not null).ToList(),
                "Active Players" => fplayers.Where(player => player.PlayersInTeam.First().CurrentPlayerInTeamStatus == EF.Entities.InTeamStatusEnum.ActiveRoster && player.CanPlayAsPitcher).ToList(),
                _ => fplayers
            };

            return fplayers;
        }

        private List<string> GetTeamsForFilter(string TeamFilter)
        {
            var teams = _teamsEFDAO.GetList().ToList();

            return TeamFilter switch
            {
                "MLB" => teams.Select(team => team.TeamAbbreviation).ToList(),
                "AL" or "NL" => teams.Where(team => team.Division.LeagueId == TeamFilter)
                    .Select(team => team.TeamAbbreviation).ToList(),
                _ => teams.Where(team => team.TeamName == TeamFilter)
                    .Select(team => team.TeamAbbreviation).ToList()
            };
        }

        public List<List<List<EF.Entities.PlayerInLineupViewModel>>> GetFreeAgents()
        {
            var allFreeAgents = _playerEFDAO.GetFreeAgents().ToList();
            var players = new List<List<List<EF.Entities.PlayerInLineupViewModel>>> { new() };
            players[0].Add(allFreeAgents.OrderBy(player => player.SecondName).ThenBy(player => player.FirstName).ToList());
            return players;
        }

        public List<List<List<EF.Entities.PlayerInLineupViewModel>>> GetRoster(TypeOfRoster typeOfRoster)
        {
            var rosterFuncs = new Dictionary<TypeOfRoster, Func<List<EF.Entities.PlayerInLineupViewModel>>>
            {
                { TypeOfRoster.Starters, _playerEFDAO.GetStartingLineups },
                { TypeOfRoster.Bench , _playerEFDAO.GetBench},
                { TypeOfRoster.ActivePlayers, _playerEFDAO.GetActivePlayers },
                { TypeOfRoster.Reserve, _playerEFDAO.GetReserves },
                { TypeOfRoster.ActiveAndReserve, _playerEFDAO.GetActiveAndReservePlayers }
            };

            var allPlayers = new List<EF.Entities.PlayerInLineupViewModel>();

            if(rosterFuncs.TryGetValue(typeOfRoster, out var playersFunc)) allPlayers = playersFunc();
            var teams = _teamsEFDAO.GetList().ToList();

            var lineups = allPlayers.Select(player => player.LineupNumber).OrderBy(number => number).Distinct().ToList();
            var players = new List<List<List<EF.Entities.PlayerInLineupViewModel>>>();
            for (var i = 0; i < teams.Count; i++)
            {
                players.Add(new List<List<EF.Entities.PlayerInLineupViewModel>>());
                foreach (var lineupType in lineups)
                    players[i].Add(allPlayers
                        .Where(player => player.TeamAbbreviation == teams[i].TeamAbbreviation && player.LineupNumber == lineupType)
                        .OrderBy(player => player.NumberInLineup)
                        .ThenBy(player => player.SecondName)
                        .ThenBy(player => player.FirstName).ToList());
            }

            return players;
        }

        public EF.Entities.Player GetPlayerByCode(uint code) => _playerEFDAO.GetPlayerByCode(code);

        public List<EF.Entities.PlayerPosition> GetPlayerPositions() => _playerEFDAO.GetPlayerPositions().ToList();

        public List<EF.Entities.Batter> GetCurrentLineupForThisMatch(EF.Entities.Team team, EF.Entities.Match match) => _playerEFDAO.GetCurrentBattingLineup(team, match).ToList();

        public void UpdateStatsForThisPitcher(EF.Entities.Pitcher pitcher, EF.Entities.Match match)
        {
            pitcher.PitchingStats = GetPitchingStatsByCode(pitcher.Id, match.MatchDate.Year, match.MatchTypeId);
            pitcher.RemainingStamina = _playerEFDAO.GetPitcherStamina(pitcher.Id, match.MatchDate);
        }

        public EF.Entities.Pitcher GetStartingPitcherForThisTeam(EF.Entities.Team team, EF.Entities.Match match)
        {
            var pitcher = _playerEFDAO.GetStartingPitcherForThisTeam(match, team);
            pitcher.PitchingStats = GetPitchingStatsByCode(pitcher.Id, match.MatchDate.Year, match.MatchTypeId);
            pitcher.RemainingStamina = _playerEFDAO.GetPitcherStamina(pitcher.Id, match.MatchDate);
            return pitcher;
        }

        public List<Pitcher> GetAvailablePitchers(Match match, Team team) => _playerDAO.GetAvailablePitchers(match, team).ToList();

        public void SubstitutePitcher(Match match, Team team, Pitcher pitcher) => _teamsDAO.SubstitutePitcher(match, team, pitcher);

        public List<Batter> GetAvailableBatters(Match match, Team team, Batter batter) => _playerDAO.GetAvailableBatters(match, team, batter).ToList();

        public void SubstituteBatter(Match match, Team team, Batter oldBatter, Batter newBatter) => _teamsDAO.SubstituteBatter(match, team, oldBatter, newBatter);

        public int ReturnNumberOfOutsPlayedByThisPitcherInLast5Days(EF.Entities.Pitcher pitcher, EF.Entities.Match match) => _playerEFDAO.GetPitcherStamina(pitcher.Id, match.MatchDate);

        public EF.Entities.PlayerBattingStats GetBattingStatsByCode(uint id, int year) => _playerEFDAO.GetBattingStatsByCode(id, year);

        public EF.Entities.PlayerPitchingStats GetPitchingStatsByCode(uint id, int year, TypeOfMatchEnum matchType = TypeOfMatchEnum.RegularSeason) =>
            _playerEFDAO.GetPitchingStatsByCode(id, year, matchType);
    }
}