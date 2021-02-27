using System.Collections.Generic;
using System.Linq;
using VKR.DAL;
using Entities;

namespace VKR.BLL
{
    public class StadiumsBL
    {
        private readonly StadiumsDAO stadiumsDAO;

        public StadiumsBL()
        {
            stadiumsDAO = new StadiumsDAO();
        }

        public List<Stadium> GetAllStadims()
        {
            return stadiumsDAO.GetAllStadiums().OrderBy(stadium => stadium.StadiumTitle).ToList();
        }
    }
}