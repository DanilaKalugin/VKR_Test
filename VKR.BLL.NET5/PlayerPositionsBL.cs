using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VKR.EF.DAO;
using VKR.EF.Entities;

namespace VKR.BLL.NET5
{
    public class PlayerPositionsBL
    {
        private readonly PlayerPositionsEFDAO _positionsDao = new();

        public async Task<List<PlayerPosition>> GetAllPlayerPositions()
        {
            var positions = await _positionsDao.GetPlayerPositions()
                .ConfigureAwait(false);
            return positions.ToList();
        }

        public async Task<List<PlayerPosition>> GetAvailablePlayerPositions()
        {
            var positions = await _positionsDao.GetPlayerPositions()
                .ConfigureAwait(false);
            return positions.Where(pp => pp.Number % 9 != 0).ToList();
        }
    }
}