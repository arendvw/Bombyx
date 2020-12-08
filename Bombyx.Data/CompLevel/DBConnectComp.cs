using System;
using System.Data;
using System.Data.SqlClient;

namespace Bombyx.Data.CompLevel
{
    public class DBConnectComp : IRepository
    {
        public DataTable SelectData(string query)
        {
            return Config.DataAdapter.GetResults(query);
        }
    }
}
