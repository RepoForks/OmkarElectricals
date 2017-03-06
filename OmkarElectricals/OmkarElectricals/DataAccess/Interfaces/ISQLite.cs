using SQLite.Net;
using SQLite.Net.Async;

namespace OmkarElectricals.DataAccess.Interfaces
{
    public interface ISQLite
    {
        /// <summary>
        /// Gets SQLite connection (SQLite.net PCL) for respective OSes
        /// </summary>
        /// <returns>returns sqlite connection</returns>
        SQLiteConnection GetConnection();

        /// <summary>
        /// Gets SQLiteAsync connection (SQLite.net PCL) for respective OSes
        /// </summary>
        /// <returns>returns sqlite async connection</returns>
        SQLiteAsyncConnection GetAsyncConnection();
    }
}
