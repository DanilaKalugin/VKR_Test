using System.Collections.Generic;
using System.Linq;
using VKR.DAL;
using Entities;
using System;

namespace VKR.BLL
{
    public class PlayerBL
    {
        private readonly PlayerDAO playerDAO;
        private readonly TeamsDAO teamsDAO;

        public PlayerBL()
        {
            teamsDAO = new TeamsDAO();
            playerDAO = new PlayerDAO();
        }

        public List<Batter> GetBattersStats(string TeamFilter = "MLB", string Qualifying = "Qualified Players", string Positions = "")
        {
            List<string> abbreviations = GetTeamsForFilter(TeamFilter);

            List<Batter> batters = playerDAO.GetBattersStats().ToList();
            foreach (Batter batter in batters)
            {
                batter.PlayerPositions = playerDAO.GetPositionsForThisPlayer(batter.id).ToList();
            }
            batters = batters.Where(player => abbreviations.IndexOf(player.Team) != -1).ToList();
            if (Positions != "")
            {
                if (Positions == "OF")
                {
                    List<Batter> lf = batters.Where(batter => batter.PlayerPositions.IndexOf("LF") != -1).ToList();
                    List<Batter> cf = batters.Where(batter => batter.PlayerPositions.IndexOf("CF") != -1).ToList();
                    List<Batter> rf = batters.Where(batter => batter.PlayerPositions.IndexOf("RF") != -1).ToList();
                    batters = lf.Union(cf).Union(rf).Distinct().ToList();
                }
                else
                {
                    batters = batters.Where(player => player.PlayerPositions.IndexOf(Positions) != -1).ToList();
                }
            }
            if (Qualifying == "Qualified Players")
            {
                batters = batters.Where(player => (double)player.PA / player.TGP >= 3.1 && player.Team != "").ToList();
            }
            else if (Qualifying == "Active Players")
            {
                batters = batters.Where(player => player.InActiveRoster).ToList();
            }
            else if (Qualifying == "Active and Reserve Players")
            {
                batters = batters.Where(player => player.Team != "").ToList();
            }
            else if (Qualifying == "Free Agents")
            {
                batters = batters.Where(player => player.Team == "").ToList();
            }
            return batters;
        }

        public List<Batter> GetSortedBattersStatsDesc<Tkey>(List<Batter> batters, Func<Batter, Tkey> key)
        {
            return batters.OrderByDescending(key).ToList();
        }

        public List<Batter> GetSortedBattersStats<Tkey>(List<Batter> batters, Func<Batter, Tkey> key)
        {
            return batters.OrderBy(key).ToList();
        }

        public List<Pitcher> GetPitchersStats(string Qualifying = "Qualified Players", string TeamFilter = "MLB")
        {
            List<string> abbreviations = GetTeamsForFilter(TeamFilter);

            List<Pitcher> pitchers = playerDAO.GetPitchersStats().ToList();
            foreach (Pitcher pitcher in pitchers)
            {
                pitcher.PlayerPositions = playerDAO.GetPositionsForThisPlayer(pitcher.id).ToList();
            }
            pitchers = pitchers.Where(player => abbreviations.IndexOf(player.Team) != -1).ToList();
            if (Qualifying == "Qualified Players")
            {
                pitchers = pitchers.Where(player => player.IP / player.TGP >= 1.1 && player.Team != "").ToList();
            }
            else if (Qualifying == "Active Players")
            {
                pitchers = pitchers.Where(player => player.InActiveRoster).ToList();
            }
            else if (Qualifying == "Active and Reserve Players")
            {
                pitchers = pitchers.Where(player => player.Team != "").ToList();
            }
            else if (Qualifying == "Free Agents")
            {
                pitchers = pitchers.Where(player => player.Team == "").ToList();
            }
            return pitchers;
        }

        public List<Pitcher> GetSortedPitchersStatsDesc<Tkey>(List<Pitcher> pitchers, Func<Pitcher, Tkey> key)
        {
            return pitchers.OrderByDescending(key).ToList();
        }

        public List<Pitcher> GetSortedPitchersStats<Tkey>(List<Pitcher> pitchers, Func<Pitcher, Tkey> key)
        {
            return pitchers.OrderBy(key).ToList();
        }

        private List<string> GetTeamsForFilter(string TeamFilter)
        {
            List<string> teamsabbreviations = new List<string>();
            List<Team> teams = teamsDAO.GetList().ToList();
            if (TeamFilter == "MLB")
            {
                teamsabbreviations.AddRange(teams.Select(team => team.TeamAbbreviation).ToList());
                teamsabbreviations.Add("");
            }
            else teamsabbreviations.AddRange(teams.Where(team => team.TeamTitle == TeamFilter).Select(team => team.TeamAbbreviation).ToList());
            return teamsabbreviations;
        }

        public List<List<List<PlayerInLineup>>> GetRoster(string rosterType)
        {
            List<PlayerInLineup> ungroupedPlayers;
            if (rosterType == "GetStartingLineups")
            {
                ungroupedPlayers = playerDAO.GetStartingLineups().ToList();
            }
            else
            {
                ungroupedPlayers = playerDAO.GetRoster(rosterType).ToList();
            }
            for (int i = 0; i < ungroupedPlayers.Count; i++)
            {
                ungroupedPlayers[i].PlayerPositions = playerDAO.GetPositionsForThisPlayer(ungroupedPlayers[i].id).ToList();
            }
            List<Team> Teams = teamsDAO.GetList().ToList();
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
            List<PlayerInLineup> ungroupedPlayers = playerDAO.GetRoster("GetFreeAgents").ToList();
            for (int i = 0; i < ungroupedPlayers.Count; i++)
            {
                ungroupedPlayers[i].PlayerPositions = playerDAO.GetPositionsForThisPlayer(ungroupedPlayers[i].id).ToList();
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

        public string GetPlayerNameByID(int code)
        {
            Player PlayerByCode = playerDAO.GetPlayerNameByID(code).First();
            return $"{PlayerByCode.FirstName[0]}. {PlayerByCode.SecondName}";
        }

        public string GetFullPlayerNameByID(int code)
        {
            Player PlayerByCode = playerDAO.GetPlayerNameByID(code).First();
            return $"{PlayerByCode.FullName}";
        }

        public Batter GetBatterByCode(int code)
        {
            return playerDAO.GetBatterByCode(code).First();
        }

        public Pitcher GetPitcherByCode(int code)
        {
            return playerDAO.GetPitcherByCode(code).First();
        }

        public List<PlayerPosition> GetPlayerPositions()
        {
            return playerDAO.GetPlayerPositions().ToList();
        }
    }
}