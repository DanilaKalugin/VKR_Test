using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class SubstitutionEFDAO
    {
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

        public List<Pitcher> GetAvailablePitchers(Match match, Team team)
        {
            using var db = new VKRApplicationContext();

            var notAvailablePitchers = db.StartingLineups.Where(sl => sl.LineupTypeId == 5)
                .Select(sl => sl.PlayerInTeamId)
                .Union(db.LineupsForMatches.Where(lfm => lfm.MatchId == match.Id)
                    .Select(sl => sl.PlayerInTeamId));

            var pitchersDb = db.PlayersInTeams.Include(pit => pit.Player)
                .ThenInclude(player => player.Positions)
                .Where(pit => pit.CurrentPlayerInTeamStatus == InTeamStatusEnum.ActiveRoster &&
                              pit.TeamId == team.TeamAbbreviation &&
                              pit.Player.Positions.Any(pp => pp.ShortTitle == "P") &&
                              !notAvailablePitchers.Contains(pit.Id))
                .ToList();

            var pitchers = pitchersDb.Select(p => new Pitcher(p.Player, 0, p.Id)).ToList();
            var pitcherIds = pitchers.Select(pitcher => pitcher.Id);

            var pitchingStats = db.PlayersPitchingStats.Where(pitchingStats =>
                pitchingStats.Season == match.MatchDate.Year &&
                pitchingStats.MatchType == match.MatchTypeId &&
                pitcherIds.Contains(pitchingStats.PlayerID)).ToList();

            return pitchers.Join(pitchingStats,
                pitcher => pitcher.Id,
                ps => ps.PlayerID,
                (pitcher, stats) => pitcher.SetPitchingStats(stats)).ToList();
        }

        public List<Batter> GetAvailableBatters(Match match, Team team, Batter batter)
        {
            using var db = new VKRApplicationContext();

            var notAvailableBatters = db.LineupsForMatches.Where(lfm => lfm.MatchId == match.Id)
                    .Select(sl => sl.PlayerInTeamId);

            var battersDB = batter.PositionForThisMatch switch
            {
                "P" => db.PlayersInTeams.Include(pit => pit.Player)
                    .ThenInclude(player => player.Positions)
                    .Where(pit => pit.CurrentPlayerInTeamStatus == InTeamStatusEnum.ActiveRoster &&
                                  pit.TeamId == team.TeamAbbreviation && !pit.Player.CanPlayAsPitcher &&
                                  !notAvailableBatters.Contains(pit.Id))
                    .ToList(),
                "DH" => db.PlayersInTeams.Include(pit => pit.Player)
                    .ThenInclude(player => player.Positions)
                    .Where(pit => pit.CurrentPlayerInTeamStatus == InTeamStatusEnum.ActiveRoster &&
                                  pit.TeamId == team.TeamAbbreviation && !pit.Player.CanPlayAsPitcher &&
                                  !notAvailableBatters.Contains(pit.Id))
                    .ToList(),
                _ => db.PlayersInTeams.Include(pit => pit.Player)
                    .ThenInclude(player => player.Positions)
                    .Where(pit => pit.CurrentPlayerInTeamStatus == InTeamStatusEnum.ActiveRoster &&
                                  pit.TeamId == team.TeamAbbreviation &&
                                  pit.Player.Positions.Any(pp => pp.ShortTitle == batter.PositionForThisMatch) &&
                                  !notAvailableBatters.Contains(pit.Id))
                    .ToList()
            };

            var batters = battersDB.Select(pit => new Batter(pit.Player, batter.PositionForThisMatch, batter.NumberInLineup, pit.Id))
                .ToList();

            var battersIds = batters.Select(batter => batter.Id).ToList();

            var battingStats = db.PlayersBattingStats.Where(stats =>
                stats.Season == match.MatchDate.Year &&
                stats.MatchType == match.MatchTypeId &&
                battersIds.Contains(stats.PlayerID)).ToList();

            return batters.Join(battingStats,
                batter => batter.Id,
                stats => stats.PlayerID,
                (batter, stats) => batter.SetBattingStats(stats)).ToList();
        }
    }
}