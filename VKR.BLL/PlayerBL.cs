using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKR.DAL;
using Entities;

namespace VKR.BLL
{
    public class PlayerBL
    {
        private readonly PlayerDAO playerDAO;

        public PlayerBL()
        {
            playerDAO = new PlayerDAO();
        }

        public List<Batter> GetBattersStats()
        {
            return playerDAO.GetBattersStats().Where(player => (player.PA / (double)player.Games) >= 3.1).OrderByDescending(batter => batter.AVG).ToList();
        }

        public List<Pitcher> GetPitchersStats()
        {
            return playerDAO.GetPitchersStats().Where(player => player.IP / player.Games >= 1).OrderBy(player => player.ERA).ToList();
        }
    }
}
