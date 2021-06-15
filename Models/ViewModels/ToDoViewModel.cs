using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueMoonAdmin.Models.ViewModels
{
    public class ToDoViewModel
    {

    public IEnumerable<ToDoListItem> Tasks { get; set; }

    public int TaskCompletedCount { get; set; }

    public int TaskCompleteCount { get; set; }
    public int TaskOverdueCount { get; set; }

    public int TaskPendingCount { get; set; }

    }

}
