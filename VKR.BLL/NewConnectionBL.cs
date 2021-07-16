using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VKR.DAL;

namespace VKR.BLL
{
    public class NewConnectionBL
    {
        private readonly NewConnectionDAO newConnectionDAO;

        public NewConnectionBL()
        {
            newConnectionDAO = new NewConnectionDAO();
        }

        public void DeployDatabase(string ConnectionTitle, string ServerName, bool IntegratedSecurity, out int result, out string message, string UserName = "", string UserPassword = "")
        {
            newConnectionDAO.DeployDataBase(ConnectionTitle, ServerName, IntegratedSecurity, out result, out message, UserName, UserPassword);
        }
    }
}
