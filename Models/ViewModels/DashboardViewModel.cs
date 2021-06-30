using BlueMoonAdmin.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueMoonAdmin.Models.ViewModels
{
    public class DashboardViewModel
    {
        public IEnumerable<ToDoListItem> ToDoList { get; set; }

        public int ToDoListCount { get; set; }
        
        public decimal MonthlyServiceCount { get; set; }

        public decimal ServicesCompleted { get; set; }

        public decimal ServicePercentage { get; set; }

        public int TaskCompletedCount { get; set; }

        public int TaskCompleteCount { get; set; }
        public int TaskOverdueCount { get; set; }

        public Customers Customers { get; set; }

        public decimal YearToDate { get; set; }

        public decimal LastYear { get; set; }

        public decimal LastMonth { get; set; }
        public IEnumerable<MonthlySales> MonthlySales { get; set; }

        public string ChartSales { get; set; }

    }
}
