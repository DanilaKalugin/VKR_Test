using System.Collections.Generic;
using System.Linq;
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

                var newPiTrecord = new PlayerInTeam()
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
            db.SaveChanges();
        }

        public List<PlayerInLineupViewModel> GetAllPlayers()
        {
            using var db = new VKRApplicationContext();
            var allPlayers = db.PlayersInTeams
                .Where(pit => pit.CurrentPlayerInTeamStatus != InTeamStatusEnum.NotInThisTeam)
                .Include(pit => pit.Player)
                .ThenInclude(p => p.City)
                .Include(p => p.Player.Positions)
                .Include(pit => pit.Player.BattingHand)
                .Include(pit => pit.Player.PitchingHand)
                .ToList();

            var allPlayersVM = allPlayers.Select(pit => new PlayerInLineupViewModel(pit.Player, 0, 0, pit.TeamId, pit.Player.Positions[0].ShortTitle)).ToList();

            var freeAgents = db.Players
                .Where(player => player.CurrentPlayerStatus == PlayerStatusEnum.FreeAgent)
                .Include(player => player.BattingHand)
                .Include(player => player.PitchingHand)
                .Include(player => player.City)
                .Include(player => player.Positions)
                .ToList();

            var freeAgentsVM = freeAgents.Select(player => new PlayerInLineupViewModel(player, 0, 0, string.Empty, player.Positions[0].ShortTitle)).ToList();

            return allPlayersVM.Union(freeAgentsVM).ToList();
        }
    }
}