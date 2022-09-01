using System.Collections.Generic;
using System.Linq;
using VKR.EF.DAO;
using VKR.EF.Entities;

namespace VKR.BLL.NET5
{
    public class PlayerPositionsBL
    {
        private readonly PlayerPositionsEFDAO _positionsDao = new();

        public List<PlayerPosition> GetAllPlayerPositions() => _positionsDao.GetPlayerPositions().ToList();

        public List<PlayerPosition> GetAvailablePlayerPositions() => _positionsDao.GetPlayerPositions().Where(pp => pp.Number % 9 != 0).ToList();

        public void FillPositionsForThisPlayer(Player player)
        {
            
        }
    }
}