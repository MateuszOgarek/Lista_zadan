using System;
using System.Linq;

public static class DatabaseInitializer
{
    public static void Initialize()
    {
        using (var db = new TaskDbContext())
        {
            db.Database.EnsureCreated(); // Tworzy bazę danych, jeśli nie istnieje

            if (!db.Tasks.Any()) // Dodaje przykładowe dane
            {
                db.Tasks.Add(new TaskItem { Title = "Pierwsze zadanie", Description = "Napisz kod!", DueDate = DateTime.Now.AddDays(1) });
                db.SaveChanges();
            }
        }
    }
}
