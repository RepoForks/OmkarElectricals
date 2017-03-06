using OmkarElectricals.DataAccess.Interfaces;
using OmkarElectricals.Models;
using SQLite.Net.Async;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OmkarElectricals.DataAccess
{
    public class DatabaseInitialization : IDisposable
    {
        private SQLiteAsyncConnection _asyncConnection;

        public DatabaseInitialization()
        {
            if (_asyncConnection == null) _asyncConnection = DependencyService.Get<ISQLite>().GetAsyncConnection();
        }

        /// <summary>
        /// Initializes the tables id not exists, asynchronously.
        /// </summary>
        /// <returns></returns>
        public async Task InitializeTablesAsync()
        {
            Type[] tables = new Type[]
            {
                typeof(Customer)
            };
            //CreateTablesAsync will only create tables if not exists.
            //check https://github.com/praeclarum/sqlite-net/blob/61914587a484c6273b7f15ab9cfbf84faf4010eb/src/SQLite.cs#L407
            await _asyncConnection.CreateTablesAsync(tables).ConfigureAwait(false);
        }

        public void Dispose() { }
    }
}