using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombyx.Data.DbAdapter
{
    class SqlDbAdapter : IDbAdapter
    {
        public string ConnectionString { get; set; }

        public SqlDbAdapter(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private SQLiteConnection CreateConnection()
        {
            // replace with SqlServer if needed.
            return new SQLiteConnection(ConnectionString);
        }

        public DataTable GetResults(string query)
        {
            var results = new DataTable();
            // create new connectionString..
            using (var connection = CreateConnection())
            {
                try
                {

                    var cmd = new SQLiteCommand(query, connection);
                    connection.Open();
                    var da = new SQLiteDataAdapter(cmd);
                    da.Fill(results);

                    connection.Close();
                }
                catch (Exception ex)
                {
                    // ignore for now..
                }
            }
            // auto disconnect..
            return results;
        }
    }
}
