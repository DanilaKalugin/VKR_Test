using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VKR.EF.Entities;

namespace VKR.EF.DAO
{
    public class PlayerPositionsEFDAO
    {
        public async Task<List<PlayerPosition>> GetPlayerPositions()
        {
            await using var db = new VKRApplicationContext();
            return await db.PlayersPositions
                .OrderBy(pp => pp.Number)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task FillPlayerPositionsForPlayer(Player player)
        {
            await using var db = new VKRApplicationContext();
            var playerDb = await db.Players.Include(p => p.Positions)
                .FirstOrDefaultAsync(p => p.Id == player.Id)
                .ConfigureAwait(false);

            playerDb.Positions ??= new List<PlayerPosition>();

            foreach (var position in player.Positions.Select(p => db.PlayersPositions.FirstOrDefault(pp => pp.Number == p.Number)))
                playerDb.Positions.Add(position);

            await db.SaveChangesAsync()
                .ConfigureAwait(false);
        }

        public async Task DeleteAllPositionsForPlayer(Player player)
        {
            await using var db = new VKRApplicationContext();
            var playerDb = await db.Players.Include(p => p.Positions)
                .FirstOrDefaultAsync(p => p.Id == player.Id)
                .ConfigureAwait(false);

            playerDb.Positions.Clear();
            db.Players.Update(playerDb);
            await db.SaveChangesAsync()
                .ConfigureAwait(false);
        }
    }
}