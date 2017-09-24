using System;
using System.IO;
using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;
using SQLiteUserApp.iOS;
using Xamarin.Forms;
using SQLiteSample;

[assembly: Dependency(typeof(SampleiOS))]

namespace SQLiteUserApp.iOS
{
    public class SampleiOS : SQLiteInterface
    {
        public SQLiteConnection GetConnection()
        {
            var wFolderPath = Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var wSqlitePath = Path.Combine(wFolderPath, "..", "Library");
            const string wSqliteName = "SampleSQLite.db";
            var wPath = Path.Combine(wSqlitePath, wSqliteName);
            var wPlatform = new SQLitePlatformIOS();
            var wConnect = new SQLiteConnection(wPlatform, wPath);
            return wConnect;
        }
    }
}
