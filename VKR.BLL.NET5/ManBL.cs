﻿using System.Collections.Generic;
using System.Linq;
using Entities.NET5;
using VKR.DAL.NET5;

namespace VKR.BLL.NET5
{
    public class ManBL
    {
        private readonly ManDAO _manDAO = new();

        public List<ManInTeam> GetListOfPeopleWithBirthdayToday() => _manDAO.GetListOfPeopleWithBirthdayToday().ToList();
    }
}