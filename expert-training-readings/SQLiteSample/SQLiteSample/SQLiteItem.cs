using System;
using SQLite.Net.Attributes;

namespace SQLiteSample
{
    public class SQLiteItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Text { get; set; }
        public DateTime InsertDate { get; set; }
    }
}
