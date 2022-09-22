using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VKR.EF.DAO;
using VKR.EF.Entities;

namespace VKR.BLL.NET5
{
    public class StadiumsBL
    {
        private readonly StadiumsEFDAO _stadiumsDAO = new();

        public async Task<List<Stadium>> GetAllStadiumsAsync()
        {
            var stadiums = await _stadiumsDAO.GetAllStadiumsAsync().ConfigureAwait(false);
            return stadiums.OrderBy(stadium => stadium.StadiumTitle).ToList();
        }

        public async Task<Stadium> GetHomeStadiumForThisTeamAndTypeOfMatch(Team team, TypeOfMatchEnum typeOfMatch) => 
            await _stadiumsDAO.GetHomeStadiumForThisTeamAndTypeOfMatchAsync(team.TeamAbbreviation, typeOfMatch)
                .ConfigureAwait(false);
    }
}