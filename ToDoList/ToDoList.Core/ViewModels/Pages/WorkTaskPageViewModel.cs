/*
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
*/
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Windows.UI.WindowManagement;
using Windows.UI.Xaml.Controls;

namespace ToDoList.Core
{
    public class WorkTaskPageViewModel : BaseViewModel
    {
        public ObservableCollection<WorkTaskViewModel> WorkTasksList { get; set; } = new ObservableCollection<WorkTaskViewModel>();

        public string NewWorkTaskTitle { get; set; }

        public string NewWorkTaskDescription { get; set; }

        public ICommand AddNewTaskCommand { get; set; }

        public ICommand DeleteSelectedTaskCommand { get; set; }

        public WorkTaskPageViewModel()
        {
            AddNewTaskCommand = new RelayCommands(AddNewTask);
            DeleteSelectedTaskCommand = new RelayCommands(DeleteSelectedTasks);
        }

        private void AddNewTask()
        {
            var newTask = new WorkTaskViewModel
            {
                Title = NewWorkTaskTitle,
                Description = NewWorkTaskDescription,
                CreateDate = DateTime.Now
            };

            WorkTasksList.Add(newTask);

            NewWorkTaskTitle = string.Empty;
            NewWorkTaskDescription = string.Empty;

            //OnPropertyChanged(nameof(NewWorkTaskTitle));
            //OnPropertyChanged(nameof(NewWorkTaskDescription));
        }

        private void DeleteSelectedTasks()
        {
            var selectedTasks = WorkTasksList.Where(x => x.IsSelected).ToList();
            foreach (var task in selectedTasks) 
            {
                WorkTasksList.Remove(task);
            }
        }
    }
}
