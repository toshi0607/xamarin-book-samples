using System.Collections.Generic;
using SQLite.Net;
using Xamarin.Forms;

namespace SQLiteSample
{
    public class SqliteControl
    {
        static readonly object wObject = new object();
        readonly SQLiteConnection wSQLiteConnection;
        public SqliteControl()
        {
            wSQLiteConnection = DependencyService.Get<SQLiteInterface>().GetConnection();
            wSQLiteConnection.CreateTable<SQLiteItem>();
        }

        public IEnumerable<SQLiteItem> GetItems()
        {
            lock (wObject) {
                return wSQLiteConnection.Table<SQLiteItem>();
            }
        }

        public void InsertItem(SQLiteItem item) {
            lock (wObject) {
                wSQLiteConnection.Insert(item);
            }
        }

        public void DeleteItem(SQLiteItem item) {
            lock (wObject) {
                wSQLiteConnection.Delete(item);
            }
        }
    }
}
