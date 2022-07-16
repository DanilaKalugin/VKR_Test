using System.Collections.Generic;
using System.Linq;
using VKR.EF.DAO;
using VKR.EF.Entities;

namespace VKR.BLL.NET5
{
    public class StadiumsBL
    {
        private readonly StadiumsEFDAO _stadiumsDAO = new();

        public List<Stadium> GetAllStadiums() => _stadiumsDAO.GetAllStadiums().OrderBy(stadium => stadium.StadiumTitle).ToList();

        public Stadium GetHomeStadiumForThisTeamAndTypeOfMatch(Team team, TypeOfMatchEnum typeOfMatch) => _stadiumsDAO.GetHomeStadiumForThisTeamAndTypeOfMatch(team.TeamAbbreviation, typeOfMatch);
    }
}