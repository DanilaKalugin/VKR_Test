using System.Collections.Generic;
using System.Linq;
using Entities.NET5;
using VKR.DAL.NET5;

namespace VKR.BLL.NET5
{
    public class PlayerBL
    {
        private readonly PlayerDAO _playerDAO = new();
        private readonly TeamsDAO _teamsDAO = new();
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
            List<PlayerInLineup> ungroupedPlayers = rosterType == "GetStartingLineups" ? _playerDAO.GetStartingLineups().ToList() : _playerDAO.GetRoster(rosterType).ToList();
            
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

        public List<List<List<PlayerInLineup>>> GetFreeAgents()
        {
            var ungroupedPlayers = _playerDAO.GetRoster("GetFreeAgents").ToList();
            
            foreach (var playerInLineup in ungroupedPlayers)
                playerInLineup.PlayerPositions = _playerDAO.GetPositionsForThisPlayer(playerInLineup.Id).ToList();

            var Lineups = ungroupedPlayers.Select(player => player.LineupType).OrderBy(number => number).Distinct().ToList();

            var groupedPlayers = new List<List<List<PlayerInLineup>>> { new()};
            
            foreach (var lineupType in Lineups)
                groupedPlayers[0].Add(ungroupedPlayers.Where(player => player.LineupType == lineupType).OrderBy(player => player.NumberInLineup).ToList());

            return groupedPlayers;
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
    }
}