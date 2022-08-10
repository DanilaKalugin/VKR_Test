﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class MatchEFDAO
    {
        public DateTime GetDateForNextMatch(TypeOfMatchEnum matchType)
        {
            using var db = new VKRApplicationContext();
            return db.NextMatches.Where(match => match.MatchTypeId == matchType && !match.IsPlayed).Min(match => match.MatchDate);
        }
        public IEnumerable<MatchFromSchedule> GetRemainingScheduleForThisDay(DateTime date, TypeOfMatchEnum matchType)
        {
            using var db = new VKRApplicationContext();
            return db.NextMatches.Where(nm => !nm.IsPlayed && nm.MatchTypeId == matchType && nm.MatchDate == date).ToList();
        }

        public DateTime GetMaxDateForAllMatches()
        {
            using var db = new VKRApplicationContext();
            return db.Matches.Include(m => m.MatchResult)
                .Where(m => m.MatchResult != null)
                .Select(m => m.MatchDate).Max();
        }

        public List<MatchScheduleViewModel> GetResultsForAllMatches()
        {
            using var db = new VKRApplicationContext();

            var matches = db.Matches.Include(m => m.MatchResult)
                .Include(match => match.Stadium)
                .ThenInclude(stadium => stadium.StadiumCity);

            var results = matches
                .Where(m => m.MatchResult != null)
                .Select(m => new MatchScheduleViewModel(true, m.MatchEnded, m.AwayTeamAbbreviation, m.HomeTeamAbbreviation, m.MatchResult.Length, m.MatchResult.AwayTeamRuns, m.MatchResult.HomeTeamRuns, m.Stadium, m.MatchDate)).ToList();

            var activeMatches = db.ActiveMatchResults.ToList();

            var activeMatchResults = matches.ToList()
                .Join(activeMatches,
                    match => match.Id,
                    activeMatch => activeMatch.MatchId,
                    (match, res) => new MatchScheduleViewModel(true, match.MatchEnded, match.AwayTeamAbbreviation,
                        match.HomeTeamAbbreviation, res.Inning, res.AwayTeamRuns, res.HomeTeamRuns, match.Stadium,
                        match.MatchDate)).ToList();

            return results.Union(activeMatchResults).ToList();
        }

        public List<MatchScheduleViewModel> GetScheduleForAllMatches()
        {
            using var db = new VKRApplicationContext();
            return db.NextMatches.Include(m => m.HomeTeam)
                .ThenInclude(team => team.StadiumsForMatchTypes)
                .ThenInclude(tmts => tmts.Stadium)
                .ThenInclude(stadium => stadium.StadiumCity)
                .Where(m => !m.IsPlayed)
                .Select(m => new MatchScheduleViewModel(m.IsPlayed, false, m.AwayTeamAbbreviation, m.HomeTeamAbbreviation, 1, 0, 0, m.HomeTeam.StadiumsForMatchTypes.First().Stadium, m.MatchDate)).ToList();
        }

        public int GetNextMatchId(TypeOfMatchEnum matchType)
        {
            using var db = new VKRApplicationContext();

            var maxId = matchType == TypeOfMatchEnum.QuickMatch
                ? db.Matches.Where(match => match.MatchTypeId == TypeOfMatchEnum.QuickMatch)
                    .Max(match => match.Id)
                : db.Matches.Where(match => match.MatchTypeId != TypeOfMatchEnum.QuickMatch)
                    .Max(match => match.Id);

            return maxId + 1;
        }

        public void StartNewMatch(Match match)
        {
            using var db = new VKRApplicationContext();

            var newMatch = new Match
            {
                Id = match.Id,
                DHRule = match.DHRule,
                MatchEnded = match.MatchEnded,
                MatchLength = match.MatchLength,
                MatchTypeId = match.MatchTypeId,
                MatchDate = match.MatchDate,
                StadiumId = match.Stadium.StadiumId
            };
            db.Matches.Add(newMatch);
            db.SaveChanges();

            AddPlayersToTheMatch(match, match.AwayTeam);
            AddPlayersToTheMatch(match, match.HomeTeam);

            newMatch.AwayTeamAbbreviation = match.AwayTeam.TeamAbbreviation;
            newMatch.HomeTeamAbbreviation = match.HomeTeam.TeamAbbreviation;

            if (match.MatchTypeId == TypeOfMatchEnum.QuickMatch) return;

            var thisMatch = db.NextMatches.FirstOrDefault(_match =>
                _match.HomeTeamAbbreviation == newMatch.HomeTeamAbbreviation &&
                _match.AwayTeamAbbreviation == newMatch.AwayTeamAbbreviation &&
                _match.MatchDate == match.MatchDate);

            if (thisMatch != null) thisMatch.IsPlayed = true;
            db.NextMatches.Update(thisMatch);
            db.SaveChanges();
        }

        private void AddPlayersToTheMatch(Match match, Team team)
        {
            using var db = new VKRApplicationContext();

            var startingPitcher = FindStartingPitcherForThisTeam(team);
            var lineupType = db.LineupTypes.First(lt => lt.PitcherHandId == startingPitcher.PlayerPitchingHand && lt.DesignatedHitterRule == match.DHRule);

            var startingLineup = db.StartingLineups.Include(sl => sl.PlayerInTeam)
                .Where(sl => sl.LineupTypeId == lineupType.Id && sl.PlayerInTeam.TeamId == team.TeamAbbreviation)
                .Select(sl => new LineupForMatch
                {
                    MatchId = match.Id,
                    PlayerInTeamId = sl.PlayerInTeamId,
                    PlayerPositionId = sl.PlayerPositionId,
                    PlayerNumberInLineup = sl.PlayerNumberInLineup
                }).ToList();

            var pitcher = db.StartingLineups.Include(sl => sl.PlayerInTeam)
                .ThenInclude(pit => pit.Player)
                .Where(sl =>
                    sl.LineupTypeId == 5 &&
                    sl.PlayerInTeam.CurrentPlayerInTeamStatus != InTeamStatusEnum.NotInThisTeam &&
                    sl.PlayerInTeam.PlayerId == startingPitcher.Id)
                .Select(sl => new LineupForMatch
                {
                    MatchId = match.Id,
                    PlayerInTeamId = sl.PlayerInTeamId,
                    PlayerPositionId = "P",
                    PlayerNumberInLineup = 10
                }).ToList();

            var pitcherDH = db.StartingLineups.Include(sl => sl.PlayerInTeam)
                .Where(sl => lineupType.Id % 2 == 0 &&
                    sl.PlayerInTeam.CurrentPlayerInTeamStatus != InTeamStatusEnum.NotInThisTeam && sl.PlayerInTeam.TeamId == team.TeamAbbreviation && sl.PlayerInTeam.PlayerId == startingPitcher.Id)
                .Select(sl => new LineupForMatch
                {
                    MatchId = match.Id,
                    PlayerInTeamId = sl.PlayerInTeamId,
                    PlayerPositionId = "P",
                    PlayerNumberInLineup = 9
                }).ToList();

            db.LineupsForMatches.AddRange(startingLineup);
            if (!match.DHRule) db.LineupsForMatches.AddRange(pitcherDH);
            db.LineupsForMatches.AddRange(pitcher);
            db.SaveChanges();
        }

        private Player FindStartingPitcherForThisTeam(Team team)
        {
            using var db = new VKRApplicationContext();

            var pitchersInRotation = db.StartingLineups.Include(sl => sl.PlayerInTeam)
                .Count(sl => sl.LineupTypeId == 5 && sl.PlayerInTeam.TeamId == team.TeamAbbreviation);

            var nextPitcherInLineup = (team.Wins + team.Losses + 1) % pitchersInRotation;
            var nextPitcherInLineupNumber = nextPitcherInLineup == 0 ? pitchersInRotation : nextPitcherInLineup;

            return db.StartingLineups.Include(sl => sl.PlayerInTeam)
                .ThenInclude(pit => pit.Player)
                .Where(sl => sl.LineupTypeId == 5 &&
                             sl.PlayerNumberInLineup == nextPitcherInLineupNumber &&
                             sl.PlayerInTeam.TeamId == team.TeamAbbreviation)
                .Select(sl => sl.PlayerInTeam.Player).First();
        }

        public void DeleteMatch(int matchId)
        {
            using var db = new VKRApplicationContext();

            var deletingMatch = db.Matches.FirstOrDefault(m => m.Id == matchId);

            if (deletingMatch == null) return;

            var matchForDelete = db.NextMatches.FirstOrDefault(nm =>
                nm.AwayTeamAbbreviation == deletingMatch.AwayTeamAbbreviation &&
                nm.HomeTeamAbbreviation == deletingMatch.HomeTeamAbbreviation &&
                nm.MatchDate == deletingMatch.MatchDate &&
                nm.MatchTypeId == deletingMatch.MatchTypeId);

            if (matchForDelete != null) matchForDelete.IsPlayed = false;
            db.Matches.Remove(deletingMatch);
            db.SaveChanges();
        }

        public void FinishMatch(Match match)
        {
            using var db = new VKRApplicationContext();

            var matchDb = db.Matches.FirstOrDefault(m => m.Id == match.Id);

            if (matchDb != null) matchDb.MatchEnded = true;
            db.Matches.Update(matchDb);
            db.SaveChanges();

            var MatchRes = new MatchResult
            {
                MatchId = match.Id,
                MatchWinnerId = match.GameSituations.Last().AwayTeamRuns > match.GameSituations.Last().HomeTeamRuns
                    ? match.AwayTeam.TeamAbbreviation
                    : match.HomeTeam.TeamAbbreviation,
                MatchLoserId = match.GameSituations.Last().AwayTeamRuns < match.GameSituations.Last().HomeTeamRuns
                    ? match.AwayTeam.TeamAbbreviation
                    : match.HomeTeam.TeamAbbreviation,
                Length = match.GameSituations.Last().InningNumber,
                AwayTeamRuns = match.GameSituations.Last().AwayTeamRuns,
                HomeTeamRuns = match.GameSituations.Last().HomeTeamRuns
            };

            db.MatchResults.Add(MatchRes);
            db.SaveChanges();
        }

        public void AddNewAtBat(AtBat atBat)
        {
            using var db = new VKRApplicationContext();

            db.AtBats.Add(atBat);
            db.SaveChanges();
        }

        public void AddMatchResultForThisPitcher(PitcherResults pitcherResults)
        {
            using var db = new VKRApplicationContext();

            db.PitcherResults.Add(pitcherResults);
            db.SaveChanges();
        }

        public void SubstitutePitcher(Match match, Pitcher pitcher)
        {
            using var db = new VKRApplicationContext();

            var pitcherDb = new LineupForMatch
            {
                MatchId = match.Id,
                PlayerInTeamId = pitcher.PitcherId,
                PlayerPositionId = "P",
                PlayerNumberInLineup = 10
            };

            db.LineupsForMatches.Add(pitcherDb);

            if (!match.DHRule)
            {
                var pitcherInBattingLineup = new LineupForMatch
                {
                    MatchId = match.Id,
                    PlayerInTeamId = pitcher.PitcherId,
                    PlayerPositionId = "P",
                    PlayerNumberInLineup = 9
                };
                db.LineupsForMatches.Add(pitcherInBattingLineup);
            }
            db.SaveChanges();
        }

        public void SubstituteBatter(Match match, Batter batter)
        {
            using var db = new VKRApplicationContext();

            var pitcherDb = new LineupForMatch
            {
                MatchId = match.Id,
                PlayerInTeamId = batter.BatterId,
                PlayerPositionId = batter.PositionForThisMatch,
                PlayerNumberInLineup = batter.NumberInLineup
            };

            db.LineupsForMatches.Add(pitcherDb);

            if (!match.DHRule && batter.NumberInLineup == 9 && batter.PositionForThisMatch == "P")
            {
                var pitcherInBattingLineup = new LineupForMatch
                {
                    MatchId = match.Id,
                    PlayerInTeamId = batter.BatterId,
                    PlayerPositionId = "P",
                    PlayerNumberInLineup = 10
                };
                db.LineupsForMatches.Add(pitcherInBattingLineup);
            }
            db.SaveChanges();
        }
    }
}