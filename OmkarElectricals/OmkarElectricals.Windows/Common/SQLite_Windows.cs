using System;
using OmkarElectricals.DataAccess.Interfaces;
using SQLite.Net;
using SQLite.Net.Async;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;
using OmkarElectricals.Windows.Common;

[assembly: Dependency(typeof(SQLite_Windows))]
namespace OmkarElectricals.Windows.Common
{
    public class SQLite_Windows : ISQLite
    {
        private static SQLiteConnectionWithLock _conn;
        private static Object _connectionLock = new Object();
        private string DatabaseName = "Omkar.db3";

        public SQLite_Windows() { }

        public SQLiteAsyncConnection GetAsyncConnection()
        {
            lock (_connectionLock)
            {
                var sqliteFilename = DatabaseName;
                string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
                var platform = new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT();
                var connectionString = new SQLiteConnectionString(path, storeDateTimeAsTicks: false);
                var connectionFactory = new Func<SQLiteConnectionWithLock>(
                    () =>
                    {
                        if (_conn == null)
                        {
                            _conn =
                                new SQLiteConnectionWithLock(platform,
                                    connectionString);

                        }
                        return _conn;
                    });
                return new SQLiteAsyncConnection(connectionFactory);
            }
        }

        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = DatabaseName;
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
            var platform = new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT();
            var connection = new SQLiteConnection(platform, path);
            return connection;
        }

        public void DeleteDatabase()
        {
            try
            {
                string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, DatabaseName);
                CloseConnection();
                //if (File.Exists(path))
                //{
                //    File.Delete(path);
                //}
            }
            catch
            {
                throw;
            }
        }

        public void CloseConnection()
        {
            if (_conn != null)
            {
                _conn.Close();
                _conn.Dispose();
                _conn = null;
                // Must be called as the disposal of the connection is not released until the GC runs. 
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
    }
}