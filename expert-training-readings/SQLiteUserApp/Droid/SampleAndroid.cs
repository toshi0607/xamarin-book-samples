using System.IO;
using SQLiteUserApp.Droid;
using Xamarin.Forms;
using SQLiteSample;

[assembly: Dependency(typeof(SampleAndroid))]

namespace SQLiteUserApp.Droid
{
    public class SampleAndroid : SQLiteInterface
    {
        public SQLite.Net.SQLiteConnection GetConnection()
        {
            var wSqlitePath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            const string wSqliteName = "SampleSQLite.db";
            var wPath = Path.Combine(wSqlitePath, wSqliteName);
            var wPlatform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var wConnect = new SQLite.Net.SQLiteConnection(wPlatform, wPath);
            return wConnect;
        }
    }
}
