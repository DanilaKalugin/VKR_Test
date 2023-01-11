using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VKR.EF.DAO.Interfaces;
using VKR.EF.Entities.Views;

namespace VKR.BLL.NET5
{
    public class ManBL
    {
        private readonly IManDAO _manDao;

        public ManBL(IManDAO manDao)
        {
            _manDao = manDao;
        }

        public async Task<List<ManInTeam>> GetListOfPeopleWithBirthdayTodayAsync()
        {
            var men = await _manDao.GetListOfPeopleWithBirthdayTodayAsync()
                .ConfigureAwait(false);

            return men.OrderBy(m => m.SecondName)
                .ThenBy(m => m.FirstName)
                .ToList();
        }
    }
}