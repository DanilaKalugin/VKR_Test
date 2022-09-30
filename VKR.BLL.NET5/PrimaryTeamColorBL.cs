using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VKR.EF.DAO;
using VKR.EF.Entities;

namespace VKR.BLL.NET5
{
    public class PrimaryTeamColorBL
    {
        private readonly PrimaryTeamColorEFDAO _primaryColorDao = new();

        public async Task<List<TeamColor>> GetPrimaryTeamColorsAsync()
        {
            var colors = await _primaryColorDao.GetPrimaryTeamColorsAsync()
                .ConfigureAwait(false);
            return colors.ToList();
        }
    }
}