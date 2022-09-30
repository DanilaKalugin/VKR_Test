using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VKR.EF.DAO;
using VKR.EF.Entities;

namespace VKR.BLL.NET5
{
    public class ManBL
    {
        private readonly ManEFDAO _manDAO = new();

        public async Task<List<ManInTeam>> GetListOfPeopleWithBirthdayTodayAsync()
        {
            var men = await _manDAO.GetListOfPeopleWithBirthdayTodayAsync()
                .ConfigureAwait(false);
            return men.ToList();
        }
    }
}