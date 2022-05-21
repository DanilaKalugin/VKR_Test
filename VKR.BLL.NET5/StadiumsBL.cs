using System.Collections.Generic;
using System.Linq;
using Entities;
using VKR.DAL;

namespace VKR.BLL
{
    public class StadiumsBL
    {
        private readonly StadiumsDAO _stadiumsDAO = new StadiumsDAO();

        public List<Stadium> GetAllStadiums() => _stadiumsDAO.GetAllStadiums().OrderBy(stadium => stadium.StadiumTitle).ToList();
    }
}