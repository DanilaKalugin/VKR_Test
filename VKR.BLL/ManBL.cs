using Entities;
using System.Collections.Generic;
using System.Linq;
using VKR.DAL;

namespace VKR.BLL
{
    public class ManBL
    {
        private readonly ManDAO manDAO;

        public ManBL()
        {
            manDAO = new ManDAO();
        }

        public List<ManInTeam> GetListOfPeopleWithBirthdayToday()
        {
            return manDAO.GetListOfPeopleWithBirthdayToday().ToList();
        }
    }
}