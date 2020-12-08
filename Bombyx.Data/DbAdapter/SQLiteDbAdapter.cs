using System;
using System.Data;
using System.Data.SQLite;

namespace Bombyx.Data.DbAdapter
{
    public class SQLiteDbAdapter : IDbAdapter
    {
        // this can be modified if needed..
        public string ConnectionString { get; set; }

        public SQLiteDbAdapter(string connection)
        {
            ConnectionString = connection;
        }

        private SQLiteConnection CreateConnection()
        {
            // replace with SqlServer if needed.
            return new SQLiteConnection(ConnectionString);
        }

        public DataTable GetResults(string query)
        {
            var results = new DataTable();
            // create new connection..
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
