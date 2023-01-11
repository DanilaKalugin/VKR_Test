using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VKR.EF.DAO.Contexts;
using VKR.EF.Entities.Enums;
using VKR.EF.Entities.Tables;

namespace VKR.EF.DAO
{
    public class MatchEFDAO
    {
        public async ValueTask<DateTime> GetDateForNextMatchAsync(TypeOfMatchEnum matchType)
        {
            await using var db = new VKRApplicationContext();
            return await db.NextMatches
                .Where(match => match.MatchTypeId == matchType && !match.IsPlayed)
                .MinAsync(match => match.MatchDate)
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<MatchFromSchedule>> GetRemainingScheduleForThisDayAsync(DateTime date, TypeOfMatchEnum matchType)
        {
            await using var db = new VKRApplicationContext();
            return await db.NextMatches
                .Where(nm => !nm.IsPlayed && nm.MatchTypeId == matchType && nm.MatchDate == date)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async ValueTask<DateTime> GetMaxDateForAllMatchesAsync()
        {
            await using var db = new VKRApplicationContext();
            return await db.Matches.Include(m => m.MatchResult)
                .Where(m => m.MatchResult != null)
                .Select(m => m.MatchDate)
                .MaxAsync()
                .ConfigureAwait(false);
        }

        public async ValueTask<int> GetNextMatchId(TypeOfMatchEnum matchType)
        {
            await using var db = new VKRApplicationContext();

            var maxId = await db.Matches.MaxAsync(match => match.Id)
                .ConfigureAwait(false);

            return maxId + 1;
        }

        public async Task StartNewMatch(Match match)
        {
            await using var db = new VKRApplicationContext();

            var newMatch = new Match
            {
                Id = match.Id,
                DHRule = match.DHRule,
                MatchEnded = match.MatchEnded,
                MatchLength = match.MatchLength,
                MatchTypeId = match.MatchTypeId,
                MatchDate = match.MatchDate,
                StadiumId = match.Stadium.StadiumId,
                SeasonId = match.MatchDate.Year
            };
            db.Matches.Add(newMatch);
            await db.SaveChangesAsync();

            await AddPlayersToTheMatchAsync(match, match.AwayTeam).ConfigureAwait(false);
            await AddPlayersToTheMatchAsync(match, match.HomeTeam).ConfigureAwait(false);

            newMatch.AwayTeamAbbreviation = match.AwayTeam.TeamAbbreviation;
            newMatch.HomeTeamAbbreviation = match.HomeTeam.TeamAbbreviation;

            if (match.MatchTypeId == TypeOfMatchEnum.QuickMatch) return;

            var thisMatch = await db.NextMatches.FirstOrDefaultAsync(_match =>
                _match.HomeTeamAbbreviation == newMatch.HomeTeamAbbreviation &&
                _match.AwayTeamAbbreviation == newMatch.AwayTeamAbbreviation &&
                _match.MatchDate == match.MatchDate && !_match.IsPlayed)
                .ConfigureAwait(false);

            if (thisMatch != null)
                thisMatch.IsPlayed = true;

            db.NextMatches.Update(thisMatch);
            await db.SaveChangesAsync();
        }

        private async Task AddPlayersToTheMatchAsync(Match match, Team team)
        {
            await using var db = new VKRApplicationContext();

            var startingPitcher = await FindStartingPitcherForThisTeamAsync(team);
            var lineupType = await db.LineupTypes
                .FirstAsync(lt => lt.PitcherHandId == startingPitcher.PlayerPitchingHand && lt.DesignatedHitterRule == match.DHRule)
                .ConfigureAwait(false);

            var startingLineup = await db.StartingLineups.Include(sl => sl.PlayerInTeam)
                .Where(sl => sl.LineupTypeId == lineupType.Id && sl.PlayerInTeam.TeamId == team.TeamAbbreviation)
                .Select(sl => new LineupForMatch
                {
                    MatchId = match.Id,
                    PlayerInTeamId = sl.PlayerInTeamId,
                    PlayerPositionId = sl.PlayerPositionId,
                    PlayerNumberInLineup = sl.PlayerNumberInLineup
                }).ToListAsync()
                .ConfigureAwait(false);

            var pitcher = await db.StartingLineups.Include(sl => sl.PlayerInTeam)
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
                }).ToListAsync()
                .ConfigureAwait(false);

            var pitcherDH = await db.StartingLineups.Include(sl => sl.PlayerInTeam)
                .Where(sl => lineupType.Id % 2 == 0 &&
                    sl.PlayerInTeam.CurrentPlayerInTeamStatus != InTeamStatusEnum.NotInThisTeam && sl.PlayerInTeam.TeamId == team.TeamAbbreviation && sl.PlayerInTeam.PlayerId == startingPitcher.Id)
                .Select(sl => new LineupForMatch
                {
                    MatchId = match.Id,
                    PlayerInTeamId = sl.PlayerInTeamId,
                    PlayerPositionId = "P",
                    PlayerNumberInLineup = 9
                }).ToListAsync()
                .ConfigureAwait(false);

            await db.LineupsForMatches.AddRangeAsync(startingLineup);

            if (!match.DHRule) 
                await db.LineupsForMatches.AddRangeAsync(pitcherDH);

            db.LineupsForMatches.AddRange(pitcher);
            await db.SaveChangesAsync();
        }

        private async Task<Player> FindStartingPitcherForThisTeamAsync(Team team)
        {
            await using var db = new VKRApplicationContext();

            var pitchersInRotation = await db.StartingLineups.Include(sl => sl.PlayerInTeam)
                .CountAsync(sl => sl.LineupTypeId == 5 && sl.PlayerInTeam.TeamId == team.TeamAbbreviation)
                .ConfigureAwait(false);

            var nextPitcherInLineup = (team.Wins + team.Losses + 1) % pitchersInRotation;
            var nextPitcherInLineupNumber = nextPitcherInLineup == 0 ? pitchersInRotation : nextPitcherInLineup;

            return await db.StartingLineups.Include(sl => sl.PlayerInTeam)
                .ThenInclude(pit => pit.Player)
                .Where(sl => sl.LineupTypeId == 5 &&
                             sl.PlayerNumberInLineup == nextPitcherInLineupNumber &&
                             sl.PlayerInTeam.TeamId == team.TeamAbbreviation)
                .Select(sl => sl.PlayerInTeam.Player).FirstAsync()
                .ConfigureAwait(false);
        }

        public async Task DeleteMatch(int matchId)
        {
            await using var db = new VKRApplicationContext();

            var deletingMatch = await db.Matches.FirstOrDefaultAsync(m => m.Id == matchId)
                .ConfigureAwait(false);

            if (deletingMatch == null) return;

            var matchForDelete = await db.NextMatches.FirstOrDefaultAsync(nm =>
                nm.AwayTeamAbbreviation == deletingMatch.AwayTeamAbbreviation &&
                nm.HomeTeamAbbreviation == deletingMatch.HomeTeamAbbreviation &&
                nm.MatchDate == deletingMatch.MatchDate &&
                nm.MatchTypeId == deletingMatch.MatchTypeId)
                .ConfigureAwait(false);

            if (matchForDelete != null) matchForDelete.IsPlayed = false;
            db.Matches.Remove(deletingMatch);
            await db.SaveChangesAsync()
                .ConfigureAwait(false);
        }

        public async Task FinishMatch(Match match)
        {
            await using var db = new VKRApplicationContext();

            var matchDb = await db.Matches.FirstOrDefaultAsync(m => m.Id == match.Id);

            if (matchDb != null) matchDb.MatchEnded = true;
            db.Matches.Update(matchDb);
            await db.SaveChangesAsync();

            var matchRes = new MatchResult
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

            await db.MatchResults.AddAsync(matchRes);
            await db.SaveChangesAsync();
        }

        public async Task AddNewAtBat(AtBat atBat)
        {
            await using var db = new VKRApplicationContext();

            await db.AtBats.AddAsync(atBat)
                .ConfigureAwait(false);

            await db.SaveChangesAsync()
                .ConfigureAwait(false);
        }

        public async Task AddNewRun(Run run)
        {
            await using var db = new VKRApplicationContext();
            await db.Runs.AddAsync(run)
                .ConfigureAwait(false);

            await db.SaveChangesAsync()
                .ConfigureAwait(false);
        }

        public async Task AddMatchResultForThisPitcher(PitcherResults pitcherResults)
        {
            await using var db = new VKRApplicationContext();

            await db.PitcherResults.AddAsync(pitcherResults)
                .ConfigureAwait(false);

            await db.SaveChangesAsync()
                .ConfigureAwait(false);
        }
    }
}