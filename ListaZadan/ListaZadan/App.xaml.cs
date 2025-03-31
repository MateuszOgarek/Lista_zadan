using System.Windows;
using TaskManagerWPF.Data;
using static System.Net.Mime.MediaTypeNames;

namespace TaskManagerWPF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            using (var db = new TaskDbContext())
            {
                db.Database.EnsureCreated();
            }

            base.OnStartup(e);
        }
    }
}
