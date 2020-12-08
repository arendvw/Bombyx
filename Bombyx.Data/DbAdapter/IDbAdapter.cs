using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombyx.Data.DbAdapter
{
    public interface IDbAdapter
    {
        DataTable GetResults(string query);
    }
}
