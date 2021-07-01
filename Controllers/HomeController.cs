using BlueMoonAdmin.Data;
using BlueMoonAdmin.Models;
using BlueMoonAdmin.Models.ViewModels;
using BlueMoonAdmin.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Linq;

namespace BlueMoonAdmin.Controllers
{

    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;

        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }

        //private readonly ILogger<HomeController> _logger;
        //private readonly IEmployyeService employyeService;

        //public HomeController(ILogger<HomeController> logger, IEmployyeService employyeService)
        //{
        //    _logger = logger;
        //    this.employyeService = employyeService;
        //}

        public IActionResult Index()
        {
            // current date
            DateTime dt = DateTime.Now;
            // use current date and find 1 date of this month and next
            DateTime firstDayCurrentMonth = dt.AddDays(-dt.Day + 1);
            DateTime firstDayNextMonth = firstDayCurrentMonth.AddMonths(1);
            // any service due before the end of the month, this includes any overdue from last month
            decimal ServiceDue = _db.ServiceCustomers.Where(c => c.NextServiceDate < firstDayNextMonth).Count();

            DashboardViewModel DBView = new();
            // used for to-do table at bottom
            DBView.ToDoList = _db.ToDoListItems;
            // used to counters top left of to-do table
            DBView.ToDoListCount = _db.ToDoListItems.Count();
            DBView.TaskOverdueCount = _db.ToDoListItems.Where(c => c.ToDoDueDate > DateTime.Now && c.Completed == false ).Count();
            DBView.TaskCompleteCount = _db.ToDoListItems.Where(c => c.ToDoDueDate > DateTime.Now.AddDays(-30) && c.Completed == true).Count();
            DBView.TaskCompletedCount = _db.ToDoListItems.Where(c => c.ToDoDueDate > DateTime.Now.AddMonths(-12) && c.Completed == true).Count();
            DBView.MonthlySales = _db.MonthlySalesFigure.Where(s => s.Date.Year == DateTime.Now.Year).ToList();
            DBView.LastYear = _db.MonthlySalesFigure.Where(c=> c.Date.Year == DateTime.Now.AddYears(-1).Year).Sum(c => c.Amount);
            DBView.YearToDate = DBView.MonthlySales.Sum(c => c.Amount);

            if (DBView.MonthlySales.FirstOrDefault(c => c.Date.Month == DateTime.Now.AddMonths(-1).Month) != null)
            {
                DBView.LastMonth = DBView.MonthlySales.FirstOrDefault(c => c.Date.Month == DateTime.Now.AddMonths(-1).Month).Amount;
            }
            else
            {
                DBView.LastMonth = 0;
            }

            // Generating the string to populate the year to date sales chart
            var sales = new string[12];
            foreach (var item in DBView.MonthlySales)
            {
               sales[item.Date.Month-1] = item.Amount.ToString();
            }
            DBView.ChartSales = string.Join(",", sales);
            // ServiceType has a dropdown with options Complete, Partial and Break Fix.  For service, I did not want to pick up break fix figures.
            DBView.ServicesCompleted = _db.Notes.Where(c => c.Category == "Service Notes" && c.ServiceType != "Break Fix").Count();
            // Calendar month figures
            DBView.MonthlyServiceCount = ServiceDue + DBView.ServicesCompleted;
            if (DBView.ServicesCompleted <= 0 && ServiceDue <= 0)
            {
                DBView.ServicePercentage = 100;
            }
            else
            {
                if (DBView.ServicesCompleted == 0 && ServiceDue > 0)
                {
                    DBView.ServicePercentage = 0;
                }
                else
                {
                    decimal Percentage = ServiceDue / DBView.MonthlyServiceCount *100;
                    // rounding figure to avoid decimal places in percentage screen.
                    DBView.ServicePercentage = Math.Round(Percentage, MidpointRounding.AwayFromZero);
                }
            }
            
            
            return View(DBView);


        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Terms()
        {
            return View();
        }

        public IActionResult Charts()
        {
            return View();
        }

        //public IActionResult Tables()
        //{
        //    var empleados = employyeService.GetAll();
        //    return View(empleados);
        //}

        public IActionResult _401()
        {
            return View();
        }

        public IActionResult _404()
        {
            return View();
        }

        public IActionResult _500()
        {
            return View();
        }

        public IActionResult LayoutStatic()
        {
            return View();
        }

        public IActionResult SidenavLight()
        {
            return View();
        }


        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
