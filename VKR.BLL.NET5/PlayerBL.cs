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
        private List<Player> _players;

        public List<Player> GetBattersStats(string TeamFilter = "MLB", string qualifying = "Qualified Players", string positions = "")
        {
            _players = _playerDAO.GetAllPlayers().ToList();
            var abbreviations = GetTeamsForFilter(TeamFilter);
            var fplayers = _players.Where(player => abbreviations.Contains(player.Team)).ToList();

            if (positions != "")
                if (positions == "OF")
                {
                    var lf = fplayers.Where(batter => batter.PlayerPositions.Contains("LF")).ToList();
                    var cf = fplayers.Where(batter => batter.PlayerPositions.Contains("CF")).ToList();
                    var rf = fplayers.Where(batter => batter.PlayerPositions.Contains("RF")).ToList();
                    fplayers = lf.Union(cf).Union(rf).Distinct().ToList();
                }
                else
                    fplayers = fplayers.Where(player => player.PlayerPositions.Contains(positions)).ToList();

            fplayers = qualifying switch
            {
                "Qualified Players" => fplayers.Where(player => (double)player.BattingStats.PA / player.BattingStats.TGP >= 3.1 && player.Team != "").ToList(),
                "Active Players" => fplayers.Where(player => player.InActiveRoster).ToList(),
                _ => fplayers
            };

            return fplayers;
        }

        public List<Player> GetPitchersStats(string qualifying = "Qualified Players", string teamFilter = "MLB")
        {
            _players = _playerDAO.GetAllPlayers().ToList();
            var abbreviations = GetTeamsForFilter(teamFilter);
            var fplayers = _players.Where(player => abbreviations.Contains(player.Team)).ToList();

            fplayers = qualifying switch
            {
                "Qualified Players" => fplayers.Where(player => player.PitchingStats.IP / player.PitchingStats.Tgp >= 1.1 && player.Team != "").ToList(),
                "Active Players" => fplayers.Where(player => player.InActiveRoster && player.PlayerPositions.Contains("P")).ToList(),
                _ => fplayers
            };

            return fplayers;
        }

        private List<string> GetTeamsForFilter(string TeamFilter)
        {
            var teamsAbbreviations = new List<string>();
            var teams = _teamsDAO.GetList().ToList();

            switch (TeamFilter)
            {
                case "MLB":
                    teamsAbbreviations.AddRange(teams.Select(team => team.TeamAbbreviation).ToList());
                    teamsAbbreviations.Add("");
                    break;
                case "AL":
                case "NL":
                    teamsAbbreviations.AddRange(teams.Where(team => team.League == TeamFilter).Select(team => team.TeamAbbreviation).ToList());
                    break;
                default:
                    teamsAbbreviations.AddRange(teams.Where(team => team.TeamTitle == TeamFilter).Select(team => team.TeamAbbreviation).ToList());
                    break;
            }
            return teamsAbbreviations;
        }

        public List<List<List<PlayerInLineup>>> GetRoster(string rosterType)
        {
            var ungroupedPlayers = rosterType == "GetStartingLineups" ? _playerDAO.GetStartingLineups().ToList() : _playerDAO.GetRoster(rosterType).ToList();

            foreach (var playerInLineup in ungroupedPlayers)
                playerInLineup.PlayerPositions = _playerDAO.GetPositionsForThisPlayer(playerInLineup.Id).ToList();

            var teams = _teamsDAO.GetList().ToList();
            var lineups = ungroupedPlayers.Select(player => player.LineupType).OrderBy(number => number).Distinct().ToList();

            var groupedPlayers = new List<List<List<PlayerInLineup>>>();

            for (var i = 0; i < teams.Count; i++)
            {
                groupedPlayers.Add(new List<List<PlayerInLineup>>());
                foreach (var lineupType in lineups)
                    groupedPlayers[i].Add(ungroupedPlayers.Where(player => player.Team == teams[i].TeamAbbreviation && player.LineupType == lineupType)
                                                              .OrderBy(player => player.NumberInLineup).ToList());
            }

            return groupedPlayers;
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