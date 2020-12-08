using System;
using System.Data;
using System.Data.SqlClient;
using Bombyx.Data.CompLevel;

namespace Bombyx.Data.InputLevel
{
    public class DBConnectInput : IRepository
    {
        public DataTable SelectData(string query)
        {
            return Config.DataAdapter.GetResults(query);
        }
    }
}
