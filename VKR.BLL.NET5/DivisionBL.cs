using System.Collections.Generic;
using System.Threading.Tasks;
using VKR.EF.DAO;
using VKR.EF.Entities.Tables;

namespace VKR.BLL.NET5
{
    public class DivisionBL
    {
        private readonly DivisionEFDAO _divisionEfdao = new();

        public async Task<List<Division>> GetAllDivisionsAsync() => 
            await _divisionEfdao.GetAllDivisionsAsync()
                .ConfigureAwait(false);
    }
}