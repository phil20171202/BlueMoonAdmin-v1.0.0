using BlueMoonAdmin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueMoonAdmin.Models.ViewModels
{
    public class DashboardViewModel
    {
        public IEnumerable<ToDoListItem> toDoList { get; set; }

        public int CustomerCount { get; set; }

        public int ServiceCount { get; set; }

        public Customers Customers { get; set; }

    }
}
