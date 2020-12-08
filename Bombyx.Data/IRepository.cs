using System.Data;

namespace Bombyx.Data
{
    public interface IRepository
    {
        DataTable SelectData(string query);
    }
}