﻿using VKR.DAL.NET5;

namespace VKR.BLL.NET5
{
    public class NewConnectionBL
    {
        private readonly NewConnectionDAO _newConnectionDao = new();

        public void DeployDatabase(string connectionTitle, string serverName, bool integratedSecurity, out int result, out string message, string userName = "", string userPassword = "") => _newConnectionDao.DeployDataBase(connectionTitle, serverName, integratedSecurity, out result, out message, userName, userPassword);
    }
}