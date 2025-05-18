
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System;

namespace ToDoList.Core
{ 
    public class WorkTaskViewModel : BaseViewModel
    {
        public bool IsSelected { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
