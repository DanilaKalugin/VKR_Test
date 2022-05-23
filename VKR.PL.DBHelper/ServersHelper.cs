using System.Collections.Generic;
using System.Data;
using System.Data.Sql;
using System.Linq;

namespace VKR.PL.DBHelper
{
    public static class ServersHelper
    {
        public static List<string> GetAvailableServers()
        {
            var table = SqlDataSourceEnumerator.Instance.GetDataSources();
            return (from DataRow row in table.Rows 
                    select row[table.Columns[0]] + @"\" + row[table.Columns[1]]).ToList();
        }
    }
}