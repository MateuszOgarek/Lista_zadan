using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.Background;
using Windows.UI.Xaml.Controls.Primitives;

namespace ToDoList.Core
{
    internal class RelayCommands : ICommand
    {
        private Action mAction;

        public event EventHandler CanExecuteChanged;

        public RelayCommands(Action action) 
        {
            mAction = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mAction();
        }
    }
}
