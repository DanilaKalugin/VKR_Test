using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using VKR.DAL;

namespace VKR.BLL
{
    public class TeamsBL
    {
        private readonly TeamsDAO teamsDAO;

        public TeamsBL()
        {
            teamsDAO = new TeamsDAO();
        }

        public List<Team> GetAllTeams()
        {
            List<Team> teams = teamsDAO.GetList().ToList();
            double MaxOffensiveRating = teams.Select(team => team.OffensiveRating()).Max();
            double MaxDefensiveRating = teams.Select(team => team.DefensiveRating()).Max();
            foreach (Team team in teams)
            {
                team.NormalizedOffensiveRating = (int)(team.OffensiveRating() / MaxOffensiveRating * 99);
                team.NormalizedDefensiveRating = (int)(team.DefensiveRating() / MaxDefensiveRating * 99);
            }
            return teams;
        }

        public List<Team> GetStandings(string Filter, DateTime date)
        {
            List<Team> teams = teamsDAO.GetStandings(date).ToList();

            if (Filter != "MLB")
            {
                if (Filter == "NL" || Filter == "AL")
                {
                    teams = teams.Where(team => team.League == Filter).ToList();
                }
                else
                {
                    teams = teams.Where(team => team.Division == Filter).ToList();
                }
            }
            int LeaderW = teams[0].Wins;
            int LeaderL = teams[0].Losses;

            foreach (Team team in teams)
            {
                team.GamesBehind = (double)(LeaderW - LeaderL - (team.Wins - team.Losses)) / 2;
            }
            teams = teams.OrderBy(team => team.GamesBehind).ThenByDescending(team => team.Wins).ThenByDescending(team => team.RunDifferential).ThenByDescending(team => team.RunsScored).ToList();

            double leadGB = teams[0].GamesBehind;
            if (leadGB < 0)
            {
                foreach (Team team in teams)
                {
                    team.GamesBehind -= leadGB;
                }
            }
            return teams;
        }

        public List<Pitcher> GetStartingPitcherForThisTeam(Team team, Match match)
        {
            return teamsDAO.GetStartingPitcherForThisTeam(team, match.MatchID).ToList();
        }

        public void UpdateStatsForThisPitcher(Pitcher pitcher)
        {
            Pitcher PitcherWithNewStats = teamsDAO.UpdateStatsForThisPitcher(pitcher).First();
            pitcher.CaughtStealing = PitcherWithNewStats.CaughtStealing;
            pitcher.Games = PitcherWithNewStats.Games;
            pitcher.SinglesAllowed = PitcherWithNewStats.SinglesAllowed;
            pitcher.StolenBasesAllowed = PitcherWithNewStats.StolenBasesAllowed;
            pitcher.DoublesAllowed = PitcherWithNewStats.DoublesAllowed;
            pitcher.HitByPitch = PitcherWithNewStats.HitByPitch;
            pitcher.HomeRunsAllowed = PitcherWithNewStats.HomeRunsAllowed;
            pitcher.Outs = PitcherWithNewStats.Outs;
            pitcher.SacrificeBunts = PitcherWithNewStats.SacrificeBunts;
            pitcher.SacrificeFlies = PitcherWithNewStats.SacrificeFlies;
            pitcher.Strikeouts = PitcherWithNewStats.Strikeouts;
            pitcher.TotalBattersFaced = PitcherWithNewStats.TotalBattersFaced;
            pitcher.TriplesAllowed = PitcherWithNewStats.TriplesAllowed;
            pitcher.WalksAllowed = PitcherWithNewStats.WalksAllowed;
            pitcher.RunsAllowed = PitcherWithNewStats.RunsAllowed;
        }

        public List<Batter> GetCurrentLineupForThisMatch(string Team, int Match)
        {
            return teamsDAO.GetCurrentLineupForThisMatch(Team, Match).ToList();
        }

        public List<Pitcher> GetAvailablePitchers(Match match, Team team)
        {
            return teamsDAO.GetAvailablePitchers(match, team).ToList();
        }

        public void SubstitutePitcher(Match match, Team team, Pitcher pitcher)
        {
            teamsDAO.SubstitutePitcher(match, team, pitcher);
        }

        public List<Batter> GetAvailableBatters(Match match, Team team, Batter batter)
        {
            return teamsDAO.GetAvailableBatters(match, team, batter).ToList();
        }

        public List<Team> GetSortedTeamStatsDesc<Tkey>(List<Team> teams, Func<Team, Tkey> key)
        {
            return teams.OrderByDescending(key).ToList();
        }

        public List<Team> GetSortedTeamStats<Tkey>(List<Team> teams, Func<Team, Tkey> key)
        {
            return teams.OrderBy(key).ToList();
        }

        public void SubstituteBatter(Match match, Team team, Batter oldBatter, Batter newBatter)
        {
            teamsDAO.SubstituteBatter(match, team, oldBatter, newBatter);
        }

        public Pitcher GetPitcherByID(int id)
        {
            return teamsDAO.GetPitcherByID(id).First();
        }

        public void UpdateTeamBalance(Team team)
        {
            Team TeamWithNewBalance = teamsDAO.UpdateBalanceForThisTeam(team).First();
            team.Wins = TeamWithNewBalance.Wins;
            team.Losses = TeamWithNewBalance.Losses;
        }

        public List<Team> GetTeamBattingStats()
        {
            return teamsDAO.ReturnTeamBattingStats().OrderByDescending(team => team.AVG).ToList();
        }
    }
}