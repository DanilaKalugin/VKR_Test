using VKR.DAL;

namespace VKR.BLL
{
    public class NewConnectionBL
    {
        private readonly NewConnectionDAO _newConnectionDAO = new NewConnectionDAO();

        public void DeployDatabase(string connectionTitle, string serverName, bool integratedSecurity, out int result, out string message, string userName = "", string userPassword = "") => _newConnectionDAO.DeployDataBase(connectionTitle, serverName, integratedSecurity, out result, out message, userName, userPassword);
    }
}