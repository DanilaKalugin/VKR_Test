using System;
using System.Collections.Generic;
using VKR.EF.Entities;

namespace VKR.EF.DAO.Interfaces
{
    public interface IStandingsDAO
    {
        List<TeamStandingsViewModel> GetStandings(DateTime date, TypeOfMatchEnum type);
    }
}