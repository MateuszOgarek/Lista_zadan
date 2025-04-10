using System.Collections.Generic;
using System.Data.SQLite;

public class TaskItem
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool IsDone { get; set; }

    public override string ToString() => $"{Id}. {Description} {(IsDone ? "[✓]" : "[ ]")}";
}

public static class TaskRepository
{
    private static string connString = $"Data Source={Database.DbPath};Version=3;";

    public static List<TaskItem> GetAllTasks()
    {
        var list = new List<TaskItem>();
        using var conn = new SQLiteConnection(connString);
        conn.Open();

        var cmd = new SQLiteCommand("SELECT * FROM Tasks", conn);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new TaskItem
            {
                Id = reader.GetInt32(0),
                Description = reader.GetString(1),
                IsDone = reader.GetInt32(2) == 1
            });
        }
        return list;
    }

    public static void AddTask(string description)
    {
        using var conn = new SQLiteConnection(connString);
        conn.Open();
        var cmd = new SQLiteCommand("INSERT INTO Tasks (Description, IsDone) VALUES (@desc, 0)", conn);
        cmd.Parameters.AddWithValue("@desc", description);
        cmd.ExecuteNonQuery();
    }

    public static void UpdateTask(int id, string newDesc)
    {
        using var conn = new SQLiteConnection(connString);
        conn.Open();
        var cmd = new SQLiteCommand("UPDATE Tasks SET Description = @desc WHERE Id = @id", conn);
        cmd.Parameters.AddWithValue("@desc", newDesc);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }

    public static void DeleteTask(int id)
    {
        using var conn = new SQLiteConnection(connString);
        conn.Open();
        var cmd = new SQLiteCommand("DELETE FROM Tasks WHERE Id = @id", conn);
        cmd.Parameters.AddWithValue("@id", id);
        cmd.ExecuteNonQuery();
    }
}