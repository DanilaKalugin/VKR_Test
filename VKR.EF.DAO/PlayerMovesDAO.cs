using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class PlayerMovesDAO
    {
        public void MovePlayerToNewTeam(Player player, Team team)
        {
            using var db = new VKRApplicationContext();

            var pit = db.PlayersInTeams.FirstOrDefault(pit => pit.PlayerId == player.Id &&
                                                              pit.TeamId == team.TeamAbbreviation);

            var playerInCurrentTeam = db.PlayersInTeams.Where(pit => pit.PlayerId == player.Id).ToList();

            foreach (var playerInTeam in playerInCurrentTeam)
            {
                playerInTeam.CurrentPlayerInTeamStatus = InTeamStatusEnum.NotInThisTeam;
                db.PlayersInTeams.Update(playerInTeam);
            }

            if (pit == null)
            {
                var maxId = db.PlayersInTeams.Max(pit => pit.Id);

                var newPiTrecord = new PlayerInTeam
                {
                    CurrentPlayerInTeamStatus = InTeamStatusEnum.Reserve,
                    PlayerId = player.Id,
                    TeamId = team.TeamAbbreviation,
                    Id = maxId + 1
                };
                db.PlayersInTeams.Add(newPiTrecord);
            }
            else
            {
                pit.CurrentPlayerInTeamStatus = InTeamStatusEnum.Reserve;
                db.PlayersInTeams.Update(pit);
            }

            var playerDB = db.Players.FirstOrDefault(p => p.Id == player.Id);
            if (playerDB is { CurrentPlayerStatus: PlayerStatusEnum.FreeAgent })
            {
                playerDB.CurrentPlayerStatus = PlayerStatusEnum.Active;
                db.Players.Update(playerDB);
            }

            db.SaveChanges();
        }

        public void ChangePlayerInTeamStatus(Player player, Team team, InTeamStatusEnum inTeamStatus)
        {
            using var db = new VKRApplicationContext();
            var pit = db.PlayersInTeams.FirstOrDefault(pit => pit.TeamId == team.TeamAbbreviation && pit.PlayerId == player.Id);

            if (pit == null) return;
            pit.CurrentPlayerInTeamStatus = inTeamStatus;
            db.PlayersInTeams.Update(pit);
            db.SaveChanges();
        }

        public void ReleasePlayer(Player player)
        {
            using var db = new VKRApplicationContext();
            var playerDB = db.Players.FirstOrDefault(p => p.Id == player.Id);
            if (playerDB == null) return;

            playerDB.CurrentPlayerStatus = PlayerStatusEnum.FreeAgent;
            db.Players.Update(playerDB);

            var pitRecords = db.PlayersInTeams.Where(pit => pit.PlayerId == player.Id).ToList();
            foreach (var playerInTeam in pitRecords)
            {
                playerInTeam.CurrentPlayerInTeamStatus = InTeamStatusEnum.NotInThisTeam;
                db.PlayersInTeams.Update(playerInTeam);
            }

            db.SaveChanges();
        }

        public void RemovePlayerFromStartingLineup(Player player, Team team, byte lineupNumber)
        {
            using var db = new VKRApplicationContext();
            var playerInTeam = db.PlayersInTeams.FirstOrDefault(pit => pit.PlayerId == player.Id &&
                                                                       pit.TeamId == team.TeamAbbreviation);

            if (playerInTeam == null) return;

            var slEntry = db.StartingLineups.FirstOrDefault(sl =>
                sl.LineupTypeId == lineupNumber && sl.PlayerInTeamId == playerInTeam.Id);

            if (slEntry == null) return;

            db.StartingLineups.Remove(slEntry);
            db.SaveChanges();
        }

        public void AssignPlayerToStartingLineup(Player player, Team team, byte lineupNumber, PlayerPosition position, byte numberInLineup)
        {
            using var db = new VKRApplicationContext();
            var playerInTeam = db.PlayersInTeams.FirstOrDefault(pit => pit.PlayerId == player.Id &&
                                                                       pit.TeamId == team.TeamAbbreviation);

            if (playerInTeam == null) return;

            var playerPosition = db.PlayersPositions.FirstOrDefault(pp => pp.Number == position.Number);

            if (playerPosition == null) return;

            var newEntryInStartingLineup = new StartingLineup
            {
                PlayerInTeamId = playerInTeam.Id,
                LineupTypeId = lineupNumber,
                PlayerPositionId = playerPosition.ShortTitle,
                PlayerNumberInLineup = numberInLineup
            };

            db.StartingLineups.Add(newEntryInStartingLineup);
            db.SaveChanges();
        }
    }
}