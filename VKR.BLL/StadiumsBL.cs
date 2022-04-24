using System.Collections.Generic;
using System.Linq;
using VKR.DAL;
using Entities;

namespace VKR.BLL
{
    public class StadiumsBL
    {
        private readonly StadiumsDAO _stadiumsDAO;

        public StadiumsBL()
        {
            _stadiumsDAO = new StadiumsDAO();
        }

        public List<Stadium> GetAllStadims()
        {
            return _stadiumsDAO.GetAllStadiums().OrderBy(stadium => stadium.StadiumTitle).ToList();
        }
    }
}