using System;
using System.Collections.Generic;
using System.Linq;
using VKR.DAL.NET5;
using VKR.EF.DAO;
using VKR.EF.Entities;
using VKR.Entities.NET5;
using Match = VKR.Entities.NET5.Match;
using Player = VKR.Entities.NET5.Player;
using PlayerPosition = VKR.Entities.NET5.PlayerPosition;
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
                "Active Players" => players.Where(player => player.PlayersInTeam.First().CurrentPlayerInTeamStatus == InTeamStatusEnum.ActiveRoster).ToList(),
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
                "Active Players" => fplayers.Where(player => player.PlayersInTeam.First().CurrentPlayerInTeamStatus == InTeamStatusEnum.ActiveRoster && player.CanPlayAsPitcher).ToList(),
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

        public List<List<List<PlayerInLineupViewModel>>> GetFreeAgents()
        {
            var allFreeAgents = _playerEFDAO.GetFreeAgents().ToList();
            var players = new List<List<List<PlayerInLineupViewModel>>> { new() };
            players[0].Add(allFreeAgents.OrderBy(player => player.SecondName).ThenBy(player => player.FirstName).ToList());
            return players;
        }

        public List<List<List<PlayerInLineupViewModel>>> GetRoster(TypeOfRoster typeOfRoster)
        {
            var rosterFuncs = new Dictionary<TypeOfRoster, Func<List<PlayerInLineupViewModel>>>
            {
                { TypeOfRoster.Starters, _playerEFDAO.GetStartingLineups },
                { TypeOfRoster.Bench , _playerEFDAO.GetBench},
                { TypeOfRoster.ActivePlayers, _playerEFDAO.GetActivePlayers },
                { TypeOfRoster.Reserve, _playerEFDAO.GetReserves },
                { TypeOfRoster.ActiveAndReserve, _playerEFDAO.GetActiveAndReservePlayers }
            };

            var allPlayers = new List<PlayerInLineupViewModel>();

            if(rosterFuncs.TryGetValue(typeOfRoster, out var playersFunc)) allPlayers = playersFunc();
            var teams = _teamsEFDAO.GetList().ToList();

            var lineups = allPlayers.Select(player => player.LineupNumber).OrderBy(number => number).Distinct().ToList();
            var players = new List<List<List<PlayerInLineupViewModel>>>();
            for (var i = 0; i < teams.Count; i++)
            {
                players.Add(new List<List<PlayerInLineupViewModel>>());
                foreach (var lineupType in lineups)
                    players[i].Add(allPlayers
                        .Where(player => player.TeamAbbreviation == teams[i].TeamAbbreviation && player.LineupNumber == lineupType)
                        .OrderBy(player => player.NumberInLineup)
                        .ThenBy(player => player.SecondName)
                        .ThenBy(player => player.FirstName).ToList());
            }

            return players;
        }

        public Player GetPlayerByCode(int code) => _playerDAO.GetPlayerByCode(code).First();

        public List<PlayerPosition> GetPlayerPositions() => _playerDAO.GetPlayerPositions().ToList();

        public List<Batter> GetCurrentLineupForThisMatch(string team, int match) => _playerDAO.GetCurrentLineupForThisMatch(team, match).ToList();

        public void UpdateStatsForThisPitcher(Pitcher pitcher, Match match)
        {
            pitcher.RemainingStamina = _playerDAO.GetNumberOfOutsPlayedByThisPitcherInLast5Days(pitcher.Id, match.MatchID);
            pitcher.PitchingStats = _playerDAO.GetPitchingStatsByCode(pitcher).FirstOrDefault();
        }

        public Pitcher GetStartingPitcherForThisTeam(Team team, Match match)
        {
            var pitcher = _playerDAO.GetStartingPitcherForThisTeam(team, match).First();
            pitcher.RemainingStamina = _playerDAO.GetNumberOfOutsPlayedByThisPitcherInLast5Days(pitcher.Id, match.MatchID);
            return pitcher;
        }

        public List<Pitcher> GetAvailablePitchers(Match match, Team team) => _playerDAO.GetAvailablePitchers(match, team).ToList();

        public void SubstitutePitcher(Match match, Team team, Pitcher pitcher) => _teamsDAO.SubstitutePitcher(match, team, pitcher);

        public List<Batter> GetAvailableBatters(Match match, Team team, Batter batter) => _playerDAO.GetAvailableBatters(match, team, batter).ToList();

        public void SubstituteBatter(Match match, Team team, Batter oldBatter, Batter newBatter) => _teamsDAO.SubstituteBatter(match, team, oldBatter, newBatter);

        public int ReturnNumberOfOutsPlayedByThisPitcherInLast5Days(Pitcher pitcher, Match match) => _playerDAO.GetNumberOfOutsPlayedByThisPitcherInLast5Days(pitcher.Id, match.MatchID);

        public Pitcher GetPitcherByCode(int id)
        {
            var pitcher = new Pitcher(_playerDAO.GetPlayerByCode(id).First());
            pitcher.RemainingStamina = _playerDAO.GetNumberOfOutsPlayedByThisPitcherInLast5Days(pitcher.Id);
            return pitcher;
        }

        public PlayerBattingStats GetBattingStatsByCode(uint id, int year) => _playerEFDAO.GetBattingStatsByCode(id, year);

        public PlayerPitchingStats GetPitchingStatsByCode(uint id, int year) =>
            _playerEFDAO.GetPitchingStatsByCode(id, year);
    }
}