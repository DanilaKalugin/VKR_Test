﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VKR.EF.DAO.Contexts;
using VKR.EF.Entities.Enums;
using VKR.EF.Entities.Tables;
using VKR.EF.Entities.Views;

namespace VKR.EF.DAO
{
    public class TeamsEFDAO
    {
        public async Task<List<Team>> GetListAsync()
        {
            await using var db = new VKRApplicationContext();

            return await db.Teams.Include(t => t.TeamColors)
                .Include(t => t.Division)
                .OrderBy(t => t.TeamName)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<IEnumerable<Team>> GetTeamsWithWLBalanceAsync(int season, TypeOfMatchEnum type)
        {
            await using var db = new VKRApplicationContext();

            var teams = await db.Teams.Include(t => t.TeamRating)
                .Include(t => t.TeamColors)
                .Include(t => t.Manager)
                .Include(t => t.Division)
                    .ThenInclude(d => d.League)
                .ToListAsync()
                .ConfigureAwait(false);

            var standings = await db.TeamStandings
                .Where(ts => ts.MatchType == type && ts.Season == season)
                .ToListAsync()
                .ConfigureAwait(false);

            return teams.Join(standings,
                    t => t.TeamAbbreviation, 
                    tb => tb.TeamAbbreviation,
                    (team, balance) => team.SetTeamBalance(balance))
                .ToList();
        }

        public async Task<TeamBalance> GetNewTeamBalanceForThisTeam(Team team, TypeOfMatchEnum matchType, int year)
        {
            await using var db = new VKRApplicationContext();

            return await db.TeamStandings.FirstOrDefaultAsync(teamStandings => teamStandings.TeamAbbreviation == team.TeamAbbreviation &&
                                                           teamStandings.Season == year &&
                                                           teamStandings.MatchType == matchType)
                .ConfigureAwait(false);
        }

        public async Task<List<Team>> GetTeamsWithInfoAsync()
        {
            await using var db = new VKRApplicationContext();

            return await db.Teams.Include(t => t.TeamColors)
                .Include(t => t.Manager)
                    .ThenInclude(m => m.City)
                .Include(t => t.Division)
                    .ThenInclude(d => d.League)
                .Include(t => t.StadiumsForMatchTypes)
                    .ThenInclude(tsmt => tsmt.Stadium)
                .OrderBy(t => t.TeamName)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task UpdateTeam(Team team)
        {
            await using var db = new VKRApplicationContext();

            var teamDb = await db.Teams.FirstOrDefaultAsync(p => p.TeamAbbreviation == team.TeamAbbreviation)
                .ConfigureAwait(false);

            if (teamDb == null) return;

            teamDb.TeamAbbreviation = team.TeamAbbreviation;
            teamDb.TeamCity = team.TeamCity;
            teamDb.TeamName = team.TeamName;
            teamDb.DivisionId = team.Division.Id;
            teamDb.TeamManager = team.Manager?.Id;
            teamDb.FoundationYear = team.FoundationYear;

            db.Teams.Update(teamDb);
            await db.SaveChangesAsync()
                .ConfigureAwait(false);
        }

        public async Task<List<RetiredNumber>> GetRetiredNumbersForThisTeam(Team team)
        {
            await using var db = new VKRApplicationContext();

            return await db.RetiredNumbers
                .Where(rn => rn.TeamId == team.TeamAbbreviation || rn.TeamId == null)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task AddNewRetiredNumberAsync(RetiredNumber newRetiredNumber)
        {
            await using var db = new VKRApplicationContext();

            await db.RetiredNumbers.AddAsync(newRetiredNumber)
                .ConfigureAwait(false);

            await db.SaveChangesAsync()
                .ConfigureAwait(false);
        }

        public async Task<List<TeamHistoricalName>> GetTeamNamesBySeason(Season season)
        {
            await using var db = new VKRApplicationContext();

            return await db.TeamHistoricalNames
                .Where(t => t.FirstSeasonWithName <= season.Year &&
                            (t.LastSeasonWithName == null || t.LastSeasonWithName >= season.Year))
                .ToListAsync();
        }
    }
}