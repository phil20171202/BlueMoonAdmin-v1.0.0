using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlueMoonAdmin.Models.ViewModels
{
    public class MonthlySalesViewModel
    { 
        public IEnumerable<MonthlySales> MonthlySales { get; set; }
        public decimal YearToDate { get; set; }

        public decimal LastMonth { get; set; }

        public string ChartSales { get; set; }
    }
}
