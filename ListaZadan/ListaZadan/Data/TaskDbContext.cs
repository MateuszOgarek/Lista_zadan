using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Entity;

public class TaskDbContext : DbContext
{
    public DbSet<TaskItem> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=tasks.db");
    }
}
