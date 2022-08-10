﻿using System;
using System.Collections.Generic;
using System.Linq;
using VKR.EF.DAO;
using VKR.EF.Entities;

namespace VKR.BLL.NET5
{
    public class PlayerBL
    {
        public enum TypeOfRoster {Starters, Bench, ActivePlayers, Reserve, ActiveAndReserve}
        
        private readonly PlayerEFDAO _playerEFDAO = new();
        private readonly TeamsEFDAO _teamsEFDAO = new();

        public List<Player> GetBattersStats(string TeamFilter = "MLB", string qualifying = "Qualified Players", string positions = "")
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

        public List<Player> GetPitchersStats(string qualifying = "Qualified Players", string teamFilter = "MLB")
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

        public Player GetPlayerByCode(uint code) => _playerEFDAO.GetPlayerByCode(code);

        public List<PlayerPosition> GetPlayerPositions() => _playerEFDAO.GetPlayerPositions().ToList();

        public List<Batter> GetCurrentLineupForThisMatch(Team team, Match match) => _playerEFDAO.GetCurrentBattingLineup(team, match).ToList();

        public void UpdateStatsForThisPitcher(Pitcher pitcher, Match match)
        {
            pitcher.PitchingStats = GetPitchingStatsByCode(pitcher.Id, match.MatchDate.Year, match.MatchTypeId);
            pitcher.RemainingStamina = _playerEFDAO.GetPitcherStamina(pitcher.Id, match.MatchDate);
        }

        public Pitcher GetStartingPitcherForThisTeam(Team team, Match match)
        {
            var pitcher = _playerEFDAO.GetStartingPitcherForThisTeam(match, team);
            pitcher.PitchingStats = GetPitchingStatsByCode(pitcher.Id, match.MatchDate.Year, match.MatchTypeId);
            pitcher.RemainingStamina = _playerEFDAO.GetPitcherStamina(pitcher.Id, match.MatchDate);
            return pitcher;
        }

        public List<Pitcher> GetAvailablePitchers(Match match, Team team)
        {
            var pitchers = _playerEFDAO.GetAvailablePitchers(match, team).ToList();
            foreach (var pitcher in pitchers)
                pitcher.RemainingStamina = _playerEFDAO.GetPitcherStamina(pitcher.Id, match.MatchDate);
            return pitchers;
        }

        public List<Batter> GetAvailableBatters(Match match, Team team, Batter batter) => _playerEFDAO.GetAvailableBatters(match, team, batter).ToList();

        public int GetPitcherStamina(Pitcher pitcher, Match match) => _playerEFDAO.GetPitcherStamina(pitcher.Id, match.MatchDate);

        public PlayerBattingStats GetBattingStatsByCode(uint id, int year) => _playerEFDAO.GetBattingStatsByCode(id, year);

        public PlayerPitchingStats GetPitchingStatsByCode(uint id, int year, TypeOfMatchEnum matchType = TypeOfMatchEnum.RegularSeason) =>
            _playerEFDAO.GetPitchingStatsByCode(id, year, matchType);
    }
}