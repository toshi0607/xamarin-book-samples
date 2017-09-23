using SQLite.Net;

namespace SQLiteSample
{
    public interface SQLiteInterface
    {
        SQLiteConnection GetConnection();
    }
}
