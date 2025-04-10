using System.Data.SQLite;
using System.IO;

public static class Database
{
    public static string DbPath = "tasks.db";

    public static void InitializeDatabase()
    {
        if (!File.Exists(DbPath))
        {
            SQLiteConnection.CreateFile(DbPath);
        }

        using (var connection = new SQLiteConnection($"Data Source={DbPath};Version=3;"))
        {
            connection.Open();
            string tableCommand = "CREATE TABLE IF NOT EXISTS Tasks (" +
                                  "Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                  "Description TEXT NOT NULL, " +
                                  "IsDone INTEGER NOT NULL)";
            SQLiteCommand createTable = new SQLiteCommand(tableCommand, connection);
            createTable.ExecuteNonQuery();
        }
    }
}