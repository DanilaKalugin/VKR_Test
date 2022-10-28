using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VKR.EF.DAO;
using VKR.EF.Entities;

namespace VKR.BLL.NET5
{
    public class ManagerBL
    {
        private readonly ManagerEFDAO _mangerEfdao = new();

        public async Task<List<Manager>> GetAllManagersAsync()
        {
            var managers = await _mangerEfdao.GetAllManagersAsync().ConfigureAwait(false);

            return managers
                .OrderBy(m => m.SecondName)
                .ThenBy(m => m.FirstName)
                .ToList();
        }

        public async Task<uint> GetIdForNewManager() =>
            await _mangerEfdao.GetIdForNewManager()
                .ConfigureAwait(false);

        public async Task AddManager(Manager manager)
        {
           await _mangerEfdao.AddManager(manager)
               .ConfigureAwait(false);
        }
    }
}