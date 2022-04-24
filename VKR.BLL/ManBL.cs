using Entities;
using System.Collections.Generic;
using System.Linq;
using VKR.DAL;

namespace VKR.BLL
{
    public class ManBL
    {
        private readonly ManDAO _manDAO;

        public ManBL()
        {
            _manDAO = new ManDAO();
        }

        public List<ManInTeam> GetListOfPeopleWithBirthdayToday()
        {
            return _manDAO.GetListOfPeopleWithBirthdayToday().ToList();
        }
    }
}