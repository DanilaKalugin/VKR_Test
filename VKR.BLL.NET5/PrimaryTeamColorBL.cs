using System.Collections.Generic;
using VKR.EF.DAO;
using VKR.EF.Entities;

namespace VKR.BLL.NET5
{
    public class PrimaryTeamColorBL
    {
        private readonly PrimaryTeamColorEFDAO _primaryColorDao = new();

        public List<TeamColor> GetPrimaryTeamColors() => _primaryColorDao.GetPrimaryTeamColors();
    }
}