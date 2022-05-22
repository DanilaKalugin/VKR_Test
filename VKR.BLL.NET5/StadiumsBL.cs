using System.Collections.Generic;
using System.Linq;
using Entities.NET5;
using VKR.DAL.NET5;

namespace VKR.BLL.NET5
{
    public class StadiumsBL
    {
        private readonly StadiumsDAO _stadiumsDAO = new();

        public List<Stadium> GetAllStadiums() => _stadiumsDAO.GetAllStadiums().OrderBy(stadium => stadium.StadiumTitle).ToList();
    }
}