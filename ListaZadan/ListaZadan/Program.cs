using System;
using System.Linq;

class Program
{
    static void Main()
    {
        DatabaseInitializer.Initialize(); // Tworzy bazę, jeśli nie istnieje

        while (true)
        {
            Console.WriteLine("\nZarządzanie listą zadań");
            Console.WriteLine("1. Dodaj zadanie");
            Console.WriteLine("2. Wyświetl zadania");
            Console.WriteLine("3. Oznacz jako ukończone");
            Console.WriteLine("4. Usuń zadanie");
            Console.WriteLine("5. Wyjście");
            Console.Write("Wybierz opcję: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    ListTasks();
                    break;
                case "3":
                    CompleteTask();
                    break;
                case "4":
                    DeleteTask();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Nieprawidłowa opcja, spróbuj ponownie.");
                    break;
            }
        }
    }

    static void AddTask()
    {
        Console.Write("Tytuł: ");
        string title = Console.ReadLine();
        Console.Write("Opis: ");
        string description = Console.ReadLine();

        using (var db = new TaskDbContext())
        {
            db.Tasks.Add(new TaskItem { Title = title, Description = description, DueDate = DateTime.Now.AddDays(3) });
            db.SaveChanges();
        }

        Console.WriteLine("Dodano zadanie!");
    }

    static void ListTasks()
    {
        using (var db = new TaskDbContext())
        {
            var tasks = db.Tasks.ToList();
            Console.WriteLine("\nLista zadań:");
            foreach (var task in tasks)
            {
                Console.WriteLine($"[{task.Id}] {task.Title} - {task.Description} | Ukończone: {task.IsCompleted}");
            }
        }
    }

    static void CompleteTask()
    {
        Console.Write("Podaj ID zadania do oznaczenia jako ukończone: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            using (var db = new TaskDbContext())
            {
                var task = db.Tasks.Find(id);
                if (task != null)
                {
                    task.IsCompleted = true;
                    db.SaveChanges();
                    Console.WriteLine("Zadanie oznaczone jako ukończone.");
                }
                else
                {
                    Console.WriteLine("Nie znaleziono zadania.");
                }
            }
        }
        else
        {
            Console.WriteLine("Nieprawidłowe ID.");
        }
    }

    static void DeleteTask()
    {
        Console.Write("Podaj ID zadania do usunięcia: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            using (var db = new TaskDbContext())
            {
                var task = db.Tasks.Find(id);
                if (task != null)
                {
                    db.Tasks.Remove(task);
                    db.SaveChanges();
                    Console.WriteLine("Zadanie usunięte.");
                }
                else
                {
                    Console.WriteLine("Nie znaleziono zadania.");
                }
            }
        }
        else
        {
            Console.WriteLine("Nieprawidłowe ID.");
        }
    }
}
