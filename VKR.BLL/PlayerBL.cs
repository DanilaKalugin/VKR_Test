using System.Collections.Generic;
using System.Linq;
using VKR.DAL;
using Entities;
using System;

namespace VKR.BLL
{
    public class PlayerBL
    {
        private readonly PlayerDAO _playerDAO;
        private readonly TeamsDAO _teamsDAO;
        private List<Player> _players;

        public PlayerBL()
        {
            _teamsDAO = new TeamsDAO();
            _playerDAO = new PlayerDAO();
            _players = _playerDAO.GetAllPlayers().ToList();
        }

        public List<Player> GetBattersStats(string TeamFilter = "MLB", string Qualifying = "Qualified Players", string Positions = "")
        {
            List<string> abbreviations = GetTeamsForFilter(TeamFilter);
            var fplayers = _players.Where(player => abbreviations.IndexOf(player.Team) != -1).ToList();
            if (Positions != "")
            {
                if (Positions == "OF")
                {
                    List<Player> lf = fplayers.Where(batter => batter.PlayerPositions.IndexOf("LF") != -1).ToList();
                    List<Player> cf = fplayers.Where(batter => batter.PlayerPositions.IndexOf("CF") != -1).ToList();
                    List<Player> rf = fplayers.Where(batter => batter.PlayerPositions.IndexOf("RF") != -1).ToList();
                    fplayers = lf.Union(cf).Union(rf).Distinct().ToList();
                }
                else
                {
                    fplayers = fplayers.Where(player => player.PlayerPositions.IndexOf(Positions) != -1).ToList();
                }
            }
            if (Qualifying == "Qualified Players")
            {
                fplayers = fplayers.Where(player => (double)player.battingStats.PA / player.battingStats.TGP >= 3.1 && player.Team != "").ToList();
            }
            else if (Qualifying == "Active Players")
            {
                fplayers = fplayers.Where(player => player.InActiveRoster).ToList();
            }
            return fplayers;
        }

        public List<Player> GetSortedBattersStatsDesc<Tkey>(List<Player> batters, Func<Player, Tkey> key) => batters.OrderByDescending(key).ToList();

        public List<Player> GetSortedBattersStats<Tkey>(List<Player> batters, Func<Player, Tkey> key) => batters.OrderBy(key).ToList();

        public List<Player> GetPitchersStats(string Qualifying = "Qualified Players", string TeamFilter = "MLB")
        {
            List<string> abbreviations = GetTeamsForFilter(TeamFilter);
            var fplayers = _players.Where(player => abbreviations.IndexOf(player.Team) != -1).ToList();
            if (Qualifying == "Qualified Players")
            {
                fplayers = fplayers.Where(player => player.pitchingStats.IP / player.pitchingStats.TGP >= 1.1 && player.Team != "").ToList();
            }
            else if (Qualifying == "Active Players")
            {
                fplayers = fplayers.Where(player => player.InActiveRoster && player.PlayerPositions.IndexOf("P") != -1).ToList();
            }
            return fplayers;
        }

        public List<Player> GetSortedPitchersStatsDesc<Tkey>(List<Player> pitchers, Func<Player, Tkey> key) => pitchers.OrderByDescending(key).ToList();

        public List<Player> GetSortedPitchersStats<Tkey>(List<Player> pitchers, Func<Player, Tkey> key) => pitchers.OrderBy(key).ToList();

        private List<string> GetTeamsForFilter(string TeamFilter)
        {
            List<string> teamsabbreviations = new List<string>();
            List<Team> teams = _teamsDAO.GetList().ToList();
            if (TeamFilter == "MLB")
            {
                teamsabbreviations.AddRange(teams.Select(team => team.TeamAbbreviation).ToList());
                teamsabbreviations.Add("");
            }
            else if (TeamFilter == "AL" || TeamFilter == "NL")
            {
                teamsabbreviations.AddRange(teams.Where(team => team.League == TeamFilter).Select(team => team.TeamAbbreviation).ToList());
            }
            else teamsabbreviations.AddRange(teams.Where(team => team.TeamTitle == TeamFilter).Select(team => team.TeamAbbreviation).ToList());
            return teamsabbreviations;
        }

        public List<List<List<PlayerInLineup>>> GetRoster(string rosterType)
        {
            List<PlayerInLineup> ungroupedPlayers;
            if (rosterType == "GetStartingLineups")
            {
                ungroupedPlayers = _playerDAO.GetStartingLineups().ToList();
            }
            else
            {
                ungroupedPlayers = _playerDAO.GetRoster(rosterType).ToList();
            }
            for (int i = 0; i < ungroupedPlayers.Count; i++)
            {
                ungroupedPlayers[i].PlayerPositions = _playerDAO.GetPositionsForThisPlayer(ungroupedPlayers[i].Id).ToList();
            }
            List<Team> Teams = _teamsDAO.GetList().ToList();
            List<int> Lineups = ungroupedPlayers.Select(player => player.LineupType).OrderBy(number => number).Distinct().ToList();

            List<List<List<PlayerInLineup>>> groupedPlayers = new List<List<List<PlayerInLineup>>>();
            for (int i = 0; i < Teams.Count; i++)
            {
                groupedPlayers.Add(new List<List<PlayerInLineup>>());
                for (int j = 0; j < Lineups.Count; j++)
                {
                    groupedPlayers[i].Add(ungroupedPlayers.Where(player => player.Team == Teams[i].TeamAbbreviation && player.LineupType == Lineups[j]).OrderBy(player => player.NumberInLineup).ToList());
                }
            }
            return groupedPlayers;
        }

        public List<List<List<PlayerInLineup>>> GetFreeAgents()
        {
            List<PlayerInLineup> ungroupedPlayers = _playerDAO.GetRoster("GetFreeAgents").ToList();
            for (int i = 0; i < ungroupedPlayers.Count; i++)
            {
                ungroupedPlayers[i].PlayerPositions = _playerDAO.GetPositionsForThisPlayer(ungroupedPlayers[i].Id).ToList();
            }
            List<int> Lineups = ungroupedPlayers.Select(player => player.LineupType).OrderBy(number => number).Distinct().ToList();

            List<List<List<PlayerInLineup>>> groupedPlayers = new List<List<List<PlayerInLineup>>>();
            groupedPlayers.Add(new List<List<PlayerInLineup>>());
            for (int j = 0; j < Lineups.Count; j++)
            {
                groupedPlayers[0].Add(ungroupedPlayers.Where(player => player.LineupType == Lineups[j]).OrderBy(player => player.NumberInLineup).ToList());
            }
            return groupedPlayers;
        }

        public Player GetPlayerByCode(int code)
        {
            return _playerDAO.GetPlayerByCode(code).First();
        }

        public List<PlayerPosition> GetPlayerPositions()
        {
            return _playerDAO.GetPlayerPositions().ToList();
        }

        public List<Batter> GetCurrentLineupForThisMatch(string Team, int Match)
        {
            return _playerDAO.GetCurrentLineupForThisMatch(Team, Match).ToList();
        }

        public void UpdateStatsForThisPitcher(Pitcher pitcher, Match match)
        {
            pitcher.pitchingStats = _playerDAO.GetPitchingStatsByCode(pitcher).FirstOrDefault();
        }

        public Pitcher GetStartingPitcherForThisTeam(Team team, Match match)
        {
            var pitcher = _playerDAO.GetStartingPitcherForThisTeam(team, match).First();
            pitcher.RemainingStamina = _playerDAO.GetNumberOfOutsPlayedByThisPitcherInLast5Days(pitcher.Id);
            return pitcher;
        }

        public List<Pitcher> GetAvailablePitchers(Match match, Team team)
        {
            return _playerDAO.GetAvailablePitchers(match, team).ToList();
        }

        public void SubstitutePitcher(Match match, Team team, Pitcher pitcher)
        {
            _teamsDAO.SubstitutePitcher(match, team, pitcher);
        }

        public List<Batter> GetAvailableBatters(Match match, Team team, Batter batter)
        {
            return _teamsDAO.GetAvailableBatters(match, team, batter).ToList();
        }

        public void SubstituteBatter(Match match, Team team, Batter oldBatter, Batter newBatter)
        {
            _teamsDAO.SubstituteBatter(match, team, oldBatter, newBatter);
        }

        public int ReturnNumberOfOutsPlayedByThisPitcherInLast5Days(Pitcher pitcher)
        {
            return _playerDAO.GetNumberOfOutsPlayedByThisPitcherInLast5Days(pitcher.Id);
        }

        public Pitcher GetPitcherByCode(int id)
        {
            var pitcher = new Pitcher(_playerDAO.GetPlayerByCode(id).First());
            pitcher.RemainingStamina = _playerDAO.GetNumberOfOutsPlayedByThisPitcherInLast5Days(pitcher.Id);
            return pitcher;
        }
    }
}