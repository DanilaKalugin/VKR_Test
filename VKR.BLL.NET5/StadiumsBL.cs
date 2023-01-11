using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VKR.EF.DAO;
using VKR.EF.Entities.Enums;
using VKR.EF.Entities.Tables;

namespace VKR.BLL.NET5
{
    public class StadiumsBL
    {
        private readonly StadiumsEFDAO _stadiumsDao = new();

        public async Task<List<Stadium>> GetAllStadiumsAsync()
        {
            var stadiums = await _stadiumsDao.GetAllStadiumsAsync()
                .ConfigureAwait(false);
            return stadiums.OrderBy(stadium => stadium.StadiumTitle).ToList();
        }

        public async Task<Stadium> GetHomeStadiumForThisTeamAndTypeOfMatch(Team team, TypeOfMatchEnum typeOfMatch) => 
            await _stadiumsDao.GetHomeStadiumForThisTeamAndTypeOfMatchAsync(team.TeamAbbreviation, typeOfMatch)
                .ConfigureAwait(false);

        public async Task<ushort> GetIdForNewStadium() =>
            await _stadiumsDao.GetIdForNewStadium()
                .ConfigureAwait(false);

        public async Task AddNewStadium(Stadium stadium) =>
            await _stadiumsDao.AddNewStadium(stadium)
                .ConfigureAwait(false);

        public async Task UpdateStadiumForThisTeamAndMatchType(TeamStadiumForTypeOfMatch tsmt) =>
            await _stadiumsDao.UpdateStadiumForThisTeamAndMatchType(tsmt)
                .ConfigureAwait(false);
    }
}