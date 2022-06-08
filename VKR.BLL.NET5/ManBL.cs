using System.Collections.Generic;
using System.Linq;
using VKR.DAL.NET5;
using VKR.EF.DAO;
//using VKR.Entities.NET5;
using VKR.EF.Entities;


namespace VKR.BLL.NET5
{
    public class ManBL
    {
        private readonly ManEFDAO _manDAO = new();

        public List<ManInTeam> GetListOfPeopleWithBirthdayToday() => _manDAO.GetListOfPeopleWithBirthdayToday().ToList();
    }
}