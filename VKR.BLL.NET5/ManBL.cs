using System.Collections.Generic;
using System.Linq;
using Entities.NET5;
using VKR.DAL;

namespace VKR.BLL
{
    public class ManBL
    {
        private readonly ManDAO _manDAO = new ManDAO();

        public List<ManInTeam> GetListOfPeopleWithBirthdayToday() =>_manDAO.GetListOfPeopleWithBirthdayToday().ToList();
    }
}