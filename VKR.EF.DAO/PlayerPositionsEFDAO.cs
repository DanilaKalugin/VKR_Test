using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class PlayerPositionsEFDAO
    {
        public List<PlayerPosition> GetPlayerPositions()
        {
            using var db = new VKRApplicationContext();
            return db.PlayersPositions.OrderBy(pp => pp.Number).ToList();
        }

        public void FillPlayerPositionsForPlayer(Player player)
        {
            using var db = new VKRApplicationContext();
            var playerDb = db.Players.Include(p => p.Positions)
                .FirstOrDefault(p => p.Id == player.Id);

            playerDb.Positions ??= new List<PlayerPosition>();

            foreach (var position in player.Positions.Select(p => db.PlayersPositions.FirstOrDefault(pp => pp.Number == p.Number)))
                playerDb.Positions.Add(position);

            db.SaveChanges();
        }

        public void DeleteAllPositionsForPlayer(Player player)
        {
            using var db = new VKRApplicationContext();
            var playerDb = db.Players.Include(p => p.Positions)
                .FirstOrDefault(p => p.Id == player.Id);

            playerDb.Positions.Clear();
            db.Players.Update(playerDb);
            db.SaveChanges();
        }
    }
}