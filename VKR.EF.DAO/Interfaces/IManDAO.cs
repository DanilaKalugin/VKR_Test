using System.Collections.Generic;
using System.Threading.Tasks;
using VKR.EF.Entities;

namespace VKR.EF.DAO.Interfaces
{
    public interface IManDAO
    {
        Task<List<ManInTeam>> GetListOfPeopleWithBirthdayTodayAsync();
    }
}